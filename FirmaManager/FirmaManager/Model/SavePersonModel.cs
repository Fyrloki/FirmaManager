using FimaManager.Common.Configs;
using FimaManager.Common.Enum;
using FirmaManager.Common;
using FirmaManager.EntityFrameworkData.Models;
using FirmaManager.StaticObjects;
using System;

namespace FirmaManager.Model
{
    public class SavePersonModel
    {
        public static bool IsPersonSaveSuccessful(Guid? guid, string lastName, string firstName, DateTime birthdate, string gender, string personnumber, out string message)
        {
            using DieFirmaContext context = new(Configurator.Connectionstring);

            message = null;
            Person person = new(
                guid
                ,lastName
                ,firstName
                ,birthdate.ToString(Constants.DATE_FORMAT)
                ,gender
                ,personnumber);

            if (person.Uid is null)
            {
                person.Uid = Guid.NewGuid();

                return IsPersonCreateSuccessful(person, context, out message);
            }

            return IsPersonUpdateSuccessful(person, context, out message);
        }

        private static bool IsPersonCreateSuccessful(Person person, DieFirmaContext context, out string message)
        {
            try
            {
                message = string.Empty;
                StaticObjectCollector.PersonManager.CreatePerson(person, context);

                return true;
            }
            catch(Exception ex)
            {
                message = MessageCompiler.GetTechnicalMessageFromException(ex);

                return false;
            }
        }

        private static bool IsPersonUpdateSuccessful(Person person, DieFirmaContext context, out string message)
        {
            try
            {
                message = string.Empty;

                if (StaticObjectCollector.PersonManager.UpdatePerson(person, context) == StatusOfInteraction.personNotExists)
                {
                    message = Constants.PERSON_DOES_NOT_EXISTS_ANYMORE;

                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                message = MessageCompiler.GetTechnicalMessageFromException(ex);

                return false;
            }
        }
    }
}