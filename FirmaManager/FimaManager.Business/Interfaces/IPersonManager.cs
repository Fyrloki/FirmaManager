using FimaManager.Common.Enum;
using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Models;
using System;
using System.Collections.Generic;

namespace FimaManager.Business.Interfaces
{
    public interface IPersonManager
    {
        List<Person> GetPersons(Person person, DieFirmaContext context);

        void CreatePerson(Person person, DieFirmaContext context);

        StatusOfInteraction DeletePerson(Person person, DieFirmaContext context);

        StatusOfInteraction UpdatePerson(Person person, DieFirmaContext context);

        public Person GetPerson(Guid guid, DieFirmaContext context);
    }
}