using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

using M01_First_WPF_Proj;

public class DataAccess
{
    const string dbname = "people";
    public void AddPerson(ViewModel model)
    {
        
        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";

        string query = "INSERT INTO [dbo].[person] (first_name, last_name, address, hair, eyes, nose, mouth) " +
                           "VALUES (@firstName, @lastName, @address, @hair, @eyes, @nose, @mouth)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@firstName", model.fName);
                command.Parameters.AddWithValue("@lastName", model.lName);
                command.Parameters.AddWithValue("@address", model.address);
                command.Parameters.AddWithValue("@hair", model.hair);
                command.Parameters.AddWithValue("@eyes", model.eyes);
                command.Parameters.AddWithValue("@nose", model.nose);
                command.Parameters.AddWithValue("@mouth", model.mouth);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
    public List<Person> GetAllPeople()
    {
        List<Person> people = new List<Person>();

        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";

        string query = "SELECT person_id, first_name, last_name, address, hair, eyes, nose, mouth FROM [dbo].[person]";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {

                            people.Add(readPerson(reader));
                    }
                }
            }
        }

        return people;
    }

    private Person readPerson(SqlDataReader reader) {

            Person person = new Person
            {
                PersonId = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Address = reader.GetString(3),
                Hair = reader.GetString(4), 
                Eyes = reader.GetString(5),
                Nose = reader.GetString(6), 
                Mouth = reader.GetString(7) 
            };
             return person;
        }

    public Person GetPerson(int id)
    {
        Person person = new Person();

        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";

        string query = $"SELECT person_id, first_name, last_name, address, hair, eyes, nose, mouth FROM [dbo].[person] where  id={id}";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        person = readPerson(reader);
                        break;
                    }
                }
            }
        }

        return person;
    }
    public void DeletePerson(int id)
    {
        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";

        string query = $"DELETE FROM [dbo].[person] WHERE person_id = @personId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@personId", id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }

    public void UpdatePerson(Person person)
    {
        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";

        string query = "UPDATE [dbo].[person] SET " +
                       "first_name = @firstName, " +
                       "last_name = @lastName, " +
                       "address = @address, " +
                       "hair = @hair, " +
                       "eyes = @eyes, " +
                       "nose = @nose, " +
                       "mouth = @mouth " +
                       "WHERE person_id = @personId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@personId", person.PersonId);
                command.Parameters.AddWithValue("@firstName", person.FirstName);
                command.Parameters.AddWithValue("@lastName", person.LastName);
                command.Parameters.AddWithValue("@address", person.Address);
                command.Parameters.AddWithValue("@hair", person.Hair);
                command.Parameters.AddWithValue("@eyes", person.Eyes);
                command.Parameters.AddWithValue("@nose", person.Nose);
                command.Parameters.AddWithValue("@mouth", person.Mouth);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}


