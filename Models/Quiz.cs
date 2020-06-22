using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizbaseBrowser.Models
{
    [Table("abcd")]
    public class Quiz : ReactiveObject
    {
        /// <summary>
        /// Числовой идентификатор вопроса.
        /// </summary>
        [Key]
        [Reactive]
        public int Id { get; set; }

        /// <summary>
        /// Тема вопроса
        /// </summary>
        [Reactive]
        public string Theme { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        [Reactive]
        public string Question { get; set; }

        /// <summary>
        /// Вариант A
        /// </summary>
        [Reactive]
        public string A { get; set; }

        /// <summary>
        /// Вариант B
        /// </summary>
        [Reactive]
        public string B { get; set; }

        /// <summary>
        /// Вариант C
        /// </summary>
        [Reactive]
        public string C { get; set; }

        /// <summary>
        /// Вариант D
        /// </summary>
        [Reactive]
        public string D { get; set; }

        /// <summary>
        /// Номер правильного ответа
        /// </summary>
        [Reactive]
        public int Correct { get; set; }

        /// <summary>
        /// Комментарий к вопросу
        /// </summary>
        [Reactive]
        public string Comment { get; set; }

        /// <summary>
        /// Уровень сложности вопроса по шкале 1-15 («Кто хочет стать миллионером?»)
        /// </summary>
        [Column("level_wwtbam")]
        [Reactive]
        public int LevelWwtbam { get; set; }

        /// <summary>
        /// Уровень сложности вопроса по шкале 1-3 («Дуэль»)
        /// </summary>
        [Column("level_duel")]
        [Reactive]
        public float LevelDuel { get; set; }

        /// <summary>
        /// Ссылка
        /// </summary>
        [Column("url_misc")]
        [Reactive]
        public string UrlMisc { get; set; }

        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        [Column("url_photo")]
        [Reactive]
        public string UrlPhoto { get; set; }

        /// <summary>
        /// Ссылка на видео
        /// </summary>
        [Column("url_video")]
        [Reactive]
        public string UrlVideo { get; set; }

        /// <summary>
        /// Отыгрыш вопроса в IRC
        /// </summary>
        [Column("check_irc")]
        [Reactive]
        public bool CheckIrc { get; set; }

        /// <summary>
        /// Отыгрыш вопроса дома
        /// </summary>
        [Column("check_home")]
        [Reactive]
        public bool CheckHome { get; set; }

        /// <summary>
        /// Отыгрыш вопроса среди друзей
        /// </summary>
        [Column("check_friends")]
        [Reactive]
        public bool CheckFriends { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        [Reactive]
        public string Note { get; set; }

        public void CopyFrom(Quiz quiz)
        {
            Id = quiz.Id;

            Theme = quiz.Theme;
            Question = quiz.Question;
            A = quiz.A;
            B = quiz.B;
            C = quiz.C;
            D = quiz.D;
            Correct = quiz.Correct;
            Comment = quiz.Comment;

            LevelWwtbam = quiz.LevelWwtbam;
            LevelDuel = quiz.LevelDuel;

            UrlMisc = quiz.UrlMisc;
            UrlPhoto = quiz.UrlPhoto;
            UrlVideo = quiz.UrlVideo;

            CheckIrc = quiz.CheckIrc;
            CheckHome = quiz.CheckHome;
            CheckFriends = quiz.CheckFriends;

            Note = quiz.Note;
        }
    }
}