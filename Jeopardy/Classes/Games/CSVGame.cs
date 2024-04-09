using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Jeopardy.Classes.Games
{
    internal class CSVGame : Game
    {
        /// <summary>
        /// file that is used for game data
        /// </summary>
        public FileInfo GameFile { get; }
        /// <summary>
        /// name of game to display to user
        /// </summary>
        public override string DisplayName { get => GameFile == null ? "UNKNOWN" : Path.GetFileNameWithoutExtension(GameFile?.Name); }

        public CSVGame(FileInfo gameFile)
        {
            GameFile = gameFile;
        }

        public override void ReadGameFile()
        {
            base.ReadGameFile();

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null,
            };

            using (var reader = new StreamReader(GameFile.FullName))
            {
                using (var csv = new CsvReader(reader, configuration))
                {
                    var questions = csv.GetRecords<JeopardyQuestion>().ToList();
                    var categories = questions.Select(u => u.Category).Distinct().ToList();
                    categories.ForEach(u =>
                    {
                        Categories.Add(new JeopardyCategory
                        {
                            Name = u,
                            Questions = questions.Where(v => v.Category == u).ToList()
                        });
                    });
                }
            }
        }
    }
}
