namespace Test_JSON.Service
{
    internal static class DirectoryService
    {
        private const string DIRECTORY_PATH = "..//..//..//JSONS";
        public static string GetPath(string fileName)
        {
            if(!Directory.Exists(DIRECTORY_PATH)) Directory.CreateDirectory(DIRECTORY_PATH);
            return $"{DIRECTORY_PATH}//{fileName}";
        }

    }
}
