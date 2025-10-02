using Ejercicios01hasta06App.Data;
using Ejercicios01hasta06App.Interfaces;
using Ejercicios01hasta06App.Model;
using Ejercicios01hasta06App.Service;
using System.Text.Json;

namespace Ejercicios01hasta06App.Repositorys
{
    internal class ProductsMemoryRepository : ICrudRepository<Product, int>
    {
        private List<Product>? _products;
        private const string FILE_NAME = "productos.json";
        private static ProductsJsonFileRepository pjson = new ProductsJsonFileRepository(); 

        /// <summary>
        /// Initializes the product list if it has not already been initialized.
        /// </summary>
        private void StartList()
        {
            if (_products == null) _products = new List<Product>();
        }

        /// <summary>
        /// Add one product into the list. If the list don't exist, it will create it.
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns>The productd added</returns>
        public bool Add(Product product)
        {
            StartList();
            _products?.Add(product);
            return true;
        }

        /// <summary>
        /// Serialize all products from the JSON and return a list with the products.
        /// If products were already in the list, it won't be eliminated.
        /// </summary>
        /// <returns>List of products</returns>
        public List<Product>? FindAll()
        {
            if(Directory.Exists(StaticData.DIRECTORY_PATH))
            {
                string json = File.ReadAllText($@"{StaticData.DIRECTORY_PATH}/{FILE_NAME}");
                JsonSerializer.Deserialize<List<Product>>(json)?.ForEach(p => Add(p));
            }
            return _products;
        }

        /// <summary>
        /// Return one product by his I, if not exists, it returns null
        /// </summary>
        /// <param name="id">Int id of the searched dproduct</param>
        /// <returns>Searched Product or null if not exists</returns>
        public Product? FindById(int id)
        {
            Product? product = null;
            if(_products != null) product = _products.Find(p => p.Id == id);
            
            return product;
        }

        /// <summary>
        /// Remove a product from the list
        /// </summary>
        /// <param name="product">Prododuct to be eliminated</param>
        /// <returns>Boolean, True if was eliminated, False otherwise</returns>
        public bool Remove(Product product)
        {
            bool isRemoved = false;
            if (_products != null) isRemoved = _products.Remove(product);

            return isRemoved;
        }

        /// <summary>
        /// Remove a product from the list by his ID
        /// </summary>
        /// <param name="id">Int ID of the Product to be deleted</param>
        /// <returns>Boolean, True if the Product was deleted, False otherwise</returns>
        public bool RemoveById(int id)
        {
            bool isRemoved = false;
            if (_products != null) isRemoved = _products.Remove(_products.Find(p => p.Id == id));

            return isRemoved;
        }

        /// <summary>
        /// This method is not implemented yet and it will return an Exception
        /// </summary>
        /// <param name="product">Product to be saved</param>
        /// <returns>Throws a NotImplementedException. When implemented, returns a bool, True if the product
        /// was saved, False otherwise</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Save(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented yet and it will return an Exception
        /// </summary>
        /// <param name="products">List of Products to be saved</param>
        /// <returns>Throws a NotImplementedException. When implemented, returns a bool, True if the products
        /// was saved, False otherwise</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveAll(List<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}
