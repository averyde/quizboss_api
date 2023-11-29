namespace QuizBoss_API.Models
{
	public class Question
	{
        public Guid QuestionId { get; set; }
        public Guid QuizId { get; set; }
        public string? QuestionText { get; set; }
        public int Points { get; set; }
        public int CorrectOption { get; set; }

        public ICollection<Option>? Options { get; set; }
    }
}