using Npgsql;

namespace EmpresaADONET.Service
{
    internal static class DBService
    {
        private static readonly string _path = "HOST=localhost;Port=5432;Database=empresa;Username=admin;Password=1234;";

        public static void CheckConecction()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_path))
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
    }
}
