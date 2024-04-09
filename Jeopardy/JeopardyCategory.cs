using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class JeopardyCategory
    {
        /// <summary>
        /// display name of category
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// questions pertaining to this category
        /// </summary>
        public List<JeopardyQuestion> Questions { get; set; }
    }
}
