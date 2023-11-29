using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using QuizBoss_API.Data;
using QuizBoss_API.Models;

namespace QuizBoss_API.Controllers
{
	[ApiController]
	public class QuizController : ControllerBase
    {
		private readonly QuizBossDbContext _context;
		private readonly ILogger<QuizController> _logger;

		public QuizController(QuizBossDbContext context, ILogger<QuizController> logger)
		{
			_context = context;
			_logger = logger;
		}

		[Route("api/quizzes")]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzesAsync()
		{
			var quizzes = await _context.Quizzes.Include(a => a.Questions).ThenInclude(a => a.Options).ToListAsync();
			return quizzes;
		}

		[Route("api/quizzes/{id}")]
		[HttpGet]
		public async Task<ActionResult<Quiz>> GetQuizAsync(Guid id)
		{
			var quiz = await _context.Quizzes.Include(a => a.Questions).ThenInclude(a => a.Options).SingleOrDefaultAsync(a => a.QuizId == id);

			if (quiz == null)
			{
				return NotFound();
			}

			return quiz;
		}

		[Route("api/quizzes/create")]
		[HttpPost]
		public async Task<ActionResult> CreateAsync(Quiz quiz)
		{
			if (quiz == null || 
				quiz.Title == "" || 
				quiz.Title == null || 
				quiz.Description == "" || 
				quiz.Description == null)
			{
				return BadRequest();
			}

			var newQuiz = new Quiz
			{
				Title = quiz.Title,
				Description = quiz.Description,
				SecondsLimit = quiz.SecondsLimit,
				Created = DateTime.UtcNow,
				Updated = DateTime.UtcNow,
			};

			await _context.Quizzes.AddAsync(newQuiz);

			foreach (var question in quiz.Questions ?? Enumerable.Empty<Question>())
			{
				question.QuizId = newQuiz.QuizId;

				await _context.Questions.AddAsync(question);

				foreach (var option in question.Options ?? Enumerable.Empty<Option>())
				{
					option.QuestionId = question.QuestionId;

					await _context.Options.AddAsync(option);
				}
			}

			await _context.SaveChangesAsync();

			return Ok();
		}
	}
}
