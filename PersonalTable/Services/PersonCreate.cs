using AutoMapper;
using Azure.Core;
using PersonalTable.Model;
using PersonalTable.Model.Dto;
using PersonalTable.Model.Entity;
using PersonalTable.Services.Interface;

namespace PersonalTable.Services
{
    public class PersonCreate : IPersonCreate
    {
        private readonly ApplicationContext _db;
        private IMapper _mapper;
        public PersonCreate(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<PersonDto> CreatePersonAsync(PersonDto personDto)
        {
            try
            {
                var person = _mapper.Map<PersonDto, Person>(personDto);
                await _db.AddAsync(person);
                await _db.SaveChangesAsync();
                return _mapper.Map<Person, PersonDto>(person);
            }
            catch
            {
                throw;
            }
        }
    }
}
