using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalTable.Model;
using PersonalTable.Model.Dto;
using PersonalTable.Model.Entity;
using PersonalTable.Services.Interface;

namespace PersonalTable.Services
{
    public class SearchPerson : ISearchPerson
    {
        private readonly ApplicationContext _db;
        private IMapper _mapper;

        public SearchPerson(ApplicationContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Person>> SearchPersonAsync(int pageNumber,PersonSearchDto personDto)
        {
			try
			{
                var skipCount = (pageNumber - 1) * 5;

                var search = await _db.Person.Where(p => p.FirstName == personDto.FirstName && 
                                                   p.LastName == personDto.LastName && 
                                                   p.Patronymic == personDto.Patronymic &&
                                                   p.Birthday == personDto.Birthday)
                                              .Skip(skipCount)
                                              .Take(5)
                                              .ToListAsync();

                return search;

            }
			catch (Exception)
			{
				throw;
			}
        }
    }
}
