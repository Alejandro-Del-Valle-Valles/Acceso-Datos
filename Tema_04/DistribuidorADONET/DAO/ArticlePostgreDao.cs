using System.Transactions;
using DistribuidorADONET.Exceptions;
using DistribuidorADONET.Model;
using DistribuidorADONET.Interfaces;
using Npgsql;


namespace DistribuidorADONET.DAO
{
    internal class ArticlePostgreDao : IGenericDAO<Article>
    {
        private const string Path = "HOST=localhost;Port=54320;Database=empresa;Username=root;Password=1234;";

        /// <summary>
        /// Insert into the DB a new Article if it isn't in the DB yet. Can throw exceptions.
        /// </summary>
        /// <param name="obj">Article to insert</param>
        /// <returns>bool, True if it was inserted, false otherwise.</returns>
        public bool Insert(Article obj)
        {
            bool isInserted = false;
            string query = "INSERT INTO articulos VALUES(@codigo, @nombre, @precio, @idFabricante);";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {

                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        command.Transaction = transaction;
                        command.Parameters.AddWithValue("@codigo", obj.Code);
                        command.Parameters.AddWithValue("@nombre", obj.Name);
                        command.Parameters.AddWithValue("@precio", obj.Price);
                        command.Parameters.AddWithValue("@idFabricante", obj.ManufacturerCode);
                        isInserted = command.ExecuteNonQuery() > 0;
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new TransactionAbortedException("Se abortó la inserción del artículo.");
                    }

                }
            }
            return isInserted;
        }

        /// <summary>
        /// Update an Article for the DB if exist. Can throw exceptions.
        /// </summary>
        /// <param name="obj">Article to update.</param>
        /// <returns>bool, true if it was updated, false otherwise.</returns>
        public bool Update(Article obj)
        {
            bool isUpdated = false;
            string query = "UPDATE articulos SET codigo = @codigo, nombre = @nombre, precio = @precio, fabricante = @idFabricante;";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        command.Transaction = transaction;
                        command.Parameters.AddWithValue("@codigo", obj.Code);
                        command.Parameters.AddWithValue("@nombre", obj.Name);
                        command.Parameters.AddWithValue("@precio", obj.Price);
                        command.Parameters.AddWithValue("@idFabricante", obj.ManufacturerCode);
                        isUpdated = command.ExecuteNonQuery() > 0;
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new TransactionAbortedException("Se abortó la actualización del artículo.");
                    }
                }
            }
            return isUpdated;
        }

        /// <summary>
        /// Delete from the DB an Article if exists. Can throw exceptions.
        /// </summary>
        /// <param name="code">int code of the article to delete.</param>
        /// <returns>bool, true if it was deleted, false otherwise.</returns>
        public bool Delete(int code)
        {
            bool isDeleted = false;
            string query = "DELETE FROM articulos WHERE codigo = @codigo;";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@codigo", code);
                isDeleted = command.ExecuteNonQuery() > 0;
            }
            return isDeleted;
        }

        public Article? GetByCode(int code)
        {
            Article? article = null;
            string query = "SELECT codigo, nombre, precio, fabricante FROM articulos WHERE codigo = @codigo;";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@codigo", code);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        article = new(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetFloat(2),
                            reader.GetInt32(3)
                        );
                    }
                }
            }
            return article;
        }

        /// <summary>
        /// Obtains all articles form the DB or an empty list if there's no data.
        /// Can throw exceptions
        /// </summary>
        /// <returns>IEnumerable with articles.</returns>
        public IEnumerable<Article> GetAll()
        {
            IList<Article> articles = new List<Article>();
            string query = "SELECT codigo, nombre, precio, fabricante FROM articulos;";
            using var connection = new NpgsqlConnection(Path);
            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        articles.Add(new(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetFloat(2),
                                reader.GetInt32(3)
                            )
                            );
                    }
                }
            }
            return articles;
        }
    }
}
