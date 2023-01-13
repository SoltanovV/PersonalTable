using PersonalTable.Model.Dto;
using PersonalTable.Model.Entity;

namespace PersonalTable.Services.Interface
{
    public interface IPersonCreate
    {
        public Task<PersonDto> CreatePersonAsync(PersonDto personDto);
    }
}
