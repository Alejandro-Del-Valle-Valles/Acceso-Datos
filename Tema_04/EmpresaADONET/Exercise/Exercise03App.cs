using Npgsql;
using EmpresaADONET.Model;
using EmpresaADONET.Service;

namespace EmpresaADONET.Exercise
{
    internal static class Exercise03App
    {
        private static readonly ClientService _clientService = new ClientService(new ClientPostgreDAO());
        public static void Start()
        {
            bool isInserted;
            CreateClients().ForEach(client =>
            {
                isInserted = _clientService.Register(client);
                if(isInserted) Console.WriteLine($"Cliente con ID: {client.Id} insertado con éxito");
            });
        }

        private static List<Client> CreateClients()
        {
            List<Client> clients =
            [
                new(1, "Alejandro", "ejemplo1@email.com", new DateTime(2006, 5, 13), true, 5, 20),
                new(2, "Miguel", "ejemplo2@email.com", new DateTime(2004, 4, 1), false, 5, 20),
                new(3, "Laura", "ejemplo3@marcosmr.edu", new DateTime(2008, 11, 21), true, 5, 20),
                new(4, "Sofía", "ejemplo4@marcosmr.edu", new DateTime(2012, 3, 30), true, 5, 20),
                new(5, "Marcos", "", new DateTime(2000, 1, 4), false, 5, 20)
            ];
            return clients;
        }
    }
}
