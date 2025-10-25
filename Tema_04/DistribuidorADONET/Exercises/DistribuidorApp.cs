using DistribuidorADONET.Interfaces;
using DistribuidorADONET.Model;
using DistribuidorADONET.Service;
using DistribuidorADONET.DAO;

namespace DistribuidorADONET.Exercises
{
    internal static class DistribuidorApp
    {
        private static readonly IGenericService<Article>
            ArticlesDbManager = new ArticleService(new ArticlePostgreDao());
        private static readonly IGenericService<Manufacturer> ManufacturersDbManager =
            new ManufacturerService(new ManufacturerPostgreDao());

        public static void Start()
        {
            ShowManufacturers();
            Console.WriteLine();

            ShowArticles();
            Console.WriteLine();

            UpdateArticle(2);
            Console.WriteLine();

            DeleteArticle(2);
            Console.WriteLine();

            DeleteFirstManufacturerWithoutArticles();
            Console.WriteLine();

            ShowAllArticlesInRangeOfPrice();
            Console.WriteLine();
        }

        /// <summary>
        /// Print all manufacturers from the DB.
        /// </summary>
        private static void ShowManufacturers()
        {
            Console.WriteLine("Fabricantes: ");
            ManufacturersDbManager.GetAll().ToList()
                .ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Print all articles from the DB.
        /// </summary>
        private static void ShowArticles()
        {
            Console.WriteLine("Artículos: ");
            ArticlesDbManager.GetAll().ToList()
                .ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Update one article form the dab changing his name and price.
        /// </summary>
        /// <param name="code">int code of the article to update.</param>
        private static void UpdateArticle(int code)
        {
            Console.WriteLine($"Actualizando el artículo {code}");
            Article? article = ArticlesDbManager.GetByCode(code);
            bool isUpdated = false;
            if (article != null)
            {
                article.Name = "Articulo Cambiado";
                article.Price = 11.89f;
                isUpdated = ArticlesDbManager.Update(article);
            }
            Console.WriteLine(isUpdated ? "Artículo actualizado con éxito" : "No se pudo actualizar el artículo.");
        }

        /// <summary>
        /// Delete one article from the DB if exist.
        /// </summary>
        /// <param name="code">int code of the article to delete.</param>
        private static void DeleteArticle(int code)
        {
            bool isDeleted = ArticlesDbManager.Delete(code);
            Console.WriteLine(isDeleted ? "Artículo eliminado con éxito" : "No se pudo eliminar el artículo.");
        }

        /// <summary>
        /// Delete the first manufacturer from the DB that hasn't articles associated with.
        /// </summary>
        private static void DeleteFirstManufacturerWithoutArticles()
        {
            Console.WriteLine("Eliminando al primer fabricante encontrado sin artículos.");
            Dictionary<int, List<Article>> articlesByManufacturer = ArticlesDbManager.GetAll()
                .GroupBy(a => a.ManufacturerCode)
                .ToDictionary(
                    g => g.Key,
                    g => g.ToList()
                    );
            Manufacturer? firstManufacturerWithoutArticles = ManufacturersDbManager
                .GetAll().FirstOrDefault(m => !articlesByManufacturer.ContainsKey(m.Code));
            if (firstManufacturerWithoutArticles != null)
            {
                bool isDeleted = ManufacturersDbManager.Delete(firstManufacturerWithoutArticles.Code);
                Console.WriteLine(isDeleted 
                    ? $"Se ha eliminado el fabricante con código {firstManufacturerWithoutArticles.Code} porque no tenía artículos." 
                    : $"No se ha podido eliminar el fabricante con código {firstManufacturerWithoutArticles.Code} aunque no tene artículos.");
            }
            else Console.WriteLine("No existen fabricante sin artículos.");
        }

        /// <summary>
        /// Print inr oder by their price all articles from the DB that are in the range of specified price;
        /// </summary>
        /// <param name="minPrice">float limit of min price allowed included.</param>
        /// <param name="maxPrice">float limit of max price allowed included.</param>
        private static void ShowAllArticlesInRangeOfPrice(float minPrice = 50, float maxPrice = 100.10f)
        {
            Console.WriteLine($"Mostrando todos los artículos con precio entre {minPrice}€ y {maxPrice}€:");
            ArticlesDbManager.GetAll()
                .Where(a => a.Price >= minPrice && a.Price <= maxPrice)
                .OrderBy(a => a.Price)
                .ToList().ForEach(Console.WriteLine);
        }
    }
}
