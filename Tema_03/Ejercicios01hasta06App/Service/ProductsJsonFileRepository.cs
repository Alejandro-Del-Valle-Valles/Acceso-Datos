using Ejercicios01hasta06App.Data;
using Ejercicios01hasta06App.Interfaces;
using Ejercicios01hasta06App.Model;
using System.Text.Json;

namespace Ejercicios01hasta06App.Service
{
    internal class ProductsJsonFileRepository : ICrudRepository<Product, int>
    {
        private const string FILE_PATH = @$"{StaticData.DIRECTORY_PATH}/productos.json";
        private static readonly JsonSerializerOptions OPTION_INDENT = new JsonSerializerOptions { WriteIndented = true };
        private static readonly JsonSerializerOptions OPTION_IGNORE_CASE = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
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
                var products = FindAll();
                if(products != null)
                {
                    if (!products.Contains(product))
                    {
                        products.Add(product);
                        string newJson = JsonSerializer.Serialize(products, OPTION_INDENT);
                        File.WriteAllText(FILE_PATH, newJson);
                        isAdded = true;
                    }
                }
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
                string json = File.ReadAllText(FILE_PATH);
                products = JsonSerializer.Deserialize<List<Product>>(json, OPTION_IGNORE_CASE);
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
        /// Remove a product from the JSON file.
        /// </summary>
        /// <param name="product">Product to be eliminated</param>
        /// <returns>Bool, True if the product was eliminated, flase otherwise</returns>
        public bool Remove(Product product)
        {
            bool isEliminated = false;
            var products = FindAll();
            if(products != null) isEliminated = products.Remove(product);
            if(isEliminated)
            {
                string newJson = JsonSerializer.Serialize(products);
                File.WriteAllText(FILE_PATH, newJson);
            }
            return isEliminated;
        }

        /// <summary>
        /// Remove a product form the JSON based on the ID of the product
        /// </summary>
        /// <param name="id">Id of the product who wants to delete</param>
        /// <returns>bool, True if was eliminated, False otherwise</returns>
        public bool RemoveById(int id)
        {
            bool isEliminated = false;
            try
            {
                var products = FindAll();
                if (products != null) isEliminated = products.Remove(products.FirstOrDefault(p => p.Id == id));
                if (isEliminated)
                {
                    string newJson = JsonSerializer.Serialize(products);
                    File.WriteAllText(FILE_PATH, newJson);
                }
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("No existe el producto con el ID.");
            }
            catch
            {
                Console.WriteLine("Ha ocurrido un error inesperado.");
            }
            return isEliminated;
        }

        /// <summary>
        /// This method is not implemented yet and it will throw a NotImplementedException
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Save(Product product)
        {
            bool isSaved = false;
            var products = FindAll();
            if (products != null)
            {
                var searchedProduct = products.FirstOrDefault(p => p.Equals(product));
                if (searchedProduct != null && searchedProduct.Equals(product))
                {
                    products.Remove(product); //Delete the product to be changed. The product is searched by his ID.
                    products.Add(product); //Add the product with te changes.
                    string json = JsonSerializer.Serialize(products, OPTION_INDENT);
                    File.WriteAllText(FILE_PATH, json);
                    isSaved = true;
                }
            }
            return isSaved;
        }


        public bool SaveAll(List<Product> products)
        {
            if(!Directory.Exists(StaticData.DIRECTORY_PATH)) Directory.CreateDirectory(StaticData.DIRECTORY_PATH);
            string json = JsonSerializer.Serialize(products, OPTION_INDENT);
            File.WriteAllText(@$"{StaticData.DIRECTORY_PATH}/{FILE_PATH}", json);
            return Directory.Exists(@$"{StaticData.DIRECTORY_PATH}/{FILE_PATH}");
        }
    }
}
