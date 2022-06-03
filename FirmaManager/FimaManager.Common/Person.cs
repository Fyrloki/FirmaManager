using System;

namespace FirmaManager.Common
{
    public class Person
    {
        public Person(string surname, string firstName) : this(null, surname, firstName, null, null, null) { }

        public Person(Guid? uid, string surname, string firstName, string birthday, string gender, string personNumber)
        {
            Uid = uid;
            Surname = surname;
            FirstName = firstName;
            PersonNumber = personNumber;
            Gender = gender;
            Birthday = birthday;
        }

        public Guid? Uid { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string PersonNumber { get; set; }
    }
}