using PreExamen.Interfaces;
using PreExamen.Modelo;

namespace PreExamen.Servicios
{
    internal class MascotasService(IGenericCrud<Mascota, int> dbManager) : IGenericService<Mascota, int>
    {
        public bool Crear(Mascota obj)
        {
            bool esCreado = false;
            try
            {
                esCreado = dbManager.Insert(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido insertar a la mascota: {ex.Message}");
            }

            return esCreado;
        }

        public bool Actualizar(Mascota obj)
        {
            bool esActualizado = false;
            try
            {
                esActualizado = dbManager.Update(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido actualizar a la mascota: {ex.Message}");
            }

            return esActualizado;
        }

        public bool Eliminar(int id)
        {
            bool esEliminado = false;
            try
            {
                esEliminado = dbManager.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido eliminar a la mascota: {ex.Message}");
            }

            return esEliminado;
        }

        public Mascota? GetById(int id)
        {
            Mascota? persona = null;
            try
            {
                persona = dbManager.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido obtener a la mascota buscada: {ex.Message}");
            }
            return persona;
        }

        public IEnumerable<Mascota> GetAll()
        {
            IEnumerable<Mascota> personas = new List<Mascota>();
            try
            {
                personas = dbManager.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido obtener a las mascotas: {ex.Message}");
            }
            return personas;
        }

        public IEnumerable<Mascota> GetEspecial()
        {
            throw new NotImplementedException();
        }
    }
}
