using DynamicData;
using System.Collections.Generic;
using System.Linq;

namespace QuizbaseBrowser.Models
{
    public class Quizbase
    {
        public Quizbase()
        {
            using QuizzesContext db = new QuizzesContext("quizzes.db");
            List = new SourceList<Quiz>();
            List.AddRange(db.Quizzes.ToList());
        }

        public List<Quiz> Items { get; private set; }
        public SourceList<Quiz> List { get; private set; }
    }
}
