using T01_Ejercicios_Manejo_Ficheros.Modelo;
using T01_Ejercicios_Manejo_Ficheros.Repositorio;

namespace PruebasTema01
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var test = AlumnosRepositorio.GetAlumnos("D:\\Visual_Studio_Repo\\Acceso_Datos\\Tema_01\\T01_Ejercicios_Manejo_Ficheros\\Ficheros\\alumnos.txt");
            var alumno = test[0];
            DateOnly bd = new DateOnly(2006, 05, 13);
            Assert.Equal(new Alumno(1, "Alejandro", "Del Valle Vallés", bd, 9.6f, T01_Ejercicios_Manejo_Ficheros.Enums.FpType.Superior, true, 19), alumno);
        }
    }
}