using AutoMapper;

namespace PersonalTable.Utiliteis;
/// <summary>
/// Класс для настройки маппинга
/// </summary>
public class MappingConfig 
{
    /// <summary>
    /// Метод для сопоставления типов при маппинге
    /// </summary>
    /// <returns>Настройки маппинга</returns>
    public static MapperConfiguration RegisterMaps()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            
            config.CreateMap<CreatePersonRequest, Person>();
            config.CreateMap<Person, CreatePersonRequest>();
            config.CreateMap<CreatePersonResponce, Person>();
            config.CreateMap<Person, CreatePersonResponce>();

            config.CreateMap<SearchPersonRequest, Person>();
            config.CreateMap<Person, SearchPersonRequest>();
            config.CreateMap<SearchPersonResponce, Person>();
            config.CreateMap<Person, SearchPersonResponce>();
        });

        return mapperConfig;
    }
}
