using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class JeopardyQuestion
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
        /// <summary>
        /// whether or not the question has been opened
        /// </summary>
        [Ignore]
        public bool HasOpened { get; set; }
    }
}
