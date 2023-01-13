using PersonalTable.Model.Entity;

namespace PersonalTable.Services.Interface
{
    public interface ISearchPerson
    {
        public Task<Person> SearcPersonAsync();
    }
}
