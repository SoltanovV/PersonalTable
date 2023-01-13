using AutoMapper;
using PersonalTable.Model;
using PersonalTable.Model.Entity;

namespace PersonalTable.Utiliteis;

public class MappingConfig 
{
    public static MapperConfiguration RegisterMaps()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<RequestPerson, Person>();
            config.CreateMap<Person, RequestPerson>();

        });
        return mapperConfig;
    }
}
