using Ejercicio08App.Interfaces;
using Ejercicio08App.Model;
using Newtonsoft.Json;

namespace Ejercicio08App.Repositories
{
    internal class OrdersJsonRepository : ICrudRepository<Order, Guid>
    {
        private const string PATH = "../../../Files/pedidos.json";
        public bool Add(Order t)
        {
            throw new NotImplementedException();
        }

        public List<Order>? FindAll() => JsonConvert.DeserializeObject<HashSet<Order>>(
            File.ReadAllText(PATH)
            )?.ToList();

        public Order? FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Order t)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Order t)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll(List<Order> entities)
        {
            throw new NotImplementedException();
        }
    }
}
