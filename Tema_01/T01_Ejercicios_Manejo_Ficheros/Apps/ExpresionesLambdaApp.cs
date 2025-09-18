using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01_Ejercicios_Manejo_Ficheros.Modelo;
using T01_Ejercicios_Manejo_Ficheros.Servicios;

namespace T01_Ejercicios_Manejo_Ficheros.Apps
{
    internal static class ExpresionesLambdaApp
    {
        /// <summary>
        /// Generates a file containing the string representation of students whose ages are greater than or equal to
        /// the specified value.
        /// </summary>
        /// <param name="alumnos">A collection of <see cref="Alumno"/> objects to filter by age.</param>
        /// <param name="age">The minimum age, inclusive, to include in the file.</param>
        public static void GenerateReportAgesOver(ICollection<Alumno> alumnos, int age)
        {
            try
            {
                string path = DirectoryService.GetFilePath("mayores_de_edad.txt");
                File.WriteAllLines(path, alumnos
                    .Where(alumno => alumno.Age >= age)
                    .Select(alumno => alumno.ToString()));
            } catch(Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates an academic report in CSV format for the specified collection of students.
        /// </summary>
        /// <param name="alumnos">A collection of <see cref="Alumno"/> objects representing the students to include in the report. Each
        /// student's name, surname, birth date, and average score will be written to the CSV file.</param>
        public static void GenerateAcademicReport(ICollection<Alumno> alumnos)
        {
            try
            {
                string path = DirectoryService.GetFilePath("informe_académico.csv");
                File.WriteAllLines(path, alumnos
                    .Select(alumno => $"{alumno.Name};{alumno.Surname};{alumno.BirthDay};{alumno.AverageScore};"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates an academic report file containing student information, sorted by birth date.
        /// </summary>
        /// <param name="alumnos">A collection of students to include in the report. Each student's information is written to the file.</param>
        public static void GenerateAcademicReportByDate(ICollection<Alumno> alumnos)
        {
            try
            {
                string path = DirectoryService.GetFilePath("informe_académico_fechas.csv");
                File.WriteAllLines(path, alumnos
                    .OrderBy(alumno => alumno.BirthDay)
                    .Select(alumno => $"{alumno.Name};{alumno.Surname};{alumno.BirthDay};{alumno.AverageScore}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates an academic report file based on the average scores of the provided students.
        /// </summary>
        /// <param name="alumnos">A collection of students whose information will be included in the report. Each student must have a name,
        /// surname, birth date, and average score.</param>
        public static void GenerateAcademicReportByAverageScore(ICollection<Alumno> alumnos)
        {
            try
            {
                string path = DirectoryService.GetFilePath("informe_académico_nota_media.csv");
                File.WriteAllLines(path, alumnos
                    .OrderByDescending(alumno => alumno.AverageScore)
                    .Select(alumno => $"{alumno.Name};{alumno.Surname};{alumno.BirthDay};{alumno.AverageScore};"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates an academic report file that lists students, ordered by their average score in ascending order 
        /// and by their birth date in descending order for students with the same score.
        /// </summary>
        /// <param name="alumnos">A collection of students to include in the report. Each student must have a name, surname, birth date,  and
        /// average score.</param>
        public static void GenerateAcademicReportByAverageScoreAndDate(ICollection<Alumno> alumnos)
        {
            try
            {
                string path = DirectoryService.GetFilePath("informe_académico_nota_media_fecha.csv");
                File.WriteAllLines(path, alumnos
                    .OrderBy(alumno => alumno.AverageScore)
                    .ThenByDescending(alumno => alumno.BirthDay)
                    .Select(alumno => $"{alumno.Name};{alumno.Surname};{alumno.BirthDay};{alumno.AverageScore};"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error: {ex.Message}");
            }
        }

        /// <summary>
        /// Generates a report of students grouped by their grade and writes it to a file.
        /// </summary>
        /// <param name="alumnos">A collection of students to include in the report. Each student must have a grade, surname, and name.</param>
        public static void GenerateReportByCicle(ICollection<Alumno> alumnos)
        {
            try
            {
                string path = DirectoryService.GetFilePath("informe_por_ciclo.txt");
                File.WriteAllLines(path, alumnos
                        .GroupBy(alumno => alumno.Grade)
                        .OrderBy(grade => grade.Key)
                        .SelectMany(grade =>
                            new[] { $"{grade.Key}" }
                                .Concat(grade.Select(alumno => $"\t{alumno.Surname}, {alumno.Name}"))));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error: {ex.Message}");
            }
        }
    }
}
