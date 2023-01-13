using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalTable.Model;
using PersonalTable.Model.Dto;
using PersonalTable.Model.Entity;
using PersonalTable.Services.Interface;
using System.Collections;

namespace PersonalTable.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly ApplicationContext _db;
        private readonly IPersonCreate _personCreate;
        private readonly ISearchPerson _searchPerson;


        public PersonController(ApplicationContext db, 
            IPersonCreate personCreate, 
            IMapper mapper, 
            ILogger<PersonController> logger, 
            ISearchPerson searchPerson)
        {
            _db = db;
            _personCreate = personCreate;
            _logger = logger;
            _searchPerson = searchPerson;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<PersonDto>> CreatePersonAsync([FromBody] PersonDto request)
        {
            try
            {
                _logger.LogInformation("Вызов метода CreatePersonAsync");
                var result = await _personCreate.CreatePersonAsync(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost]
        [Route("search/{pageNumber}")]
        public async Task<ActionResult<Person>> SeachPerson([FromBody] PersonSearchDto searchDto, int pageNumber)
        {
            try
            {
                var result = await _searchPerson.SearchPersonAsync(pageNumber, searchDto);

                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

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
