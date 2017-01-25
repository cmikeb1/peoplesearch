using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleSearch.Repositories;
using Moq;

namespace PeopleSearch.Tests.Repositories
{
    [TestClass]
    public class PeopleRepositoryTest
    {
        [TestMethod]
        public void Add()
        {
            // Arrange
            var dbMock = new Mock<PeopleContext>();

            var dbFactoryMock = new Mock<IPeopleContextFactory>();
            dbFactoryMock.Setup(dbFactory => dbFactory.CreatePeopleContext()).Returns(dbMock.Object);

            Person personToAdd = new Person();
            personToAdd.Id = 1;

            dbMock.Setup(db => db.People.Add(personToAdd));
            dbMock.Setup(db => db.SaveChanges());

            PeopleRepository peopleRepo = new PeopleRepository(dbFactoryMock.Object);

            // Act
            Person actualPerson = peopleRepo.Add(personToAdd);

            // Assert
            Assert.AreEqual(personToAdd, actualPerson);
            dbMock.Verify(db => db.People.Add(personToAdd), Times.Once());
        }
    }
}