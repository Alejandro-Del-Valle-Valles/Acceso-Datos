
namespace Ejercicio08App.Model
{
    internal class Client : IEquatable<Client?>
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateOnly FechaNacimiento { get; set; }

        public Client(string name, string email, DateOnly bornDate)
        {
            Nombre = name;
            Correo = email;
            FechaNacimiento = bornDate;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Client);
        }

        public bool Equals(Client? other)
        {
            return other is not null &&
                   Correo == other.Correo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Correo);
        }

        public static bool operator ==(Client? left, Client? right)
        {
            return EqualityComparer<Client>.Default.Equals(left, right);
        }

        public static bool operator !=(Client? left, Client? right)
        {
            return !(left == right);
        }
    }
}
