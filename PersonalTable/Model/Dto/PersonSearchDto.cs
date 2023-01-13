namespace PersonalTable.Model.Dto
{
    public class PersonSearchDto
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

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
        public DateTime Birthday { get; set; }

    }
}
