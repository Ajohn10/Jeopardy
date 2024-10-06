using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy.Classes
{
	/// <summary>
	/// actual running game
	/// </summary>
	public class Game
	{
		private GameTemplate _template;
		/// <summary>
		/// template for game
		/// </summary>
		public GameTemplate Template 
		{ 
			get => _template;
			private set
			{
				_template = value;
				Categories.Clear();
				Categories.AddRange(_template.Categories.Select(u => new Category(u)));
			}
		}
		/// <summary>
		/// live categories within game
		/// </summary>
		public List<Category> Categories { get; } = new List<Category>();
		/// <summary>
		/// is game complete
		/// </summary>
		public bool IsComplete => Categories.All(c => c.IsComplete);

		/// <summary>
		/// main constructor
		/// </summary>
		/// <param name="template"></param>
		public Game(GameTemplate template)
		{
			Template = template;
		}

		/// <summary>
		/// resets internal memory of game 
		/// </summary>
		public void ResetGame()
		{
			// reset completion status
			foreach (var category in Categories)
				foreach (var question in category.Questions)
					question.IsComplete = false;
		}
	}
}
