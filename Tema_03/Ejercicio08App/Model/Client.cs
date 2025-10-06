
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

        public override string ToString() => $"Nombre: {Nombre}, Correo: {Correo}, Fecha de Nacimiento: {FechaNacimiento}";

        public override bool Equals(object? obj) => Equals(obj as Client);
        
        public bool Equals(Client? other) => other is not null && Correo == other.Correo;
        
        public override int GetHashCode() => HashCode.Combine(Correo);

        public static bool operator ==(Client? left, Client? right) => EqualityComparer<Client>.Default.Equals(left, right);

        public static bool operator !=(Client? left, Client? right) => !(left == right);
        
    }
}
