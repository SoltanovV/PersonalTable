using PersonalTable.Model.Dto;

namespace PersonalTable.Services.Interface;
public interface IPersonCreate
{
    /// <summary>
    /// Сервис для создание записи в БД
    /// </summary>
    /// <param name="personDto">Данные с клиента</param>
    /// <returns>Сзданный элемент</returns>
    public Task<PersonDto> CreatePersonAsync(PersonDto personDto);
}
