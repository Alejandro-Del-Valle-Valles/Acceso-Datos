using DistribuidorADONET.Interfaces;
using DistribuidorADONET.Model;
using Npgsql;
using System.Transactions;
using DistribuidorADONET.Exceptions;

namespace DistribuidorADONET.Service
{
    internal class ArticleService(IGenericDAO<Article> dbManager) : IGenericService<Article>
    {
        /// <summary>
        /// Insert into the DB the new Manufacturer.
        /// </summary>
        /// <param name="obj">Manufacturer to insert.</param>
        /// <returns>bool, true if it was inserted, false otherwise.</returns>
        public bool Create(Article obj)
        {
            bool isCreated = false;
            try
            {
                isCreated = dbManager.Insert(obj);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo acceder a la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"La operación que se está tratando de realizar no es posible: {ex.Message}");
            }
            catch (TransactionAbortedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de manejar la BBDD: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }

            return isCreated;
        }

        /// <summary>
        /// Update an Article from the DB if exist.
        /// </summary>
        /// <param name="obj">Article to update.</param>
        /// <returns>bool, true if it was updated, false otherwise.</returns>
        public bool Update(Article obj)
        {
            bool isUpdated = false;
            try
            {
                isUpdated = dbManager.Update(obj);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo acceder a la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"La operación que se está tratando de realizar no es posible: {ex.Message}");
            }
            catch (TransactionAbortedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de manejar la BBDD: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }

            return isUpdated;
        }

        /// <summary>
        /// Delete a Article from the DB if exist.
        /// </summary>
        /// <param name="code">int code of the Article.</param>
        /// <returns>bool, true if it was deleted, false otherwise.</returns>
        public bool Delete(int code)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = dbManager.Delete(code);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo acceder a la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"La operación que se está tratando de realizar no es posible: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de manejar la BBDD: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }

            return isDeleted;
        }

        /// <summary>
        /// Obtain one Article from the DB by his ID if exists.
        /// </summary>
        /// <param name="code">int code of the searched Article.</param>
        /// <returns>Article that can be null if not exist.</returns>
        public Article? GetByCode(int code)
        {
            Article? manufacturer = null;
            try
            {
                manufacturer = dbManager.GetByCode(code);
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine($"Uno de los atributos del artículo es erróneo y no se pudo extraer: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo acceder a la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"La operación que se está tratando de realizar no es posible: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de manejar la BBDD: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }

            return manufacturer;
        }

        /// <summary>
        /// Obtain all Articles from teh DB.
        /// </summary>
        /// <returns>IEnumerable with all Articles. Can be empty.</returns>
        public IEnumerable<Article> GetAll()
        {
            IEnumerable<Article> articles = new List<Article>();
            try
            {
                articles = dbManager.GetAll();
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine($"Uno de los atributos de un artículo es erróneo y no se pudo extraer: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"No se pudo acceder a la BBDD: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"La operación que se está tratando de realizar no es posible: {ex.Message}");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de manejar la BBDD: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }

            return articles;
        }
    }
}
