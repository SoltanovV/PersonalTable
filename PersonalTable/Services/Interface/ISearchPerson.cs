using PersonalTable.Model.Dto;
using PersonalTable.Model.Entity;

namespace PersonalTable.Services.Interface
{
    public interface ISearchPerson
    {
        public Task<IEnumerable<Person>> SearchPersonAsync(int pageNumber, PersonSearchDto person);
    }
}
