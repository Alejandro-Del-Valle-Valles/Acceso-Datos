using Ejercicios01hasta06App.Interfaces;
using Ejercicios01hasta06App.Model;

namespace Ejercicios01hasta06App.Repositorys
{
    internal class ProductsMemoryRepository : ICrudRepository<Product, int>
    {
        public Product Add(Product t)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindAll()
        {
            throw new NotImplementedException();
        }

        public Product FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Product t)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Product t)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll(List<Product> entities)
        {
            throw new NotImplementedException();
        }
    }
}
