using PersonalTable.Services.Interface;

namespace PersonalTable.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly ApplicationContext _db;

        public PersonServices(ApplicationContext db)
        {
            _db = db;
        }   

        public async Task<Person> CreatePersonAsync(Person request)
        {
            try
            {
                var person = await _db.Person.AddAsync(request);
                
                await _db.SaveChangesAsync();

                return person.Entity;
            }
            catch
            {
                throw;
            }
        }
    }
}
