using FirmaManager.Common;
using FirmaManager.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FirmaManager.Validation
{
    public class PersonPropertiesValidator
    {
        public static bool IsPersonNameValid(string nameToProve)
        {
            string cleanedName = NameManipulator.GetCleanedName(nameToProve);

            return Regex.IsMatch(cleanedName, @"^[a-zA-ZäöüÄÖÜ\s-]+$")
                   && !cleanedName.Contains("--")
                   && !string.IsNullOrEmpty(cleanedName)
                   && cleanedName[0] != '-'
                   && cleanedName[^1] != '-';
        }

        internal static bool IsPersonNumberUnique(string personnumber)
        {
            return GetPersonModel
                .GetPersonList(Constants.WILDCARD, Constants.WILDCARD)
                .Where(s => s.PersonNumber == personnumber)
                .FirstOrDefault() == null;
        }
    }
}