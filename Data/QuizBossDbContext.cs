using Microsoft.EntityFrameworkCore;
using QuizBoss_API.Models;

namespace QuizBoss_API.Data
{
	public class QuizBossDbContext : DbContext
	{
		public QuizBossDbContext(DbContextOptions<QuizBossDbContext> options) : base(options) 
		{ 

		}

		public DbSet<Quiz> Quizzes { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Option> Options { get; set; }
	}
}
