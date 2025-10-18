using EmpresaADONET.Exceptions;
using EmpresaADONET.StaticData;

namespace EmpresaADONET.Model
{
    internal class Client : IEquatable<Client?>
    {
        //ATTRIBUTES
        public int Id { get; set; }
        private string _name = "Unknown";
        public string Name
        {
            get => _name;
            set
            {
                if (value.Trim().Length <= Data.MAX_LENGTH_CLIENT_NAME) _name = value;
                else throw new StringToLongException($"El nombre no puede tener más de {Data.MAX_LENGTH_CLIENT_NAME} caracteres.");
            }
        }
        private string _email = "Unknown";
        public string Email
        {
            get => _email;
            set
            {
                if (value.Trim().Length >= Data.MAX_LENGTH_CLIENT_EMAIL) _email = value;
                else throw new StringToLongException($"El email no puede tener más de {Data.MAX_LENGTH_CLIENT_EMAIL} caracteres.");
            }
        }
        private DateOnly _registrationDate = new DateOnly();
        public DateOnly RegistrationDate
        {
            get => _registrationDate;
            set
            {
                if(value <= new DateOnly()) _registrationDate = value;
            }
        }
        public bool IsActive { get; set; }
        private float _discount = 0.0f;
        public float Discount
        {
            get => _discount;
            set
            {
                if (value >= 0 && value <= Data.MAX_CLIENT_DISCOUNT) _discount = value;
                else throw new InvalidValueException("El descuento introducido no es válido.");
            }
        }
        private int _fidelizationPoints = 0;
        public int FidelizationPoints
        {
            get => _fidelizationPoints;
            set
            {
                if (value >= 0) _fidelizationPoints = value;
                else throw new InvalidValueException("Los puntos de fidelidad no pueden ser inferiores a 0.");
            }
        }

        //CONSTRUCTOR
        public Client(int id, string name, string email, DateOnly registrationDate,
            bool isActive, float discount, int fidelizationPoints)
        {
            Id = id;
            Name = name;
            Email = email;
            RegistrationDate = registrationDate;
            IsActive = isActive;
            Discount = discount;
            FidelizationPoints = fidelizationPoints;
        }

        //METHODS
        public override string ToString()
        {
            return $"Client(Id: {Id}, Name: {Name}, Email: {Email}, Registration Date: {RegistrationDate}, Is Active: {IsActive}, " +
                $"Discount: {Discount}%, Fidelization Points: {FidelizationPoints}.)";
        }

        /// <summary>
        /// Two objects are equal if they are Clientas and have the same ID
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>bool, true if they are equal, false otherwise</returns>
        public override bool Equals(object? obj) => Equals(obj as Client);

        /// <summary>
        /// Two clients are equal if they have the same ID
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>bool, true if they are equal, false otherwise</returns>
        public bool Equals(Client? other) => other is not null &&
            Id == other.Id;

        public override int GetHashCode() => HashCode.Combine(Id);

        /// <summary>
        /// Two clients are equal if they have the same ID
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>bool, true if they are equal, false otherwise</returns>
        public static bool operator ==(Client? left, Client? right) => EqualityComparer<Client>.Default.Equals(left, right);

        /// <summary>
        /// Two clients are differents if they have different ID
        /// </summary>
        /// <param name="obj">object to compare</param>
        /// <returns>bool, true if they are equal, false otherwise</returns>
        public static bool operator !=(Client? left, Client? right) => !(left == right);
    }
}
