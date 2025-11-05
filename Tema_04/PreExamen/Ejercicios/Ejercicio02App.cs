using System.Text.Json;
using PreExamen.DAO;
using PreExamen.Interfaces;
using PreExamen.Modelo;
using PreExamen.Servicios;

namespace PreExamen.Ejercicios
{
    internal static class Ejercicio02App
    {
        private static readonly string PersonasPath = "../../../Files/personas.json";
        private static readonly string MascotasPath = "../../../Files/mascotas.json";
        private static readonly IGenericService<Persona, int> personasManager =
            new PersonasService(new PersonasPostgreDao());

        private static readonly IGenericService<Mascota, int> mascotasManager =
            new MascotasService(new MascotasPostgreDao());

        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public static void Start()
        {
            /*
            InsertarPersonas();
            InsertarMascotas();
            ImprimirPersonas();
            ImprimirMascotas();
            */

            ImprimirPersonasSinMascota();
        }

        private static void InsertarPersonas()
        {
            string json = File.ReadAllText(PersonasPath);
            List<Persona> personas = JsonSerializer.Deserialize<List<Persona>>(json, Options) ?? new List<Persona>();
            if (personas.Count > 0 && !personasManager.GetAll().Any())
            {
                personas.ForEach(p => Console.WriteLine(personasManager.Crear(p)
                ? "Persona creada correctamente"
                : "No se creó la persona"));
            }
        }

        private static void InsertarMascotas()
        {
            string json = File.ReadAllText(MascotasPath);
            List<Mascota> mascotas = JsonSerializer.Deserialize<List<Mascota>>(json, Options) ?? new List<Mascota>();
            if (mascotas.Count > 0 && !mascotasManager.GetAll().Any())
            {
                mascotas.ForEach(m => Console.WriteLine(mascotasManager.Crear(m)
                    ? "Mascota creada correctamente"
                    : "No se creó la mascota"));
            }
        }

        private static void ImprimirPersonas()
        {
            personasManager.GetAll().ToList().ForEach(Console.WriteLine);
        }

        private static void ImprimirMascotas()
        {
            mascotasManager.GetAll().ToList().ForEach(Console.WriteLine);
        }

        private static void ImprimirPersonasSinMascota()
        {
            personasManager.GetEspecial().ToList().ForEach(Console.WriteLine);
        }
    }
}
