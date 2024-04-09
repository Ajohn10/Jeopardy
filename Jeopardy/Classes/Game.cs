using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy.Classes
{
    public abstract class Game
    {
        /// <summary>
        /// name of game to display to user
        /// </summary>
        public virtual string DisplayName { get => "UNKNOWN"; }
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
        public virtual void ReadGameFile()
        {
            ResetGame();
        }
    }
}
