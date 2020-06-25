using Microsoft.EntityFrameworkCore;

namespace QuizbaseBrowser.Model
{
    public class QuizzesContext : DbContext
    {
        readonly string _filename;

        public DbSet<Quiz> Quizzes { get; set; }

        public QuizzesContext()
            : this("quizzes.db")
        {

        }

        public QuizzesContext(string filename)
        {
            _filename = filename;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_filename}");
        }
    }
}
