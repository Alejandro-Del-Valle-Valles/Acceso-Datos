using Ejercicio08App.Enums;
using Ejercicio08App.Model;
using Ejercicio08App.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ejercicio08App.services
{
    internal static class OrderResumService
    {
        private static readonly string PATH = "../../../Files/resumen_pedidos.json";
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            DateFormatString = "dd/MM/yyyy - HH:mm",
            Converters = { new StringEnumConverter() }
        };
        private static Random rnd = new Random();
        private static ClientJsonRepository cjr = new();
        private static OrdersJsonRepository ojr = new();
        public static void GenerateOrdersResum()
        {
            List<OrderResume> resume = new List<OrderResume>();
            Dictionary<string, Client> clients = new Dictionary<string, Client>(); //Key email of the client

            cjr.FindAll()?.ForEach(c => clients.Add(c.Correo, c)); //Adds to the dictionary each client, this is needed to search later the client by his email in the orders
            var orders = ojr.FindAll();

            orders?.ForEach(o => resume.Add(new(
                o.Codigo,
                o.FechaHora,
                clients?[o.Cliente],
                GetOrderType(),
                o.Detalle?.MaxBy(p => p.Precio).Nombre,
                o.Detalle.Sum(p => p.Precio))
                ));
            //For each order, adds to the list of resums, a resum of the order.
            string json = JsonConvert.SerializeObject(resume, _settings);
            File.WriteAllText(PATH, json);
        }

        /// <summary>
        /// Returns a random Order Type from the Enum of Order Types
        /// </summary>
        /// <returns>EOrderType</returns>
        private static EOrderType GetOrderType() => (EOrderType)Enum.GetValues(typeof(EOrderType)).GetValue(rnd.Next(0, 3));
    }
}
