using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalTable.Model;
using PersonalTable.Model.Entity;
using PersonalTable.Model.Requests;
using PersonalTable.Model.Responses;
using PersonalTable.Services.Interface;
using System.Collections;

namespace PersonalTable.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly IPersonServices _personCreate;
        private IMapper _mapper;
        private readonly ILogger<PersonController> _logger;
        private readonly ISearchPersonServices _searchPerson;


        public PersonController(ApplicationContext db, 
            IPersonServices personCreate, 
            IMapper mapper, 
            ILogger<PersonController> logger, 
            ISearchPersonServices searchPerson
            )
        {
            _db = db;
            _personCreate = personCreate;
            _mapper = mapper;
            _logger = logger;
            _searchPerson = searchPerson;
        }

        /// <summary>
        /// Создание записей в БД
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Созданный элемент</returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<CreatePersonResponce>> CreatePersonAsync([FromBody] CreatePersonRequest request)
        {
            try
            {
                _logger.LogInformation("Вызов метода CreatePersonAsync");

                var person = _mapper.Map<CreatePersonRequest, Person>(request);
                var result = await _personCreate.CreatePersonAsync(person);
                var responce = _mapper.Map<Person, CreatePersonResponce>(result);

                return Ok(responce);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
           
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="searchDto">DTO для входных данных</param>
        /// <param name="pageNumber">Номер старницы</param>
        /// <returns>Списко элементов</returns>
        [HttpPost]
        [Route("search/{pageNumber}")]
        public async Task<ActionResult<SearchPersonResponce>> SeachrPerson([FromBody] SearchPersonRequest request, int pageNumber)
        {
            try
            {
                var person = _mapper.Map<SearchPersonRequest, Person>(request);
                var result = await _searchPerson.SearchPersonAsync(person, pageNumber);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Метод для возвращения списка гендеров
        /// </summary>
        /// <returns>Список гендеров</returns>
        [HttpGet]
        [Route("genders")]
        public ActionResult<IEnumerable<Gender>> GetGender()
        {
            try
            {
                var result = Enum.GetNames<Gender>();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

    }
}
