namespace PersonalTable.Model.Configurations;

/// <summary>
/// Получение настроек с файла appsettings.json
/// </summary>
public class PageSettings
{
    /// <summary>
    /// Количество отображаемых записей на странице
    /// </summary>
    public int EntityCount { get; set; }
}
