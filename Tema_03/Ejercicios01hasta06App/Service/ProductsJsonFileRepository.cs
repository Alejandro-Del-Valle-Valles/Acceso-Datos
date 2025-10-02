using Ejercicios01hasta06App.Data;
using Ejercicios01hasta06App.Interfaces;
using Ejercicios01hasta06App.Model;
using System.Text.Json;

namespace Ejercicios01hasta06App.Service
{
    internal class ProductsJsonFileRepository : ICrudRepository<Product, int>
    {
        private const string FILE_NAME = "productos.json";
        private static JsonSerializerOptions OPTION_INDENT = new JsonSerializerOptions { WriteIndented = true };
        /// <summary>
        /// This method is not implemented yet and it will throw a NotImplementedException
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Add(Product product)
        {
            bool isAdded = false;
            if (Directory.Exists(StaticData.DIRECTORY_PATH))
            {
                string json = JsonSerializer.Serialize(product);
                File.AppendAllText($@"{StaticData.DIRECTORY_PATH}/{FILE_NAME}", json + Environment.NewLine);
            }
            return isAdded;
        }

        /// <summary>
        /// Serialize all products from the JSON and return a list with the products.
        /// If products were already in the list, it won't be eliminated.
        /// </summary>
        /// <returns>List of products</returns>
        public List<Product>? FindAll()
        {
            List<Product>? products = null;
            if (Directory.Exists(StaticData.DIRECTORY_PATH))
            {
                string json = File.ReadAllText($@"{StaticData.DIRECTORY_PATH}/{FILE_NAME}");
                products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            return products;
        }

        /// <summary>
        /// This method is not implemented yet and it will throw a NotImplementedException
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Product? FindById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented yet and it will throw a NotImplementedException
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Remove(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented yet and it will throw a NotImplementedException
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented yet and it will throw a NotImplementedException
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Save(Product product)
        {
            throw new NotImplementedException();
        }


        public bool SaveAll(List<Product> products)
        {
            if(!Directory.Exists(StaticData.DIRECTORY_PATH)) Directory.CreateDirectory(StaticData.DIRECTORY_PATH);
            string json = JsonSerializer.Serialize(products, OPTION_INDENT);
            File.WriteAllText(@$"{StaticData.DIRECTORY_PATH}/{FILE_NAME}", json);
            return Directory.Exists(@$"{StaticData.DIRECTORY_PATH}/{FILE_NAME}");
        }
    }
}
