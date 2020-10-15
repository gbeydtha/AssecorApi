using AssecorApi.Data.Interfaces;
using AssecorApi.Models;
using AssecorApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace AssecorApi.Data.Mock
{
    public class MockPersonRepository : IPersonRepository
    {
        private readonly IColorRepository _colorRepository;
        public MockPersonRepository(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository; 
        }

        public IEnumerable<Person> GetPersons()
        {

            var persons = PersonsListFromCSV();

            return persons;
        }

        // Read data from CSV file
        private List<Person> PersonsListFromCSV()
        {

            string path = Path.Combine(Path.GetDirectoryName(Directory.GetCurrentDirectory()), @"CSV\sample-input.csv");
            var persons = new List<Person>();

            try
            {
                
                var rows = File.ReadAllLines(path);

                int id = 0;
                foreach (var row in rows)
                {
                    string[] columns = row.Split(',');

                    // Read data, When Line has 4 columns
                    // Else ignore 
                    if (columns.Length == 4)
                    {

                        var person = new Person();
                        person.Id = id;

                        person.Name = columns[0].ToString();
                        person.LastName = columns[1].ToString();
                        string[] ZipCodeWithCity = columns[2].Trim().Split(' ');

                        person.ZipCode = int.Parse(ZipCodeWithCity[0].ToString());
                        person.City = ZipCodeWithCity[1].ToString();
                        person.ColorId = int.Parse(columns[3].ToString());
                        person.Color = _colorRepository.Colors.FirstOrDefault(c => c.Id == person.ColorId);

                        persons.Add(person);
                        id++;
                    }
                }
    
            }
            catch(DirectoryNotFoundException e)
            {
                e.Message.ToString();  
            }


            return persons;
        }


        public Person GetPersonById(int Id)
        {
            return GetPersons().FirstOrDefault(p => p.Id == Id); 
        }


        public IEnumerable<Person> GetPersonsByColor(string colorName)
        {
            return GetPersons().Where(p => p.Color.ColorName == colorName);
        }



        public IEnumerable<Person> AddPerson(Person person)
        {
            var people = GetPersons().ToList();

            var personObj = new Person()
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                ZipCode = person.ZipCode,
                City = person.City,
                ColorId = person.ColorId,
                Color = _colorRepository.Colors.FirstOrDefault(c => c.Id == person.ColorId)
            };

            people.Add(personObj);

            return people;

        }
    }
}



