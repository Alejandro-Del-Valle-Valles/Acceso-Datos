using System.Text.Json.Serialization;
using PreExamen.Adaptadores;

namespace PreExamen.Modelo
{
    internal class Persona : IEquatable<Persona>
    {
        private static string Formato = "dd/MM/yyyy";
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        [JsonConverter(typeof(AdaptadorFechas))]
        public DateTime FechaNacimiento { get; set; }

        public Persona(int id, string nombre, string email, DateTime fechaNacimiento)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            FechaNacimiento = fechaNacimiento;
        }

        public override string ToString() => $"Persona(Id: {Id}, Nombre: {Nombre}, Email: {Email}, Fecha Nacimiento: {FechaNacimiento.ToString(Formato)})";

        public bool Equals(Persona? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Persona)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Persona? left, Persona? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Persona? left, Persona? right)
        {
            return !Equals(left, right);
        }
    }
}
