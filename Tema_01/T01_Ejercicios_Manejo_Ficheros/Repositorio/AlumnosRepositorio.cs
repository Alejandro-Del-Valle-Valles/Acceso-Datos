using T01_Ejercicios_Manejo_Ficheros.Enums;
using T01_Ejercicios_Manejo_Ficheros.Modelo;
using System.Globalization;

namespace T01_Ejercicios_Manejo_Ficheros.Repositorio
{
    public class AlumnosRepositorio
    {

        /// <summary>
        /// Reads a file containing student data and returns a list of students.
        /// </summary>
        /// <remarks>Each line in the file is expected to represent a single student. The method attempts
        /// to create an <see cref="Alumno"/> object for each line. Invalid or malformed lines are skipped without
        /// adding to the returned list.</remarks>
        /// <param name="filePath">The path to the file containing student data. The file must exist and be accessible.</param>
        /// <returns>A set of <see cref="Alumno"/> objects created from the file's contents. Returns an empty list if the file
        /// is empty or no valid students are found.</returns>
        public static HashSet<Alumno> GetAlumnos(string filePath)
        {
            HashSet<Alumno> alumnosList = new HashSet<Alumno>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string? line = sr.ReadLine();
                    Alumno? newAlumno = null;
                    while (line != null)
                    {
                        newAlumno = CreateAlumno(line);
                        if(newAlumno != null) alumnosList.Add(newAlumno);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El fichero con ruta {filePath} no se ha encontrado. Compruebe que la ruta es la correcta");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return alumnosList;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Alumno"/> class from a tab-delimited string of data.
        /// </summary>
        /// <remarks>This method attempts to parse the input string and create an <see cref="Alumno"/>
        /// object. If the input string is not in the expected format or contains invalid data, the method logs an error
        /// message to the console and returns <see langword="null"/>.</remarks>
        /// <param name="data">A tab-delimited string containing the attributes of the <see cref="Alumno"/>. The string must include the
        /// following fields in order: NIA (integer), first name, last name, birth date (in a valid date format),
        /// average score (floating-point number), grade (as a valid <see cref="FpType"/> value), and a boolean
        /// indicating whether the student has a scholarship.</param>
        /// <returns>A new <see cref="Alumno"/> instance if the input string is valid; otherwise, <see langword="null"/>.</returns>
        private static Alumno? CreateAlumno(string data)
        {
            Alumno? newAlumno = null;
            try
            {
                string[] attribs = data.Split('\t');
                int Nia = int.Parse(attribs[0]);
                DateOnly birthDay = DateOnly.Parse(attribs[3]);
                float averageScore = float.Parse(attribs[4]);
                FpType grade = (FpType)Enum.Parse(typeof(FpType), attribs[5]);
                bool isScholarship = bool.Parse(attribs[6]);
                byte age = byte.Parse(attribs[7]);
                newAlumno = new Alumno(Nia, attribs[1], attribs[2], birthDay, averageScore, grade, isScholarship, age);
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Ha ocurrido un error al tratar de transformar uno de los datos: {ex.Message}");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return newAlumno;
        }
    }
}
