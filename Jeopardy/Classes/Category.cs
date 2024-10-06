using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy.Classes
{
	/// <summary>
	/// live game category
	/// </summary>
	public class Category
	{
		private CategoryTemplate _template;
		/// <summary>
		/// template category is built from
		/// </summary>
		public CategoryTemplate Template 
		{
			get => _template;
			private set
			{
				_template = value;
				Questions.Clear();
				Questions.AddRange(_template.Questions.Select(q => new Question(q)));
			}
		
		}
		/// <summary>
		/// if category is complete
		/// </summary>
		public bool IsComplete => Questions.All(u => u.IsComplete);
		/// <summary>
		/// live questions for category
		/// </summary>
		public List<Question> Questions { get; } = new List<Question>();

		/// <summary>
		/// basic constructor for category
		/// </summary>
		/// <param name="template"></param>
		public Category(CategoryTemplate template)
		{
			Template = template;
		}
	}
}
