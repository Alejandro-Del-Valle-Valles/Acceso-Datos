using PreExamen.Modelo;

namespace PreExamen.Repositorio
{
    internal static class RepositorioPersonasMascotas
    {
        private static IList<Persona> personas = new List<Persona>();
        private static IList<Mascota> mascotas = new List<Mascota>();

        private static void InicializarPersonas()
        {
            personas.Add(new(1, "Alejandro", "alejandro@gmail.com", new DateTime(2006, 5, 13)));
            personas.Add(new(2, "Miguel", "miguel@gmail.com", new DateTime(2004, 4, 1)));
            personas.Add(new(3, "Sara", "sara@gmail.com", new DateTime(2012, 11, 21)));
            personas.Add(new(4, "Lucía", "lucia@gmail.com", new DateTime(2008, 2, 3)));
        }

        private static void InicializarMascotas()
        {
            mascotas.Add(new(1, "Yako", 1));
            mascotas.Add(new(2, "Doraemon"));
            mascotas.Add(new(3, "Filli", 2));
            mascotas.Add(new(4, "Bigotes"));
            mascotas.Add(new(5, "Firu", 1));
        }

        public static IList<Persona> GetPersonas()
        {
            InicializarPersonas();
            return personas;
        }

        public static IList<Mascota> GetMascotas()
        {
            InicializarMascotas();
            return mascotas;
        }
    }
}
