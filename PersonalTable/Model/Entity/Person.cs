using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalTable.Model.Entity;

public class Person
{
    /// <summary>
    /// id пользователя
    /// </summary>
    public int Id { get; set; }

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
    public DateTime Birthday { get; set; } = DateTime.Now;

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

/// <summary>
/// Тип гендера
/// </summary>
public enum Gender
{
    /// <summary>
    /// Не определен
    /// </summary>
    Indefined = 0, 

    /// <summary>
    /// Мужской
    /// </summary>
    Man = 1,

    /// <summary>
    /// Женский
    /// </summary>
    Woman = 2
}
