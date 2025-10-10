using JsonPlaceholderApp.Model;
using JsonPlaceholderApp.Service;

namespace JsonPlaceholderApp.Exercises
{
    internal static class Exercise13App
    {
        private static List<UserPost>? _posts;
        private static List<User>? _users = JsonApiService.GetUsers();
        public static async Task Start()
        {
            _posts = await JsonApiService.GetUsersPost();
            ShowCompleteStats();
        }

        /// <summary>
        /// Shows the number of post published by each user. Then shows the largest body of a post and the ID of the post, the Id of the user and the number of words.
        /// </summary>
        private static void ShowBasicStats()
        {
            if (_posts != null)
            {
                Console.WriteLine("## Número de post publicados por cada usuario:");
                _posts.GroupBy(p => p.UserId)
                    .Select(g => new //Create a dictionary of every userId (Key) with his num of post (value)
                    {
                        User = g.Key,
                        Cuantity = g.Count()
                    }).ToList()
                    .ForEach(p => Console.WriteLine($"Usuario {p.User}: {p.Cuantity} post(s)."));
                Console.WriteLine("\n## Post con el comentario más extenso:");
                UserPost largerPost = _posts.OrderByDescending(p => p.Body.Trim().Replace("\n", " ").Split(" ").Count()).FirstOrDefault()
                        ?? new UserPost(0, 0, "", "");
                Console.WriteLine($"[ID {largerPost.Id}] escrito por '{largerPost.UserId}'. Tiene un total de {largerPost.Body.Trim().Replace("\n", " ").Split(" ").Count()} palabras.");
                Console.WriteLine($"\n\"{largerPost.Body.Trim()}\"");
            }
            else Console.WriteLine("No se han encontrado registros");
        }

        /// <summary>
        /// Shows the number of post published by each user. Then shows the largest body of a post and the ID of the post, the name of the user and the number of words.
        /// </summary>
        private static void ShowCompleteStats()
        {
            if (_posts != null)
            {
                Console.WriteLine("## Número de post publicados por cada usuario:");
                _posts.GroupBy(p => p.UserId)
                    .Select(g => new //Create a dictionary of every user (Key) with his num of post (value)
                    {
                        User = g.Key,
                        Cuantity = g.Count()
                    }).ToList()
                    .ForEach(p => Console.WriteLine($"Usuario {_users?.FirstOrDefault(u => u.Id == p.User)?.Name ?? "Desconocido"}: {p.Cuantity} post(s)."));
                Console.WriteLine("\n## Post con el comentario más extenso:");
                UserPost largerPost = _posts.OrderByDescending(p => p.Body.Trim().Replace("\n", " ").Split(" ").Count()).FirstOrDefault()
                        ?? new UserPost(0, 0, "", "");
                Console.WriteLine($"[ID {largerPost.Id}] escrito por '{_users?.FirstOrDefault(u => u.Id == largerPost.UserId)?.Name ?? "Desconocido"}'. Tiene un total de {largerPost.Body.Trim().Replace("\n", " ").Split(" ").Count()} palabras.");
                Console.WriteLine($"\n\"{largerPost.Body.Trim()}\"");
            }
            else Console.WriteLine("No se han encontrado registros");
        }
    }
}
