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

    public void populateHobbyTable()
    {
        if (isHobbyTableData())
        {
           
        
        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";
        string insertHobbiesQuery = "INSERT INTO [dbo].[Hobby] (id, name, description) " +
            "VALUES" +
            " (@golfId, 'Golf', 'Golf is walking'), " +
            " (@cardsId, 'Cards', 'Watch out for the sharks!'), " +
            " (@sailingId, 'Sailing', 'A water-based sport or exercise') ";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using(SqlCommand command = new SqlCommand(insertHobbiesQuery, connection))
            {
                command.Parameters.AddWithValue("@golfId", IdParser.ParseHobbyIdFromString("Golf"));
                command.Parameters.AddWithValue("@cardsId", IdParser.ParseHobbyIdFromString("Cards"));
                command.Parameters.AddWithValue("@sailingId", IdParser.ParseHobbyIdFromString("Sailing"));
                command.ExecuteNonQuery();
                }
            }
        }
    }

    public void populateOccupationTable()
    {
        if (isOccupationTableData())
        {
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";
            string insertOccupationsQuery = "INSERT INTO [dbo].[Occupation] (id, name, description) " +
                "VALUES" +
                " (@dentistId, 'Dentist', 'They do tooth things'), " +
                " (@minerId, 'Miner', 'Sorry, too young to work.'), " +
                " (@circusId, 'Circus Performer', 'A daring young man with the hair on his knees') ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertOccupationsQuery, connection))
                {
                    command.Parameters.AddWithValue("@dentistId", IdParser.ParseOccupationIdFromString("Dentist"));
                    command.Parameters.AddWithValue("@minerId", IdParser.ParseOccupationIdFromString("Miner"));
                    command.Parameters.AddWithValue("@circusId", IdParser.ParseOccupationIdFromString("Circus Performer"));
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    private bool isHobbyTableData()
    {
        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";
        string checkIfTableIsPopulatedQuery = "SELECT COUNT(*) FROM [dbo].[Hobby];";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(checkIfTableIsPopulatedQuery, connection))
            {
                int rowCount = (int)command.ExecuteScalar();
                return rowCount == 0;
            }
        }
    }

    private bool isOccupationTableData()
    {
        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";
        string checkIfTableIsPopulatedQuery = "SELECT COUNT(*) FROM [dbo].[Occupation];";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(checkIfTableIsPopulatedQuery, connection))
            {
                int rowCount = (int)command.ExecuteScalar();
                return rowCount == 0;
            }
        }
    }

    public void AddPerson(ViewModel model)
    {
        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";

        
        string insertPersonQuery = "INSERT INTO [dbo].[person] (first_name, last_name, address, hair, eyes, nose, mouth, occupation) " +
                                   "VALUES (@firstName, @lastName, @address, @hair, @eyes, @nose, @mouth, @occupation); " +
                                   "SELECT SCOPE_IDENTITY();";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(insertPersonQuery, connection))
            {
                command.Parameters.AddWithValue("@firstName", model.fName);
                command.Parameters.AddWithValue("@lastName", model.lName);
                command.Parameters.AddWithValue("@address", model.address);
                command.Parameters.AddWithValue("@hair", model.hair);
                command.Parameters.AddWithValue("@eyes", model.eyes);
                command.Parameters.AddWithValue("@nose", model.nose);
                command.Parameters.AddWithValue("@mouth", model.mouth);
                command.Parameters.AddWithValue("@occupation", IdParser.ParseOccupationIdFromString(model.occupation));


                int personId = Convert.ToInt32(command.ExecuteScalar());

                if (model.hobby != null)
                {

                    string insertHobbyPersonQuery = "INSERT INTO [dbo].[hobby_person] (person_id, hobby_id) " +
                                                       "VALUES (@personId, @hobbyId)";

                    using (SqlCommand hobbyPersonCommand = new SqlCommand(insertHobbyPersonQuery, connection))
                    {
                        int hobbyId = IdParser.ParseHobbyIdFromString(model.hobby);
                        hobbyPersonCommand.Parameters.AddWithValue("@personId", personId);
                        hobbyPersonCommand.Parameters.AddWithValue("@hobbyId", hobbyId);

                        hobbyPersonCommand.ExecuteNonQuery();
                    }
                }
            }
        }
    }
    public List<Person> GetAllPeople()
    {
        List<Person> people = new List<Person>();

        string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog={dbname};Integrated Security=True;";

        string query = "SELECT p.person_id, " +
            "p.first_name, " +
            "p.last_name, " +
            "p.address, p.hair, " +
            "p.eyes, p.nose, " +
            "p.mouth, " +
            "o.name, " +
            "h.name " +
            "FROM [dbo].[person] p " +
            "LEFT JOIN [dbo].[Occupation] o " +
            "ON p.occupation = o.Id " +
            "JOIN [dbo].[hobby_person] hp ON p.person_id = hp.person_id JOIN [dbo].[Hobby] h ON hp.hobby_id = h.id;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if(reader.IsDBNull(8))
                        {
                            people.Add(readPerson(reader));
                        } else
                        {
                            string occupation = reader.GetString(8);
                            people.Add(readPerson(reader));
                        }
                            
                    }
                }
            }
        }

        return people;
    }

    private Person readPerson(SqlDataReader reader) {
        string occupation = "None";
        string hobby = "None";
        if(!reader.IsDBNull(8))
        {
            occupation = reader.GetString(8);
        }

        if (!reader.IsDBNull(9)) 
        {
            hobby = reader.GetString(9);
        }
        Person person = new Person
        {
            PersonId = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2),
            Address = reader.GetString(3),
            Hair = reader.GetString(4),
            Eyes = reader.GetString(5),
            Nose = reader.GetString(6),
            Mouth = reader.GetString(7),
            Occupation = occupation,
            Hobby = hobby,
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


