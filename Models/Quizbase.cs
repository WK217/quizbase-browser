using DynamicData;
using System.Linq;

namespace QuizbaseBrowser.Model
{
    public class Quizbase
    {
        public Quizbase()
        {
            List = new SourceCache<Quiz, int>(quiz => quiz.Id);
            Initialize();
        }

        public SourceCache<Quiz, int> List { get; }

        void Initialize()
        {
            using QuizzesContext db = new QuizzesContext();
            List.Clear();

            foreach (var quiz in db.Quizzes.ToList())
                List.AddOrUpdate(quiz);
        }

        public void AddOrUpdate(Quiz quiz)
        {
            using QuizzesContext db = new QuizzesContext();
            var dbQuiz = db.Quizzes.FirstOrDefault(q => q.Id == quiz.Id);

            if (dbQuiz is null)
                db.Quizzes.Add(quiz);
            else
            {
                dbQuiz.CopyFrom(quiz);
                db.Quizzes.Update(dbQuiz);
            }

            db.SaveChanges();
            Initialize();
        }

        public void Remove(Quiz quiz)
        {
            using QuizzesContext db = new QuizzesContext();
            var dbQuiz = db.Quizzes.FirstOrDefault(q => q.Id == quiz.Id);

            if (dbQuiz != null)
                db.Quizzes.Remove(dbQuiz);

            db.SaveChanges();
            Initialize();
        }
    }
}
