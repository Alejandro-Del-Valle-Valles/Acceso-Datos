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


        }

        private static void ShowManufacturers()
        {
            Console.WriteLine("Fabricantes: ");
            ManufacturersDbManager.GetAll().ToList()
                .ForEach(Console.WriteLine);
        }

        private static void ShowArticles()
        {
            Console.WriteLine("Artículos: ");
            ArticlesDbManager.GetAll().ToList()
                .ForEach(Console.WriteLine);
        }

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

        private static void DeleteArticle(int code)
        {
            bool isDeleted = ArticlesDbManager.Delete(code);
            Console.WriteLine(isDeleted ? "Artículo eliminado con éxito" : "No se pudo eliminar el artículo.");
        }

        private static void DeleteFirstManufacturerWithoutArticles()
        {
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
                    ? $"Se ha eliminado el fabricante con código {firstManufacturerWithoutArticles.Code} porque no tenía fabricantes." 
                    : $"No se ha podido eliminar el fabricante con código {firstManufacturerWithoutArticles.Code} aunque no tene artículos.");
            }
            else Console.WriteLine("No existen fabricante sin artículos.");
        }
    }
}
