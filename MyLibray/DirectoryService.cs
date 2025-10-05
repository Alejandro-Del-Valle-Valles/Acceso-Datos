
namespace MyLibray
{
    public class DirectoryService
    {
        private const string FILES_DIRECTORY_PATH = @$"../../../"; //Relative Path of the main directory of the project

        public string FilesName { get; set; } //Name of the Directory that contais the files

        /// <summary>
        /// Constructor of the DirectoryService class. It has a default File Name for the directory.
        /// </summary>
        /// <param name="filesName">string name of the Directory to be created or accesed. Defalut "Files"</param>
        public DirectoryService(string filesName = "Files")
        {
            FilesName = filesName;
        }

        /// <summary>
        /// Creates the given directory on the root directory of the Project if not exists, at the same level of Program.cs
        /// </summary>
        public void CreateFilesDirectoryInProjectDirectory()
        {
            if(!Directory.Exists($"{FILES_DIRECTORY_PATH}")) Directory.CreateDirectory($@"{FILES_DIRECTORY_PATH}{FilesName}");
        }

        /// <summary>
        /// Returns the Absoluthe path of the Files Directory, if isn't created yet, it returns a "Not Created Yet" message.
        /// </summary>
        /// <returns>string path of the Files Directory, message if isn't created</returns>
        public string GetPath()
        {
            string path = "Not created yet.";
            if (Directory.Exists($"{FILES_DIRECTORY_PATH}")) path = $@"{FILES_DIRECTORY_PATH}{FilesName}";
            return path;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><see langword="true"/> if the specified object is a <see cref="DirectoryService"/>  and its <see
        /// cref="FilesName"/> property is equal to the <see cref="FilesName"/>  property of the current instance;
        /// otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj)
        {
            return obj is DirectoryService service &&
                   FilesName == service.FilesName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FilesName);
        }
    }
}
