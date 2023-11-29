namespace QuizBoss_API.Models
{
	public class Quiz
	{
		public Guid QuizId { get; set; }
		public Guid AuthorId { get; set; }
		public string? Title { get; set; }
        public string? Description { get; set; }
        public int SecondsLimit { get; set; }
        public int Attempts { get; set; }
        public DateTime? Created { get; set;}
		public DateTime? Updated { get; set;}
        public ICollection<Question>? Questions { get; set; }
    }
}
