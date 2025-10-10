namespace JsonPlaceholderApp.Model
{
    internal class User : IEquatable<User?>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool Equals(object? obj) => Equals(obj as User);

        public bool Equals(User? other) => other is not null &&
                   Id == other.Id;

        public override int GetHashCode() => HashCode.Combine(Id);

        public static bool operator ==(User? left, User? right) => EqualityComparer<User>.Default.Equals(left, right);

        public static bool operator !=(User? left, User? right) => !(left == right);
    }
}
