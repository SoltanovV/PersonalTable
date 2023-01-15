namespace PersonalTable.Services.Interface;

public interface ISearchPersonServices
{
    /// <summary>
    /// Метод для поиска в списке
    /// </summary>
    /// <param name="person">Список пользователей</param>
    /// <param name="pageNumber">Выбранная страница</param>
    /// <returns>Список найденных записей</returns>
    public Task<SearchPersonResponce> SearchPersonAsync(Person person, int pageNumber);
}
