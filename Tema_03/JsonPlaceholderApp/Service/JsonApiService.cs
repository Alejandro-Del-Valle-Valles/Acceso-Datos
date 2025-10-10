using JsonPlaceholderApp.Model;
using Newtonsoft.Json;

namespace JsonPlaceholderApp.Service
{
    internal static class JsonApiService
    {
        private static readonly string _path = "https://jsonplaceholder.typicode.com/posts";
        private static HttpClient _client = new();

        public static async Task<List<UserPost>?> GetUsersPost()
        {
            HttpResponseMessage response = await _client.GetAsync(_path);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            List<UserPost>? userPosts = JsonConvert.DeserializeObject<List<UserPost>>(json);

            return userPosts;
        }
    }
}
