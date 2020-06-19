using System.ComponentModel.DataAnnotations.Schema;

namespace QuizbaseBrowser.Models
{
    [Table("abcd")]
    public class Quiz
    {
        /// <summary>
        /// Числовой идентификатор вопроса.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тема вопроса
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Вариант A
        /// </summary>
        public string A { get; set; }

        /// <summary>
        /// Вариант B
        /// </summary>
        public string B { get; set; }

        /// <summary>
        /// Вариант C
        /// </summary>
        public string C { get; set; }

        /// <summary>
        /// Вариант D
        /// </summary>
        public string D { get; set; }

        /// <summary>
        /// Номер правильного ответа
        /// </summary>
        public int Correct { get; set; }

        /// <summary>
        /// Комментарий к вопросу
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Уровень сложности вопроса по шкале 1-15 («Кто хочет стать миллионером?»)
        /// </summary>
        [Column("level_wwtbam")]
        public int LevelWwtbam { get; set; }

        /// <summary>
        /// Уровень сложности вопроса по шкале 1-3 («Дуэль»)
        /// </summary>
        [Column("level_duel")]
        public float LevelDuel { get; set; }

        /// <summary>
        /// Ссылка
        /// </summary>
        [Column("url_misc")]
        public string UrlMisc { get; set; }

        /// <summary>
        /// Ссылка на изображение
        /// </summary>
        [Column("url_photo")]
        public string UrlPhoto { get; set; }

        /// <summary>
        /// Ссылка на видео
        /// </summary>
        [Column("url_video")]
        public string UrlVideo { get; set; }

        /// <summary>
        /// Отыгрыш вопроса в IRC
        /// </summary>
        [Column("check_irc")]
        public bool CheckIrc { get; set; }

        /// <summary>
        /// Отыгрыш вопроса дома
        /// </summary>
        [Column("check_home")]
        public bool CheckHome { get; set; }

        /// <summary>
        /// Отыгрыш вопроса среди друзей
        /// </summary>
        [Column("check_friends")]
        public bool CheckFriends { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string Note { get; set; }
    }
}