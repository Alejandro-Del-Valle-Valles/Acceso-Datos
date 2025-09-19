using Laberinto.StaticData;

namespace Laberinto.Service
{
    internal static class MazeSolver
    {
        public static List<string> SolveMaze(char[,]? maze)
        {
            List<string> solution = new List<string>();
            if (maze != null)
            {
                bool isEnd = false;
                byte[] nextPosition;
                while(!isEnd)
                {
                    foreach (char c in maze)
                    {
                        if(c == StaticMazeData.MAZE_START)
                        {
                            nextPosition = GetNextPosition(maze);
                            /*Tras obtener la posicón, chequear si es el fin. También guardar la dirección en la que se ha movido
                             comprobando. Esto es, si la posición vertical (primera posicón array) es inferior o superior, ha bajado,
                            si la primera es igual, ver si la segunda es mayor o menos (Mayor derecha, menor izquierda)*/
                        }
                    }
                }
            }
            return solution;
        }

        private static byte[] GetNextPosition(char[,] maze)
        {
            byte[] nextPosition = new byte[2];
            //Tengo que obtener la posición en la que se encuentra y comprobar que no ha estado antes en es aposición, luego chequear
            // si en la ostras 3 posiciónes restantes hay algo que no sea un * y devolver esa posicón.
            return nextPosition;
        }
    }
}
