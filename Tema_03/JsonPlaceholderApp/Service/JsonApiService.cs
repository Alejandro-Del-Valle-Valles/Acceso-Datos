using JsonPlaceholderApp.Model;
using Newtonsoft.Json;
using System.Text;

namespace JsonPlaceholderApp.Service
{
    internal static class JsonApiService
    {
        private static readonly string _path = "https://jsonplaceholder.typicode.com/posts";
        private static HttpClient _client = new();

        /// <summary>
        /// Return a list of UserPost from the API.
        /// </summary>
        /// <returns>List<UserPost> all User Post</returns>
        public static async Task<List<UserPost>?> GetUsersPost()
        {
            HttpResponseMessage response = await _client.GetAsync(_path);
            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            List<UserPost>? userPosts = JsonConvert.DeserializeObject<List<UserPost>>(json);

            return userPosts;
        }

        /// <summary>
        /// Post into the API one UserPost and shows the API response
        /// </summary>
        /// <param name="post">UserPost to post</param>
        public static async Task<HttpResponseMessage> PostUserPost(UserPost post)
        {
            string json = JsonConvert.SerializeObject(post);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_path, content);
            return response;
        }

        public static List<User>? GetUsers() => JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("../../../Files/users.json"));
        
    }
}
