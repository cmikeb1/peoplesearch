using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PeopleSearch.Repositories;
using PeopleSearch.Services;
using PeopleSearch.Models;

namespace PeopleSearch.Tests.Services
{
    [TestClass]
    public class PeopleImportServiceTest
    {
        [TestMethod]
        public void ImportPeople()
        {
            // Arrange
            var randomPeopleRepoMock = new Mock<IRandomPeopleRepository>();
            List<RandomPerson> randomPeople = new List<RandomPerson>();
            randomPeople.Add(GenerateRandomPerson());
            randomPeople.Add(GenerateRandomPerson());
            randomPeopleRepoMock.Setup(r => r.FetchRandomPeople(It.IsAny<int>())).Returns(randomPeople);

            var peopleRepoMock = new Mock<IPeopleRepository>();
            peopleRepoMock.Setup(r => r.Add(It.IsAny<List<Person>>())).Returns<List<Person>>(p => p);

            PeopleImportService peopleImportService = new PeopleImportService(peopleRepoMock.Object, randomPeopleRepoMock.Object);

            // Act
            List<Person> people = peopleImportService.ImportPeople(1);

            // Assert
            people[0].NameFirst.Equals(randomPeople[0].name.first);
        }


        private RandomPerson GenerateRandomPerson()
        {
            RandomPerson randomPerson = new RandomPerson();

            Name name = new Name();
            name.first = "first";
            name.last = "last";
            name.title = "title";
            randomPerson.name = name;

            Location location = new Location();
            location.street = "street";
            location.city = "city";
            location.postcode = "postcode";
            location.state = "state";
            randomPerson.location = location;

            randomPerson.phone = "phone";

            Login login = new Login();
            login.username = "username";
            randomPerson.login = login;

            Picture picture = new Picture();
            picture.large = "large";
            picture.medium = "medium";
            picture.thumbnail = "thumbnail";
            randomPerson.picture = picture;

            return randomPerson;
        }
    }
}
