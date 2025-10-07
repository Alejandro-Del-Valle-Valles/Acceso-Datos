using Ejercicio08App.Enums;
using Ejercicio08App.Model;
using Ejercicio08App.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Text;

namespace Ejercicio08App.services
{
    internal static class OrderResumService
    {
        private static readonly string PATH = "../../../Files/resumen_pedidos.json"; //Path to generate the json of the resum of the orders
        private static readonly JsonSerializerSettings _settings = new()
        {
            Formatting = Formatting.Indented,
            DateFormatString = "dd/MM/yyyy - HH:mm", //Format of save for the day and time 
            Converters = { new StringEnumConverter() }
        };
        private static readonly JsonSerializerSettings _desserializeSetting = new()
        {
            DateFormatString = "dd/MM/yyyy - HH:mm"
        };
        private static Random rnd = new Random();
        private static ClientJsonRepository cjr = new();
        private static OrdersJsonRepository ojr = new();
        
        /// <summary>
        /// Generates a json file with the resume of all orders from the pedidos.json file
        /// </summary>
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
        /// Get the stats from the resumen_pedidos.json
        /// </summary>
        /// <returns>string with format with all stats</returns>
        public static string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("## ESTADÍSTICAS ##");
            string json = File.ReadAllText(PATH);
            var ordersResume = JsonConvert.DeserializeObject<List<OrderResume>>(json, _desserializeSetting);
            sb.AppendLine($"\t-> Numero de pedidos: {ordersResume?.Count()}");
            sb.AppendLine($"\t-> Fecha del pedido más antiguo: {ordersResume?
                .OrderBy(o => o.FechaCreacion)
                .FirstOrDefault()?.FechaCreacion}");
            sb.AppendLine($"\t-> Fecha del último pedido más reciente: {ordersResume?
                .OrderBy(o => o.FechaCreacion)
                .LastOrDefault()?.FechaCreacion}");
            sb.AppendLine($"\t-> Numero de pedidos que superan los 200€: {ordersResume?.Count(o => o.Total >= 200)}");
            sb.AppendLine($"\t-> Suma total de todos los pedios: {ordersResume?.Sum(o => o.Total)} euros");
            sb.AppendLine($"\t-> Precio medio: {ordersResume?.Sum(o => o.Total) / ordersResume?.Count()} euros");
            sb.AppendLine($"\t-> ¿Algún pedido fue en domingo?: {(ordersResume?
                .Any(o => o.FechaCreacion.DayOfWeek == DayOfWeek.Sunday) == true ? "Sí" : "No")}");
            return sb.ToString();
        }

        /// <summary>
        /// Returns a random Order Type from the Enum of Order Types
        /// </summary>
        /// <returns>EOrderType</returns>
        private static EOrderType GetOrderType() => (EOrderType)Enum.GetValues(typeof(EOrderType)).GetValue(rnd.Next(0, 3));
    }
}
