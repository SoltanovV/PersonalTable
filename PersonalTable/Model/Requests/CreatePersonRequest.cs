using PersonalTable.Model.Entity;

namespace PersonalTable.Model.Requests
{
    public class CreatePersonRequest
    {

        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// День рождения пользователя 
        /// </summary>
        public DateTime? Birthday { get; set; }

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
        public int Gender { get; set; }
    }
}
