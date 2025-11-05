using Npgsql;
using PreExamen.Interfaces;
using PreExamen.Modelo;

namespace PreExamen.DAO
{
    internal class PersonasPostgreDao : IGenericCrud<Persona, int>
    {
        private const string Path = "HOST=localhost;Port=54320;Database=examen;Username=root;Password=1234;";
        public bool Insert(Persona obj)
        {
            bool esInsertado = false;
            string query = "INSERT INTO personas VALUES (@id, @nombre, @email, @fecha)";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", obj.Id);
                command.Parameters.AddWithValue("@nombre", obj.Nombre);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@fecha", obj.FechaNacimiento);
                esInsertado = command.ExecuteNonQuery() > 0;
            }
            return esInsertado;
        }

        public bool Update(Persona obj)
        {
            bool esActualizado = false;
            string query = "UPDATE personas SET id = @id, nombre = @nombre, email = @email, fecha_nacimiento = @fecha WHERE id = @id";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", obj.Id);
                command.Parameters.AddWithValue("@nombre", obj.Nombre);
                command.Parameters.AddWithValue("@email", obj.Email);
                command.Parameters.AddWithValue("@fecha", obj.FechaNacimiento);
                esActualizado = command.ExecuteNonQuery() > 0;
            }
            return esActualizado;
        }

        public bool Delete(int id)
        {
            bool esEliminado = false;
            string query = "DELETE FROM personas WHERE id = @id";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                esEliminado = command.ExecuteNonQuery() > 0;
            }
            return esEliminado;
        }

        public Persona? GetById(int id)
        {
            Persona? persona = null;
            string query = "SELECT id, nombre, email, fecha_nacimiento FROM personas WHERE id = @id";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        persona = new(reader.GetInt32(0), reader.GetString(1), 
                            reader.GetString(2), reader.GetDateTime(3));
                    }
                }
            }
            return persona;
        }

        public IEnumerable<Persona> GetAll()
        {
            IList<Persona> personas = new List<Persona>();
            string query = "SELECT id, nombre, email, fecha_nacimiento FROM personas";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personas.Add(new(reader.GetInt32(0), reader.GetString(1),
                            reader.GetString(2), reader.GetDateTime(3)));
                    }
                }
            }
            return personas;
        }

        public IEnumerable<Persona> GetEspecial()
        {
            IList<Persona> personasSinPerro = new List<Persona>();
            string query = @"
SELECT p.id, p.nombre, p.email, p.fecha_nacimiento
FROM personas p
LEFT JOIN mascotas m ON p.id = m.persona
WHERE m.id IS NULL;";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personasSinPerro.Add(new(reader.GetInt32(0), reader.GetString(1),
                            reader.GetString(2), reader.GetDateTime(3)));
                    }
                }
            }
            return personasSinPerro;
        }
    }
}
