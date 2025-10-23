using EmpresaADONET.Interfaces;
using EmpresaADONET.Model;
using Npgsql;

namespace EmpresaADONET.Service
{
    /// <summary>
    /// Contains the methods to manage the Empresa DB.
    /// </summary>
    internal class ClientPostgreDAO : ICrudDAO<Client, int>
    {
        private static readonly string Path = "HOST=localhost;Port=54320;Database=empresa;Username=root;Password=1234;";
        /*El de clase
         * "HOST=localhost;Port:5432;Database=empresa;Username=postgres;Password=1234;";
         */



        /// <summary>
        /// Check if it can open the connection and shows a message if it can connect or the error message otherwise.
        /// </summary>
        public static void CheckConnection()
        {
            try
            {
                using (var connection = new NpgsqlConnection(Path))
                {
                    connection.Open();
                    Console.WriteLine("Se pudo conectar perfectamente a la BBDD.");
                }
            }
            catch (Exception ex)
            {
                {
                    Console.WriteLine($"No se pudo conectar a la BBDD porqué: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Delete from the DB a client.
        /// </summary>
        /// <exception cref="Exception">Can throw and exception</exception>
        /// <param name="id">int id of the client to be deleted</param>
        /// <returns>bool, true if was deleted, false otherwise</returns>
        public bool Delete(int id)
        {
            const string query = "DELETE FROM clientes WHERE id = @clientId";
            bool isDeleted = false;
            using (var connection = new NpgsqlConnection(Path))
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@clientId", id);
                int rowsAffected = command.ExecuteNonQuery();
                isDeleted = rowsAffected > 0;
            }
            return isDeleted;
        }

        /// <summary>
        /// Return a list with all clients form the DB.
        /// </summary>
        /// <exception cref="Exception">Can throw exceptions.</exception>
        /// <returns>List of clients. Can be empty</returns>
        public IEnumerable<Client> GetAll()
        {
            const string query = "SELECT id, nombre, email, fecha_alta, activo, porcentaje_descuento, puntos_fidelidad FROM clientes";
            List<Client> listOfClients = new List<Client>();
            using (var connection = new NpgsqlConnection(Path))
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listOfClients.Add(new(reader.GetInt32(0), 
                            reader.GetString(1), 
                            !reader.IsDBNull(2) ? reader.GetString(2) : "Sin correo",
                            reader.GetDateTime(3),
                            reader.GetBoolean(4), 
                            reader.GetFloat(5), 
                            reader.GetInt32(6)));
                        //Create the client and add it into the list
                    }
                }
            }
            return listOfClients;
        }

        /// <summary>
        /// Return One client form the DB.
        /// </summary>
        /// <exception cref="Exception">Can throw exceptions</exception>
        /// <param name="id">int id of the client</param>
        /// <returns>Client or null if the client doesn't exist</returns>
        public Client? GetById(int id)
        {
            const string query = "SELECT id, nombre, email, fecha_alta, activo, porcentaje_descuento, puntos_fidelidad FROM clientes " +
                "WHERE id = @clientId";
            Client? client = null;
            using (var connection = new NpgsqlConnection(Path))
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@clientId", id);
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read()) //Only can be 1 row to read.
                    {
                        client = new(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3),
                            reader.GetBoolean(4), reader.GetFloat(5), reader.GetInt32(6));
                    }
                }
            }
            return client;
        }

        /// <summary>
        /// Insert into the DB the given client.
        /// </summary>
        /// <exception cref="Exception">Can throw exceptions.</exception>
        /// <param name="clientToInsert">Client to insert</param>
        /// <returns>bool, True if it was inserted, false otherwise</returns>
        public bool Insert(Client clientToInsert)
        {
            const string query = "INSERT INTO clientes VALUES(@id, @nombre, @email, @registro, @activo, @descuento, @puntos)";
            bool isInserted = false;
            using (var connection = new NpgsqlConnection(Path))
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", clientToInsert.Id);
                command.Parameters.AddWithValue("@nombre", clientToInsert.Name);
                command.Parameters.AddWithValue("@email", clientToInsert.Email);
                command.Parameters.AddWithValue("@registro", clientToInsert.RegistrationDate);
                command.Parameters.AddWithValue("@activo", clientToInsert.IsActive);
                command.Parameters.AddWithValue("@descuento", clientToInsert.Discount);
                command.Parameters.AddWithValue("@puntos", clientToInsert.LoyaltyPoints);
                int rowsAffected = command.ExecuteNonQuery();
                isInserted = rowsAffected > 0;
            }
            return isInserted;
        }

        /// <summary>
        /// Update a client form the DB.
        /// </summary>
        /// <exception cref="Exception">Can thor exceptions</exception>
        /// <param name="client">Client to update</param>
        /// <returns>bool, True if it was updated, False otherwise.</returns>
        public bool Update(Client client) 
        {
            const string query = @"UPDATE clientes SET id = @id, nombre = @nombre, email = @email, fecha_alta = @registro,
                activo = @activo, porcentaje_descuento = @descuento, puntos_fidelidad = @puntos WHERE id = @id";
            bool isUpdated = false;
            using (var connection = new NpgsqlConnection(Path))
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", client.Id);
                command.Parameters.AddWithValue("@nombre", client.Name);
                command.Parameters.AddWithValue("@email", client.Email);
                command.Parameters.AddWithValue("@registro", client.RegistrationDate);
                command.Parameters.AddWithValue("@activo", client.IsActive);
                command.Parameters.AddWithValue("@descuento", client.Discount);
                command.Parameters.AddWithValue("@puntos", client.LoyaltyPoints);
                int rowsAffected = command.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            return isUpdated;
        }
    }
}
