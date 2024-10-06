using CsvHelper.Configuration.Attributes;

namespace Jeopardy.Classes
{
    public class QuestionTemplate
    {
        /// <summary>
        /// category of question
        /// </summary>
        [Index(0)]
        public string Category { get; set; }
        /// <summary>
        /// question to be posed
        /// </summary>
        [Index(1)]
        public string Question { get; set; }
        /// <summary>
        /// answer to question
        /// </summary>
        [Index(2)]
        public string Answer { get; set; }
        /// <summary>
        /// worth of question
        /// </summary>
        [Index(3)]
        public int Weight { get; set; }
        /// <summary>
        /// helping picture url for question
        /// </summary>
        [Index(4)]
        public string URL { get; set; }
    }
}
