using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy.Classes
{
	/// <summary>
	/// live game question
	/// </summary>
	public class Question
	{
		/// <summary>
		/// main template for question
		/// </summary>
		public QuestionTemplate Template { get; }
		/// <summary>
		/// whether or not the question has been completed
		/// </summary>
		public bool IsComplete { get; set; }

		public Question(QuestionTemplate template)
		{
			Template = template;
		}	
	}
}
