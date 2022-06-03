using FimaManager.Common.Configs;
using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Models;
using FirmaManager.StaticObjects;
using System;
using System.Collections.Generic;

namespace FirmaManager.Model
{
    public class GetPersonModel
    {
        public static List<Person> GetPersonList(string lastName, string firstName)
        {
            return StaticObjectCollector.PersonManager.GetPersons(new Person(lastName, firstName), new DieFirmaContext(Configurator.Connectionstring));
        }

        public static Person GetPerson(Guid guid)
        {
            return StaticObjectCollector.PersonManager.GetPerson(guid, new DieFirmaContext(Configurator.Connectionstring));
        }
    }
}
