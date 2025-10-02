
namespace Test_JSON.Model
{
    internal class Person : IEquatable<Person?>, IComparable<Person>
    {
        public string Name { get; set; }
        public byte Age { get; set; }

        public Person(string name, byte age)
        {
            Name = name;
            Age = age;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Person);
        }

        public override string ToString() => $"Person => Name: {Name}, Age: {Age}.";

        public bool Equals(Person? other)
        {
            return other is not null &&
                   Name == other.Name &&
                   Age == other.Age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }

        public int CompareTo(Person? other) => Age < other?.Age ? -1 : 1;
    }
}
