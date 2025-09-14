using System.Reflection;

namespace T01_Ejercicios_Manejo_Ficheros.Servicios
{
    internal class DirectoryService
    {
        /// <summary>
        /// Retrieves the full file path for the "enteros.txt" file located in the "Ficheros" directory  within the
        /// project's root folder.
        /// </summary>
        /// <param name="fileName">Name and extension of the file that is going to be created or opened.</param>
        /// <remarks>This method constructs the file path dynamically based on the location of the
        /// executing assembly.  If the "Ficheros" directory does not exist, it is created automatically.</remarks>
        /// <returns>The full file path to the "enteros.txt" file.</returns>
        public static string GetFilePath(string fileName)
        {
            string? mainPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string? projectPath = Directory.GetParent(mainPath)?.Parent.Parent.FullName;
            string directory = Path.Combine(projectPath, "Ficheros");
            string file = Path.Combine(directory, fileName);
            Directory.CreateDirectory(directory);

            return file;
        }
    }
}
