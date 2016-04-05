using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETPatterns.Chap7.Concurrency.Model
{
    public class PersonRepository : IPersonRepository
    {
        private string _connectionString;
        private string _findByIdSQL = "SELECT * FROM People WHERE PersonId = @PersonId";
        private string _insertSQL = "INSERT People VALUES (@FirstName, @LastName, @PersonId, @Version)";
        private string _updateSQL = "UPDATE People SET FirstName = @FirstName, LastName = @LastName, Version = @Version + 1 WHERE PersonId = @PersonId AND Version = @Version";

        public PersonRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void Add(Person person)
        {
            // Add person
        }

        public Person FindBy(Guid id)
        {
            // Find person
            return null;
        }

        public void Save(Person person)
        {
            int numberOfRecordsAffected = 0;
            using (SqlConnection connection = new SqlConnection(this._connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = _updateSQL;

                // Insert params.......

                connection.Open();
                numberOfRecordsAffected = command.ExecuteNonQuery();
            }

            if (numberOfRecordsAffected == 0)
                throw new ApplicationException("No changed make because another process updating");
            else
                person.Version++;
        }
    }
}
