using FirmaManager.Common;
using System.Collections.Generic;
using System;
using FimaManager.Business.Interfaces;
using FimaManager.Common.Enum;
using FirmaManager.EntityFrameworkData.Repositories.Interfaces;
using FirmaManager.EntityFrameworkData.Models;
using System.Linq;
using FimaManager.Common.Configs;

namespace FimaManager.Business
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonModelReadRepository _personModelReadRepositority;
        private readonly IPersonModelWriteRepository _personModelWriteRepositority;


        public PersonManager(IPersonModelReadRepository personModelReadRepositority, IPersonModelWriteRepository personModelWriteRepositority)
        {
            _personModelReadRepositority = personModelReadRepositority;
            _personModelWriteRepositority = personModelWriteRepositority;
        }

        public PersonManager()
        {
        }

        public List<Person> GetPersons(Person person, DieFirmaContext context)
        {
            List<TbPerson> tbPersons = _personModelReadRepositority.GetPersons(person.FirstName, person.Surname, context);
            List<Person> persons = tbPersons.Select<TbPerson, Person>(p => p).ToList();

            return persons;
        }

        public void CreatePerson(Person person, DieFirmaContext context)
        {
            ProveUidHasValue(person);

            _personModelWriteRepositority.CreatePerson(person, context);

            context.SaveChanges();
        }

        public StatusOfInteraction UpdatePerson(Person person, DieFirmaContext context)
        {
            ProveUidHasValue(person);

            _personModelWriteRepositority.UpdatePerson(person, context, out bool isPersonUpdated);

            if (!isPersonUpdated)
            {
                return StatusOfInteraction.personNotExists;
            }

            context.SaveChanges();

            return StatusOfInteraction.success;
        }

        public StatusOfInteraction DeletePerson(Person person, DieFirmaContext context)
        {
            ProveUidHasValue(person);

            _personModelWriteRepositority.DeletePerson(person.Uid.Value, context, out bool isPersonDeleted);


            if (!isPersonDeleted)
            {
                return StatusOfInteraction.personNotExists;
            }

            context.SaveChanges();

            return StatusOfInteraction.success;
        }

        public Person GetPerson(Guid guid, DieFirmaContext context)
        {
            Person person = _personModelReadRepositority.GetPerson(guid, context);

            return person ?? null;
        }

        public static void CheckConnection(string connectionString)
        {
            new DieFirmaContext(connectionString).CheckConnection();
        }

        private static void ProveUidHasValue(Person person)
        {
            if (!person.Uid.HasValue)
            {
                throw new ArgumentNullException(nameof(person.Uid));
            }
        }
    }
}