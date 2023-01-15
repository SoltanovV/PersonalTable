namespace PersonalTable.Model.Requests
{
    public class SearchPersonRequest
    {
        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// День рождения пользователя 
        /// </summary>
        public DateTime? Birthday { get; set; } = new DateTime();
    }
}
