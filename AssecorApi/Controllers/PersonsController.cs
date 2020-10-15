using AssecorApi.Data.Interfaces;
using AssecorApi.Models;
using AssecorApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AssecorApi.Controllers
{

    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public PersonsController(IPersonRepository repository)
        {
            _repository = repository;
        }

      
        [HttpGet]
        [Route("persons")]
        public ActionResult<IEnumerable<PersonViewModel>> GetPersons()
        {
            var items = _repository.GetPersons().Select(p => new {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                ZipCode = p.ZipCode, 
                City = p.City,
                ColorName = p.Color.ColorName                
            });


            if (items == null)
            {
                return BadRequest();
            }
            return Ok(items); 
        }

        [HttpGet]
        [Route("persons/{id}")]
        public ActionResult<PersonViewModel> GetPersonById(int Id)
        {
            var person = _repository.GetPersonById(Id);

            var personViewModel = new PersonViewModel() {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                ZipCode = person.ZipCode,
                City = person.City,
                ColorName = person.Color.ColorName
            };

            if (personViewModel == null)
            {
                return BadRequest();
            }

            return Ok(personViewModel); 
        }

        [HttpGet]
        [Route("persons/color/{color}")]
        public ActionResult<PersonViewModel> GetPersonByColor(string color)
        {
            var persons = _repository.GetPersonsByColor(color).Select(p => new {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                ZipCode = p.ZipCode,
                City = p.City,
                ColorName = p.Color.ColorName
            }); 

            if (persons == null)
            {
                return BadRequest();
            }

            return Ok(persons);
        }

        [HttpPost]
        [Route("persons/create")]
        public ActionResult<IEnumerable<PersonViewModel>> Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            var persons = _repository.AddPerson(person).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                ZipCode = p.ZipCode,
                City = p.City,
                ColorName = p.Color.ColorName
            });



            return Ok(persons);
        }


    }
}