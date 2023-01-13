using AutoMapper;
using PersonalTable.Model.Dto;
using PersonalTable.Model.Entity;

namespace PersonalTable.Utiliteis;

public class MappingConfig 
{
    public static MapperConfiguration RegisterMaps()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<PersonDto, Person>();
            config.CreateMap<Person, PersonDto>();

        });
        return mapperConfig;
    }
}
