using PersonalTable.Model.Entity;

namespace PersonalTable.Model
{
    public class RequestPerson
    {
        /// <summary>
        /// id пользователя
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Отчество пользователя
        /// </summary>
        public string Patronymic { get; set; } = string.Empty;

        /// <summary>
        /// День рождения пользователя 
        /// </summary>
        public DateTime Birthday { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Страна пользователя
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Город пользователя
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Гендер пользователя
        /// </summary>
        public Gender Gender { get; set; } = Gender.Indefined;
    }
}
