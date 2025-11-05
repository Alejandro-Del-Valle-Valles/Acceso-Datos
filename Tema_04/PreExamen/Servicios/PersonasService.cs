using PreExamen.Interfaces;
using PreExamen.Modelo;

namespace PreExamen.Servicios
{
    internal class PersonasService(IGenericCrud<Persona, int> dbManager) : IGenericService<Persona, int>
    {
        public bool Crear(Persona obj)
        {
            bool esCreado = false;
            try
            {
                esCreado = dbManager.Insert(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido insertar a la persona: {ex.Message}");
            }

            return esCreado;
        }

        public bool Actualizar(Persona obj)
        {
            bool esActualizado = false;
            try
            {
                esActualizado = dbManager.Update(obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido actualizar a la persona: {ex.Message}");
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
                Console.WriteLine($"Ha ocurrido un error y no se ha podido eliminar a la personas: {ex.Message}");
            }

            return esEliminado;
        }

        public Persona? GetById(int id)
        {
            Persona? persona = null;
            try
            {
                persona = dbManager.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido obtener a la persona buscada: {ex.Message}");
            }
            return persona;
        }

        public IEnumerable<Persona> GetAll()
        {
            IEnumerable<Persona> personas = new List<Persona>();
            try
            {
                personas = dbManager.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido obtener a las personas: {ex.Message}");
            }
            return personas;
        }

        public IEnumerable<Persona> GetEspecial()
        {
            IEnumerable<Persona> personasSinPerro = new List<Persona>();
            try
            {
                personasSinPerro = dbManager.GetEspecial();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error y no se ha podido obtener a las personas: {ex.Message}");
            }
            return personasSinPerro;
        }
    }
}
