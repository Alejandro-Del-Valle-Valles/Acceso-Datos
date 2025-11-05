using Npgsql;
using PreExamen.Interfaces;
using PreExamen.Modelo;

namespace PreExamen.DAO
{
    internal class MascotasPostgreDao : IGenericCrud<Mascota, int>
    {
        private const string Path = "HOST=localhost;Port=54320;Database=examen;Username=root;Password=1234;";
        public bool Insert(Mascota obj)
        {
            bool esInsertado = false;
            string query = "INSERT INTO mascotas VALUES (@id, @nombre, @persona)";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", obj.Id);
                command.Parameters.AddWithValue("@nombre", obj.Nombre);
                command.Parameters.AddWithValue("@persona", obj.Persona is null ? DBNull.Value : obj.Persona);
                esInsertado = command.ExecuteNonQuery() > 0;
            }
            return esInsertado;
        }

        public bool Update(Mascota obj)
        {
            bool esActualizado = false;
            string query = "UPDATE mascotas SET id = @id, nombre = @nombre, persona = @persona WHERE id = @id";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", obj.Id);
                command.Parameters.AddWithValue("@nombre", obj.Nombre);
                command.Parameters.AddWithValue("@persona", obj.Persona is null ? DBNull.Value : obj.Persona);
                esActualizado = command.ExecuteNonQuery() > 0;
            }
            return esActualizado;
        }

        public bool Delete(int id)
        {
            bool esEliminado = false;
            string query = "DELETE FROM mascotas WHERE id = @id";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                esEliminado = command.ExecuteNonQuery() > 0;
            }

            return esEliminado;
        }

        public Mascota? GetById(int id)
        {
            Mascota? mascota = null;
            string query = "SELECT id, nombre, persona FROM mascotas WHERE id = @id";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mascota = new(reader.GetInt32(0), reader.GetString(1),
                            reader.IsDBNull(2) ? null : reader.GetInt32(2));
                    }
                }
            }
            return mascota;
        }

        public IEnumerable<Mascota> GetAll()
        {
            IList<Mascota> mascotas = new List<Mascota>();
            string query = "SELECT id, nombre, persona FROM mascotas";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mascotas.Add(new(reader.GetInt32(0), reader.GetString(1),
                            reader.IsDBNull(2) ? null : reader.GetInt32(2)));
                    }
                }
            }
            return mascotas;
        }

        public IEnumerable<Mascota> GetEspecial()
        {
            throw new NotImplementedException();
        }
    }
}
