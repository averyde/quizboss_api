namespace QuizBoss_API.Models
{
	public class Option
	{
        public Guid OptionId { get; set; }
        public Guid QuestionId { get; set; }
        public string? OptionText { get; set; }
    }
}