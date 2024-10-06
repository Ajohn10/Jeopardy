using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Jeopardy.Classes.GameTemplates
{
    internal class CSVGameTemplate : GameTemplate
    {
        /// <summary>
        /// file that is used for game data
        /// </summary>
        public FileInfo GameFile { get; }
        /// <summary>
        /// name of game to display to user
        /// </summary>
        public override string DisplayName { get => GameFile == null ? "UNKNOWN" : Path.GetFileNameWithoutExtension(GameFile?.Name); }

        private bool _hasReadGameFile;
		public override bool HasReadGameFile => _hasReadGameFile;

		public CSVGameTemplate(FileInfo gameFile)
        {
            GameFile = gameFile;
        }

        /// <summary>
        /// reads csv game file
        /// </summary>
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
                    var questions = csv.GetRecords<QuestionTemplate>().ToList();
                    var categories = questions.Select(u => u.Category).Distinct().ToList();
                    categories.ForEach(u =>
                    {
                        Categories.Add(new CategoryTemplate
                        {
                            Name = u,
                            Questions = questions.Where(v => v.Category == u).ToList()
                        });
                    });
                }
            }

            _hasReadGameFile = true;
        }
    }
}
