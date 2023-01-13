using PersonalTable.Model.Entity;

namespace PersonalTable.Services.Interface
{
    public interface IPersonCreate
    {
        public Task<Person> CreatePersonAsync(Person person);
    }
}
