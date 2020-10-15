using AssecorApi.Data.Interfaces;
using AssecorApi.Data.Mock;
using AssecorApi.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AssecorApi.Test
{
    /// <summary>
    /// MockPersonsRepository Test
    /// </summary>
    /// 
    
    public class  MockPersonsRepositoryTest
    {


        [Fact]
        public void Test_GetPersonById()
        {

            // arrange
            var colorMock = new Mock<IColorRepository>();
            colorMock.Setup(c => c.Colors).Returns(Colors);
            var pService = new MockPersonRepository(colorMock.Object);
            int expectedId = 0; 

            // act
            var person = pService.GetPersonById(0);

            // assert
            Assert.Equal(expectedId, person.Id);
        }

        [Fact]
        public void Test_GetPersonsByColor()
        {

            // arrange
            var colorMock = new Mock<IColorRepository>();
            colorMock.Setup(c => c.Colors).Returns(Colors);
            var pService = new MockPersonRepository(colorMock.Object);
            int expectedId = 3;

            // act
            var persons = pService.GetPersonsByColor("grün");
            int totalPersonsByColor = persons.Count(); 

            // assert
            Assert.Equal(expectedId, totalPersonsByColor);
        }

        [Fact]
        public void Test_GetAllPersons()
        {

            // arrange
            var colorMock = new Mock<IColorRepository>();
            colorMock.Setup(c => c.Colors).Returns(Colors);
            var pService = new MockPersonRepository(colorMock.Object);
            int expectedPersons = 9;

            // act
            var persons = pService.GetPersons();

            // assert
            Assert.Equal(expectedPersons, persons.Count());
        }



        [Fact]
        public void Test_AddPersion()
        {
            
            // arrange

            var person = new Person() { Id = 9, Name = "Mr. New", LastName = "Mann", ColorId = 1, City = "Erlangen", ZipCode = 91402 };
            var colorMock = new Mock<IColorRepository>();
            colorMock.Setup(c => c.Colors).Returns(Colors);
            var pService = new MockPersonRepository(colorMock.Object);
            int totaLPersonAfterAdd = 10; 

            // act
            var persons = pService.AddPerson(person);
            var personsCount = persons.Count(); 

            // assert
            Assert.Equal(totaLPersonAfterAdd, personsCount);


        }

        public IEnumerable<Color> Colors
        {

            get
            {
                return new List<Color>
                {
                            new Color{ Id = 1, ColorName = "blue"},
                            new Color{ Id = 2, ColorName = "grün"},
                            new Color{ Id = 3, ColorName = "violett"},
                            new Color{ Id = 4, ColorName = "rot"},
                            new Color{ Id = 5, ColorName = "gelb"},
                            new Color{ Id = 6, ColorName = "türkis"},
                            new Color{ Id = 7, ColorName = "weiß"}
                };
            }
        }


    }
}
