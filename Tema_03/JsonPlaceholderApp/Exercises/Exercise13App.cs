using JsonPlaceholderApp.Model;
using JsonPlaceholderApp.Service;

namespace JsonPlaceholderApp.Exercises
{
    internal static class Exercise13App
    {
        public static async void Start()
        {
            List<UserPost>? posts = await JsonApiService.GetUsersPost();
            if (posts != null)
            {
                var postPerUser = new Dictionary<int, int>();
                posts.ForEach(post =>
                {
                    if (postPerUser.ContainsKey(post.UserId)) postPerUser[post.UserId]++;
                    else postPerUser[post.UserId] = 1;
                });
                posts.OrderBy(p => p.UserId);
                Console.WriteLine("## Numero de Post escritos por cada Usuario: ");
                foreach (var item in postPerUser)
                {
                    Console.WriteLine($"Usuario {item.Key}: {item.Value} post(s).");
                }
            }
            else Console.WriteLine("No se han encontrado registros");
        }
    }
}
