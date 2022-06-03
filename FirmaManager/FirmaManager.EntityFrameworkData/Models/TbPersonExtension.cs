using FirmaManager.Common;
using System;

namespace FirmaManager.EntityFrameworkData.Models
{
    public partial class TbPerson
    {
        public static implicit operator Person(TbPerson tbPerson) => tbPerson is null ? null : new Person(
                tbPerson.Uid,
                tbPerson.Name,
                tbPerson.Vorname,
                tbPerson.Geburtsdatum.ToString("dd.MM.yyyy"),
                tbPerson.Geschlecht ? Constants.SHORTED_GENDER_FEMALE : Constants.SHORTED_GENDER_MALE,
                tbPerson.PersonNummer);

        public static implicit operator TbPerson(Person person) => person is null ? null : new TbPerson()
        {
            Geburtsdatum = DateTime.Parse(person.Birthday),
            Geschlecht = person.Gender == "w",
            Name = person.Surname,
            Vorname = person.FirstName,
            PersonNummer = person.PersonNumber,
            Uid = (Guid)person.Uid
        };
    }
}