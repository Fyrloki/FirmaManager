using FirmaManager.Common;
using FirmaManager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FirmaManager.Data
{
    public class DataManager :  IDataManager
    {
        public List<Person> GetPersons(string firstName, string surname)
        {
            List<Person> personList = new List<Person>();

            using (SqlConnection connection = new SqlConnection(FirmaManagerConfiguration.ConnectionString))
            {
                connection.Open();
                string query = "SELECT [UID], [Name], Vorname, Geburtsdatum, Geschlecht, PersonNummer FROM dbo.tb_Person WHERE [Name] LIKE @Surname AND Vorname LIKE @FirstName ORDER BY [Name], Vorname";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Surname", surname);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                using SqlDataReader reader = cmd.ExecuteReader();
                personList = GetPersonsFromReader(reader);
                connection.Close();
            }

            return personList;
        }
        
        public List<Person> GetPersonWithPersonNumber(string personNumber)
        {
            List<Person> personList = new List<Person>();

            using (SqlConnection connection = new SqlConnection(FirmaManagerConfiguration.ConnectionString))
            {
                connection.Open();
                string query = "SELECT [UID], [Name], Vorname, Geburtsdatum, Geschlecht, PersonNummer FROM dbo.tb_Person WHERE PersonNummer = @PersonNumber";
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PersonNumber", personNumber);
                using SqlDataReader reader = cmd.ExecuteReader();
                personList = GetPersonsFromReader(reader);
                connection.Close();
            }

            return personList;
        }

        public int CreatePerson(Person person)
        {
            using SqlConnection Connection = new SqlConnection(FirmaManagerConfiguration.ConnectionString);
            string query = "SET LANGUAGE German; INSERT INTO dbo.tb_Person ([UID], PersonNummer, [Name], Vorname, Geburtsdatum, Geschlecht) VALUES (NEWID(), @PersonNumber, @Surname, @FirstName, @Birthday, @Gender)";
            Connection.Open();

            SqlCommand cmd = new SqlCommand(query, Connection);

            cmd.Parameters.AddWithValue("@Surname", person.Surname);
            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd.Parameters.AddWithValue("@Birthday", person.Birthday);
            cmd.Parameters.AddWithValue("@Gender", person.Gender == "m" ? 1 : 0);
            cmd.Parameters.AddWithValue("@PersonNumber", person.PersonNumber);

            return cmd.ExecuteNonQuery();
        }

        public int DeletePerson(Guid? guid)
        {
            using SqlConnection Connection = new SqlConnection(FirmaManagerConfiguration.ConnectionString);
            string query = "DELETE FROM dbo.tb_Person WHERE [UID] = @Uid";
            Connection.Open();

            using SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@Uid", guid);

            return cmd.ExecuteNonQuery();
        }

        public int UpdatePerson(Person updatedPerson)
        {
            using SqlConnection Connection = new SqlConnection(FirmaManagerConfiguration.ConnectionString);
            string query = "UPDATE dbo.tb_Person SET [Name] = @Surname, Vorname = @NewFirstName WHERE [UID] = @Uid";
            Connection.Open();

            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Parameters.AddWithValue("@Surname", updatedPerson.Surname);
            cmd.Parameters.AddWithValue("@NewFirstName", updatedPerson.FirstName);
            cmd.Parameters.AddWithValue("@Uid", updatedPerson.Uid);

            return cmd.ExecuteNonQuery();
        }

        public void CheckConnection()
        {
            using SqlConnection connection = new SqlConnection(FirmaManagerConfiguration.ConnectionString);
            connection.Open();
        }

        public Person GetPerson(Guid guid)
        {
            using SqlConnection connection = new SqlConnection(FirmaManagerConfiguration.ConnectionString);           
            connection.Open();

            string query = "SELECT [UID], [Name], Vorname, Geburtsdatum, Geschlecht, PersonNummer FROM dbo.tb_Person WHERE [UID] = @Uid";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Uid", guid);

            using SqlDataReader reader = cmd.ExecuteReader();
            List<Person> personList= GetPersonsFromReader(reader);

            return personList.Count == 0 ? null : personList.First();
        }


        private List<Person> GetPersonsFromReader(SqlDataReader reader)
        {
            List<Person> personList = new List<Person>();

            while (reader.Read())
            {
                personList.Add(new Person((Guid)reader.GetValue(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetDateTime(3).ToString("dd.MM.yyyy"),
                    reader.GetBoolean(4) ? Constants.SHORTED_GENDER_MALE : Constants.SHORTED_GENDER_FEMALE,
                    reader.GetString(5)));
            }

            return personList;
        }
    }
}
