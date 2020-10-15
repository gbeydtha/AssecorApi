using AssecorApi.Data.Interfaces;
using AssecorApi.Models;
using AssecorApi.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorApi.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AddDbContext _addDbContext;
        public PersonRepository(AddDbContext addDbContext )
        {
            _addDbContext = addDbContext;
        }

        public IEnumerable<Person> GetPersons() => _addDbContext.Persons.Include(c => c.Color);

        public Person GetPersonById(int Id)
        {
            return _addDbContext.Persons.Include(c => c.Color).FirstOrDefault(i => i.Id == Id);
        }


        public IEnumerable<Person> GetPersonsByColor(string colorName)
        {
            return _addDbContext.Persons.Include(c => c.Color).Where(p => p.Color.ColorName == colorName);
        }

        public IEnumerable<Person> AddPerson(Person person)
        {
            _addDbContext.Add(person);
            _addDbContext.SaveChanges();

            return _addDbContext.Persons.Include(c => c.Color);
        }




    }
}
