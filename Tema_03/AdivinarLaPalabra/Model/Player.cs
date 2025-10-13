
namespace AdivinarLaPalabra.Model
{
    internal class Player : IEquatable<Player?>
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int Attempts { get; set; }
        public string Word { get; set; }
        public Player(string name, TimeSpan duration, int attempts, string word)
        {
            Name = name;
            Duration = duration;
            Attempts = attempts;
            Word = word;
        }

        public override string ToString() => $"Player(Name: {Name}, Duration {Duration}, Attempts: {Attempts}, Word: {Word})";
        public override bool Equals(object? obj) => Equals(obj as Player);

        public bool Equals(Player? other) => other is not null &&
                   Name == other.Name &&
                   Duration.Equals(other.Duration) &&
                   Attempts == other.Attempts &&
                   Word == other.Word;

        public override int GetHashCode() => HashCode.Combine(Name, Duration, Attempts, Word);

        public static bool operator ==(Player? left, Player? right) => EqualityComparer<Player>.Default.Equals(left, right);

        public static bool operator !=(Player? left, Player? right) => !(left == right);
    }
}
