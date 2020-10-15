using AssecorApi.Models;
using AssecorApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssecorApi.Data.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
        Person GetPersonById(int Id);
        IEnumerable<Person> GetPersonsByColor(string colorName);
        IEnumerable<Person> AddPerson(Person person);

    }
}
