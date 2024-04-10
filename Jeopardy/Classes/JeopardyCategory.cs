namespace Jeopardy.Classes
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

        /// <summary>
        /// if category is complete
        /// </summary>
        public bool IsComplete => Questions?.All(u => u.HasOpened) ?? false;
    }
}
