using FirmaManager.Common;
using System;
using System.Collections.Generic;

namespace FirmaManager.Data.Interfaces
{
    public interface IDataManager
    {
        List<Person> GetPersons(string firstName, string surname);

        List<Person> GetPersonWithPersonNumber(string personNumber);

        int CreatePerson(Person person);

        void CheckConnection();

        int DeletePerson(Guid? guid);

        int UpdatePerson(Person updatedPerson);

        Person GetPerson(Guid guid);
    }
}