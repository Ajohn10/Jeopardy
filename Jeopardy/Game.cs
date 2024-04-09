using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class Game
    {
        /// <summary>
        /// file that is used for game data
        /// </summary>
        public FileInfo GameFile { get; set; }
        /// <summary>
        /// name of game to display to user
        /// </summary>
        public string DisplayName { get => GameFile == null ? "UNKNOWN" : Path.GetFileNameWithoutExtension(GameFile?.Name); }
        /// <summary>
        /// categories within game
        /// </summary>
        public List<JeopardyCategory> Categories { get; } = new List<JeopardyCategory>();

        /// <summary>
        /// resets internal memory of game 
        /// </summary>
        public void ResetGame()
        {
            Categories.Clear();
        }

        /// <summary>
        /// reads game into memory
        /// </summary>
        public void ReadGameFile()
        {
            ResetGame();

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
