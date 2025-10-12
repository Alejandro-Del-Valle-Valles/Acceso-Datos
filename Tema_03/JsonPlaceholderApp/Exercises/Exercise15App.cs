using JsonPlaceholderApp.Model;
using JsonPlaceholderApp.Service;

namespace JsonPlaceholderApp.Exercises
{
    internal static class Exercise15App
    {
        public static async Task Start()
        {
            UserPost post = new(101, 11, "Buen Servicio", "Es muy buen producto");
            var response = await JsonApiService.PostUserPost(post);
            Console.WriteLine($"Código de respuesta del servidor: {response}");
        }
    }
}
