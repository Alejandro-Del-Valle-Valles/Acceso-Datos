using DistribuidorADONET.Exceptions;
using DistribuidorADONET.Interfaces;
using DistribuidorADONET.Model;
using Npgsql;
using System.Transactions;

namespace DistribuidorADONET.Service
{
    internal class ManufacturerService(IGenericDAO<Manufacturer> dbManager) : IGenericService<Manufacturer>
    {
        /// <summary>
        /// Insert into the DB the new Manufacturer.
        /// </summary>
        /// <param name="obj">Manufacturer to insert.</param>
        /// <returns>bool, true if it was inserted, false otherwise.</returns>
        public bool Create(Manufacturer obj)
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
            catch(Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
            }

            return isCreated;
        }

        /// <summary>
        /// Update a Manufacturer from the DB if exist.
        /// </summary>
        /// <param name="obj">Manufacturer to update.</param>
        /// <returns>bool, true if it was updated, false otherwise.</returns>
        public bool Update(Manufacturer obj)
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
        /// Delete a Manufacturer from the DB if exist.
        /// </summary>
        /// <param name="code">int code of the manufacturer.</param>
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
        /// Obtain one Manufacturer from the DB by his ID if exists.
        /// </summary>
        /// <param name="code">int code of the searched Manufacturer.</param>
        /// <returns>Manufacturer that can be null if not exist.</returns>
        public Manufacturer? GetByCode(int code)
        {
            Manufacturer? manufacturer = null;
            try
            {
                manufacturer = dbManager.GetByCode(code);
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine($"Uno de los atributos del fabricante es erróneo y no se pudo extraer: {ex.Message}");
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
        /// Obtain all Manufacturers from teh DB.
        /// </summary>
        /// <returns>IEnumerable with all Manufacturers. Can be empty.</returns>
        public IEnumerable<Manufacturer> GetAll()
        {
            IEnumerable<Manufacturer> articles = new List<Manufacturer>();
            try
            {
                articles = dbManager.GetAll();
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine($"Uno de los atributos del fabricante es erróneo y no se pudo extraer: {ex.Message}");
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
