using DistribuidorADONET.Exceptions;
using DistribuidorADONET.Extensions;

namespace DistribuidorADONET.Model
{
    internal class Manufacturer : IEquatable<Manufacturer>, IComparable<Manufacturer>
    {
        public static readonly int NameMaxLength = 100;

        private int _code;
        private string _name = "Desconocido";

        public int Code
        {
            get => _code;
            private set
            {
                if (value > 0) _code = value;
                else throw new InvalidValueException("El código de la empresa no puede ser inferior a 1");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value.IsNotNullOrEmptyAndEqualOrLowerThan(NameMaxLength)) _name = value.Trim();
                else
                    throw new StringToLongException(
                        $"El nombre del artículo no puede ser superior a {NameMaxLength} caracteres.");
            }
        }

        /// <summary>
        /// Constructor for instance Manufacturer.
        /// </summary>
        /// <exception cref="InvalidValueException">If the code is under 1.</exception>
        /// <exception cref="StringToLongException">If the string is empty or longer than the specified max length</exception>
        /// <param name="code">int code of the Manufacturer</param>
        /// <param name="name">string name of the Manufacture</param>
        public Manufacturer(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public override string ToString()
        {
            return $"Manufacturer => Code: {Code}, Name: {Name}";
        }

        /// <summary>
        /// Default compare by Code, then by Name. If the other Manufacturer is null, return 0.
        /// </summary>
        /// <param name="other">Manufacturer to compare with.</param>
        /// <returns>int, if null 0</returns>
        public int CompareTo(Manufacturer? other)
        {
            int? compare = Code.CompareTo(other?.Code);
            if (compare == 0) String.CompareOrdinal(Name, other?.Name);

            return compare ?? 0;
        }

        /// <summary>
        /// Two Manufacturers are equal if they have the same code.
        /// </summary>
        /// <param name="other">object to compare</param>
        /// <returns>bool, true if they are equal, false otherwise</returns>
        public bool Equals(Manufacturer? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return _code == other._code && _name == other._name;
        }

        /// <summary>
        /// Two Manufacturers are equal if they have the same code.
        /// </summary>
        /// <param name="obj">Manufacturer to compare</param>
        /// <returns>bool, true if they are equal, false otherwise</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Manufacturer)obj);
        }
        public override int GetHashCode() =>  HashCode.Combine(_code, _name);
        public static bool operator ==(Manufacturer? left, Manufacturer? right) => Equals(left, right);
        public static bool operator !=(Manufacturer? left, Manufacturer? right) => !Equals(left, right);
    }
}
