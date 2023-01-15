namespace PersonalTable.Services.Interface;

public interface IPersonServices
{
    /// <summary>
    /// Сервис для создание записи в БД
    /// </summary>
    /// <param name="person">Данные с клиента</param>
    /// <returns>Сзданный элемент</returns>
    public Task<Person> CreatePersonAsync(Person request);
}
