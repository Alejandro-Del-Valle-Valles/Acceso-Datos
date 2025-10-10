
namespace JsonPlaceholderApp.Model
{
    internal class UserPost : IEquatable<UserPost?>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public UserPost(int id, int userId, string title, string body)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Body = body;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as UserPost);
        }

        public bool Equals(UserPost? other)
        {
            return other is not null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public static bool operator ==(UserPost? left, UserPost? right)
        {
            return EqualityComparer<UserPost>.Default.Equals(left, right);
        }

        public static bool operator !=(UserPost? left, UserPost? right)
        {
            return !(left == right);
        }
    }
}
