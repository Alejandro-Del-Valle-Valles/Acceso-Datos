namespace PreExamen.Modelo
{
    internal class Mascota : IEquatable<Mascota>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Persona { get; set; }

        public Mascota(int id, string nombre, int? persona = null)
        {
            Id = id;
            Nombre = nombre;
            Persona = persona;
        }

        public override string ToString() => $"Mascota(Id: {Id}, Nombre: {Nombre}, Id Persona: {Persona})";
        public bool Equals(Mascota? other)
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
            return Equals((Mascota)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Mascota? left, Mascota? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Mascota? left, Mascota? right)
        {
            return !Equals(left, right);
        }
    }
}
