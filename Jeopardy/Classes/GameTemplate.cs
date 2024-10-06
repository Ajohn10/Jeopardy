using CsvHelper.Configuration.Attributes;

namespace Jeopardy.Classes
{
    public abstract class GameTemplate
    {
        /// <summary>
        /// name of game to display to user
        /// </summary>
        public virtual string DisplayName { get => "UNKNOWN"; }
        /// <summary>
        /// categories within game
        /// </summary>
        public List<CategoryTemplate> Categories { get; } = new List<CategoryTemplate>();
        /// <summary>
        /// if game has been read
        /// </summary>
        [Ignore]
        public virtual bool HasReadGameFile { get; }

        /// <summary>
        /// reads game into memory
        /// </summary>
        public virtual void ReadGameFile()
        {

        }
    }
}
