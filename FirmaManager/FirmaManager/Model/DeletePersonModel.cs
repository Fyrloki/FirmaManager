using FimaManager.Common.Configs;
using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Models;
using FimaManager.Common.Enum;
using FirmaManager.StaticObjects;

namespace FirmaManager.Model
{
    public class DeletePersonModel
    {
        public static StatusOfInteraction DeletePerson(Person person)
        {
            using DieFirmaContext context = new(Configurator.Connectionstring);

            return StaticObjectCollector.PersonManager.DeletePerson(person, context);
        }
    }
}