using Microsoft.Extensions.Options;
using PersonalTable.Model.Configurations;

namespace PersonalTable.Services
{
    public class SearchPersonServices : ISearchPersonServices
    {
        private readonly ApplicationContext _db;
        private PageSettings _settings;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="db">Контекст базы данных</param>
        /// <param name="settings">Получение настроек из файла appsettings.json</param>
        public SearchPersonServices(ApplicationContext db, IOptions<PageSettings> settings)
        {
            _db = db;
            _settings = settings.Value;
        }
        public async Task<SearchPersonResponce> SearchPersonAsync(Person person, int pageNumber)
        {
			try
			{
                var result = new SearchPersonResponce();
                var entityCount = _settings.EntityCount;

                var skipCount = (pageNumber - 1) * entityCount;

                if (!String.IsNullOrEmpty(person.FullName) && person.Birthday == null) {
                    result.Persons = await _db.Person.Where(p => p.FullName == person.FullName)
                                                  .Skip(skipCount)
                                                  .Take(_settings.EntityCount)
                                                  .ToListAsync();

                    var pageCount = await _db.Person.Where(p => p.FullName == person.FullName)
                                                    .CountAsync();

                    if (pageCount % _settings.EntityCount == 0)
                        result.PageCount = pageCount / _settings.EntityCount;
                    else result.PageCount = pageCount / _settings.EntityCount + 1;
                }
                else if (String.IsNullOrEmpty(person.FullName) && person.Birthday != null)
                {
                    result.Persons = await _db.Person.Where(p => p.Birthday == person.Birthday)
                                              .Skip(skipCount)
                                              .Take(_settings.EntityCount)
                                              .ToListAsync();

                    var pageCount = await _db.Person.Where(p => p.Birthday == person.Birthday)
                                                    .CountAsync();

                    if (pageCount % _settings.EntityCount == 0)
                        result.PageCount = pageCount / _settings.EntityCount;
                    else result.PageCount = pageCount / _settings.EntityCount + 1;
                }
                else if (!String.IsNullOrEmpty(person.FullName) && person.Birthday != null)
                {
                    result.Persons = await _db.Person.Where(p => p.FullName == person.FullName &&
                                                         p.Birthday == person.Birthday)
                                              .Skip(skipCount)
                                              .Take(_settings.EntityCount)
                                              .ToListAsync();

                    var pageCount = await _db.Person.Where(p => p.FullName == person.FullName &&
                                                         p.Birthday == person.Birthday)
                                                    .CountAsync();

                    if (pageCount % _settings.EntityCount == 0)
                        result.PageCount = pageCount / _settings.EntityCount;
                    else result.PageCount = pageCount / _settings.EntityCount + 1;
                }  
                else
                {
                    result.Persons = await _db.Person.Skip(skipCount)
                                             .Take(_settings.EntityCount)
                                             .ToListAsync();

                    var pageCount = await _db.Person.CountAsync();

                    if (pageCount % _settings.EntityCount == 0)
                        result.PageCount = pageCount / _settings.EntityCount;
                    else result.PageCount = pageCount / _settings.EntityCount + 1;
                }



                return result;
            }
			catch (Exception)
			{
				throw;
			}
        }
    }
}
