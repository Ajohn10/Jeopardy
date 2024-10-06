namespace Jeopardy.Classes
{
    public class CategoryTemplate
    {
        /// <summary>
        /// display name of category
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// questions pertaining to this category
        /// </summary>
        public List<QuestionTemplate> Questions { get; set; }
    }
}
