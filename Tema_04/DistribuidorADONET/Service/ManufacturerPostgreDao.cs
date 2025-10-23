using DistribuidorADONET.Interfaces;
using DistribuidorADONET.Model;
using Npgsql;

namespace DistribuidorADONET.Service
{
    internal class ManufacturerPostgreDao : IGenericDAO<Manufacturer>
    {
        private const string Path = "HOST=localhost;Port=54320;Database=empresa;Username=root;Password=1234;";

        /// <summary>
        /// Insert into the DB the new Manufacturer. Can return exceptions if already exist or the name is used.
        /// </summary>
        /// <param name="obj">Manufacturer to insert</param>
        /// <returns>bool, true if is inserted, false otherwise</returns>
        public bool Insert(Manufacturer obj)
        {
            bool isInserted = false;
            string query = @"INSERT INTO fabricantes VALUES(@code, @name);";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@code", obj.Code);
                command.Parameters.AddWithValue("@name", obj.Name);
                isInserted = command.ExecuteNonQuery() > 0;
            }
            return isInserted;
        }


        /// <summary>
        /// Update a manufacturer from the DB if exist. Can throw exceptions if the name
        /// </summary>
        /// <param name="obj">Manufacturer to update</param>
        /// <returns>bool, true if it was updated, false otherwise</returns>
        public bool Update(Manufacturer obj)
        {
            bool isUpdated = false;
            string query = @"UPDATE fabricantes SET codigo = @code, nombre = @name WHERE codigo = @code);";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@code", obj.Code);
                command.Parameters.AddWithValue("@name", obj.Name);
                isUpdated = command.ExecuteNonQuery() > 0;
            }
            return isUpdated;
        }

        /// <summary>
        /// Delete a Manufacturer from the DB if exist. Can throw exceptions.
        /// </summary>
        /// <param name="code">int code of the Manufacturer to delete</param>
        /// <returns>boo, true if it was deleted, false otherwise.</returns>
        public bool Delete(int code)
        {
            bool isDeleted = false;
            string query = @"DELETE FROM fabricantes WHERE code = @code;";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@code", code);
                isDeleted = command.ExecuteNonQuery() > 0;
            }
            return isDeleted;
        }

        /// <summary>
        /// Obtain one Manufacturer from the DB by his code.
        /// </summary>
        /// <param name="code">int code</param>
        /// <returns>Manufacturer or null if not exist.</returns>
        public Manufacturer? GetByCode(int code)
        {
            Manufacturer? manufacturer = null;
            const string query = "DELETE FROM fabricantes WHERE codigo = @code;";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@code", code);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        manufacturer = new(reader.GetInt32(0), reader.GetString(1));
                    }
                }
            }
            return manufacturer;
        }

        /// <summary>
        /// Obtain all Manufacturers from the DB. Can throw exceptions.
        /// </summary>
        /// <returns>IEnumerable with all Manufacturers or empty if the DB haven't Manufacturers</returns>
        public IEnumerable<Manufacturer> GetAll()
        {
            IEnumerable<Manufacturer> manufacturers = new List<Manufacturer>();
            string query = "SELECT codigo, nombre FROM fabricantes;";
            //TODO: Implementar la obtención de todo
            return manufacturers;
        }
    }
}
