using DistribuidorADONET.Exceptions;
using DistribuidorADONET.Extensions;

namespace DistribuidorADONET.Model
{
    internal class Article : IEquatable<Article>, IComparable<Article>
    {
        public static readonly int NameMaxLength = 100;
        public static readonly float PriceMaxValue = 999.99f;

        private int _code;
        private string _name;
        private float _price;
        private int _manufacturerCode;

        public int Code
        {
            get => _code;
            private init
            {
                if (value > 0) _code = value;
                else throw new InvalidValueException("El código del artículo no puede ser inferior a 1");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value.IsNotNullOrEmptyAndEqualOrLowerThan(NameMaxLength)) _name = value;
                else throw new StringToLongException($"El nombre no debe tener más de {NameMaxLength} caracteres.");
            }
        }

        public float Price
        {
            get => _price;
            set
            {
                if (value >= 0 && PriceMaxValue <= value) _price = value;
                else throw new InvalidValueException($"El precio debe estar entre 0 y {PriceMaxValue} euros.");
            }
        }

        public int ManufacturerCode
        {
            get => _manufacturerCode;
            set
            {
                if (value > 0) _manufacturerCode = value;
                else throw new InvalidValueException("El código del fabricante no puede ser inferior a 1.");
            }
        }

        /// <summary>
        /// Constructor to instance Article.
        /// </summary>
        /// <exception cref="InvalidValueException"> If the price isn't int the range or the code is lower than 1.</exception>
        /// <exception cref="StringToLongException">If the name is empty or too long.</exception>
        /// <param name="code">int</param>
        /// <param name="name">string</param>
        /// <param name="price">float</param>
        /// <param name="manufacturerCode">int Manufacturer code</param>
        public Article(int code, string name, float price, int manufacturerCode)
        {
            Code = code;
            Name = name;
            Price = price;
            ManufacturerCode = manufacturerCode;
        }

        public override string ToString()
        {
            return $"Article => Code: {Code}, Name: {Name}, Price: {Price}, Manufacturer Code: {ManufacturerCode}.";
        }

        /// <summary>
        /// Compare two Articles. First by code, then by name, then by price and then by the Manufacturer Code.
        /// If the other article is null, return 0.
        /// </summary>
        /// <param name="other">Article to compare with.</param>
        /// <returns>int or 0 if null.</returns>
        public int CompareTo(Article? other)
        {
            int? compare = Code.CompareTo(other?.Code);
            if (compare == 0) compare = String.CompareOrdinal(Name, other?.Name);
            if (compare == 0) compare = Price.CompareTo(other?.Price);
            if (compare == 0) compare = ManufacturerCode.CompareTo(other?.ManufacturerCode);
            return compare ?? 0;
        }

        /// <summary>
        /// Two Articles are equal if they have the same code.
        /// </summary>
        /// <param name="other">Article to compare.</param>
        /// <returns>bool, true if they are equal, false otherwise</returns>
        public bool Equals(Article? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return _code == other._code;
        }

        /// <summary>
        /// Two Articles are equal if they have the same code.
        /// </summary>
        /// <param name="obj">Article to compare.</param>
        /// <returns>bool, true if they are equal, false otherwise</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Article)obj);
        }
        public override int GetHashCode() => _code;
        public static bool operator ==(Article? left, Article? right) => Equals(left, right);
        public static bool operator !=(Article? left, Article? right) => !Equals(left, right);

    }
}
