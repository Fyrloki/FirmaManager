using FimaManager.Business.Interfaces;
using FimaManager.Common.Enum;
using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Repositories.Interfaces;
using FirmaManager.EntityFrameworkData.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using FimaManager.Business;
using FimaManager.Common.Configs;

namespace FirmaManagerTest.Test
{
    [TestClass]
    public class PersonManagerTest
    {
        private static IPersonManager _personManager;
        private static Mock<IPersonModelReadRepository> _personModelReadRepositoryMock;
        private static Mock<IPersonModelWriteRepository> _personModelWriteRepositoryMock;
        private static Person _person;
        private static TbPerson _tbPerson;
        private static DieFirmaContext _context;

        [TestInitialize]
        public void InitializeMethod()
        {
            _person = new Person(Guid.NewGuid(), "Muster", "Peter", "02.11.2002", "m", "M1");
            _tbPerson = new TbPerson()
            {
                Geburtsdatum = DateTime.Parse(_person.Birthday),
                Geschlecht = _person.Gender == "w",
                Name = _person.Surname,
                Vorname = _person.FirstName,
                PersonNummer = _person.PersonNumber,
                Uid = (Guid)_person.Uid
            };

            _personModelReadRepositoryMock = new Mock<IPersonModelReadRepository>();
            _personModelWriteRepositoryMock = new Mock<IPersonModelWriteRepository>();
            _personManager = new PersonManager(_personModelReadRepositoryMock.Object, _personModelWriteRepositoryMock.Object);
            _context = new DieFirmaContext(@"Server =.\\MSSQLSERVER2017; Database = DieFirma; Trusted_Connection = True; Connection Timeout = 1");
        }

        [TestMethod]
        public void DeletePerson_Success()
        {
            //Arrange
            bool returnedBool = true;
            _personModelWriteRepositoryMock.Setup(x => x.DeletePerson(It.IsAny<Guid>(), It.IsAny<DieFirmaContext>(), out returnedBool));

            //Act
            StatusOfInteraction status = _personManager.DeletePerson(_person, _context);

            //Assert
            Assert.AreEqual(status, StatusOfInteraction.success);
        }

        [TestMethod]
        public void DeletePerson_PersonNotExists_Success()
        {
            //Arrange
            bool returnedBool = false;
            _personModelWriteRepositoryMock.Setup(x => x.DeletePerson(It.IsAny<Guid>(), It.IsAny<DieFirmaContext>(), out returnedBool));

            //Act
            StatusOfInteraction status = _personManager.DeletePerson(_person, _context);

            //Assert
            Assert.AreEqual(status, StatusOfInteraction.personNotExists);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeletePerson_UidNull_Fail()
        {
            //Arrange
            bool returnedBool = false;
            _personModelWriteRepositoryMock.Setup(x => x.DeletePerson(It.IsAny<Guid>(), It.IsAny<DieFirmaContext>(), out returnedBool));
            _person.Uid = null;

            //Act & Assert
            _ = _personManager.DeletePerson(_person, _context);
        }

        [TestMethod]
        public void UpdatePerson_Success()
        {
            //Arrange
            bool returnedBool = true;
            _personModelWriteRepositoryMock.Setup(x => x.UpdatePerson(It.IsAny<TbPerson>(), It.IsAny<DieFirmaContext>(), out returnedBool));

            //Act
            StatusOfInteraction status = _personManager.UpdatePerson(_person, _context);

            //Assert
            Assert.AreEqual(status, StatusOfInteraction.success);
        }

        [TestMethod]
        public void UpdatePerson_PersonNotExists_Success()
        {
            //Arrange
            bool returnedBool = false;
            _personModelWriteRepositoryMock.Setup(x => x.UpdatePerson(It.IsAny<TbPerson>(), It.IsAny<DieFirmaContext>(), out returnedBool));

            //Act
            StatusOfInteraction status = _personManager.UpdatePerson(_person, _context);

            //Assert
            Assert.AreEqual(status, StatusOfInteraction.personNotExists);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdatePerson_UidNull_Fail()
        {
            //Arrange
            bool returnedBool = false;
            _personModelWriteRepositoryMock.Setup(x => x.UpdatePerson(It.IsAny<TbPerson>(), It.IsAny<DieFirmaContext>(), out returnedBool));
            _person.Uid = null;

            //Act & Assert
            _ = _personManager.UpdatePerson(_person, _context);
        }

        [TestMethod]
        public void CreatePerson_Success()
        {
            //Act & Assert
            _personManager.CreatePerson(_person, _context);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePerson_UidNull_Fail()
        {
            //Arrange
            _person.Uid = null;

            //Act & Assert
            _personManager.CreatePerson(_person, _context);
        }

        [TestMethod]
        public void GetPerson_Success()
        {
            //Arrange
            _personModelReadRepositoryMock.Setup(e => e.GetPerson(It.IsAny<Guid>(), It.IsAny<DieFirmaContext>())).Returns(_tbPerson);

            //Act
            Person person = _personManager.GetPerson((Guid)_person.Uid, _context);

            //Assert
            Assert.AreEqual(_person.Uid, person.Uid);
        }

        [TestMethod]
        public void GetPerson_NoPersonFound_Success()
        {
            //Arrange
            _personModelReadRepositoryMock.Setup(e => e.GetPerson(It.IsAny<Guid>(), It.IsAny<DieFirmaContext>())).Returns(new TbPerson());

            //Act
            Person person = _personManager.GetPerson((Guid)_person.Uid, _context);

            //Assert
            Assert.AreEqual(default(Guid), person.Uid);
        }

        [TestMethod]
        public void GetPersons_Success()
        {
            //Arrange
            _personModelReadRepositoryMock.Setup(e => e.GetPersons(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DieFirmaContext>())).Returns(new List<TbPerson>() { _tbPerson });

            //Act
            List<Person> people = _personManager.GetPersons(_person, _context);

            //Assert
            Assert.AreEqual(people.First().Uid, _tbPerson.Uid);
        }

        [TestMethod]
        [DataRow("", "")]
        [DataRow(null, null)]
        public void GetPersons_NoPersonFound_Success(string firstName, string lastName)
        {
            //Arrange
            _personModelReadRepositoryMock.Setup(e => e.GetPersons(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DieFirmaContext>())).Returns(new List<TbPerson>());

            //Act
            List<Person> people = _personManager.GetPersons(new Person(lastName, firstName), _context);

            //Assert
            Assert.AreEqual(people.Count, 0);
        }
    }
}