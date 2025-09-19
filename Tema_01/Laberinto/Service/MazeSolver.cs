using Laberinto.Enums;
using Laberinto.StaticData;

namespace Laberinto.Service
{
    internal class MazeSolver
    {
        public char[,] Maze { get; } //Is given in the constructor
        public List<Directions> DirectionsSolution { get; } //Is autocreated in the constructor

        public MazeSolver(char[,] maze)
        {
            Maze = maze;
            DirectionsSolution = new List<Directions>();
        }

        /// <summary>
        /// Solves the maze and returns the sequence of directions required to navigate from the start to the end.
        /// </summary>
        /// <remarks>This method determines the path through the maze by iteratively calculating the next
        /// position  based on the current position and the last move. The maze is considered solved when the end 
        /// position is reached.</remarks>
        /// <returns>A list of <see cref="Directions"/> representing the sequence of moves required to solve the maze. The list
        /// will be empty if no solution is found.</returns>
        public List<Directions> SolveMaze()
        {
            bool isEnd = false;
            int[] nextPosition = GetStartPosition();
            int[] actualPosition;
            Directions? lastMove = null;
            while(!isEnd)
            {
                actualPosition = nextPosition;
                nextPosition = GetNextPosition(actualPosition, lastMove);
                lastMove = DirectionsSolution.Last();
                isEnd = Maze[nextPosition[0], nextPosition[1]] == StaticMazeData.MAZE_END;
            }
            return DirectionsSolution;
        }

        /// <summary>
        /// Finds the starting position in the maze.
        /// </summary>
        /// <remarks>The starting position is identified by the value <see
        /// cref="StaticMazeData.MAZE_START"/> within the maze. The method searches the maze row by row and returns the
        /// coordinates of the first occurrence of the starting position.</remarks>
        /// <returns>An array of two integers representing the row and column indices of the starting position in the maze. If
        /// the starting position is not found, the returned array will contain the default value [0, 0].</returns>
        private int[] GetStartPosition()
        {
            int[] startPosition = new int[2];
            bool isStart = false;
            for (int i = 0; i < Maze.GetLength(0); i++)
            {
                for (int j = 0; j < Maze.GetLength(1); j++)
                {
                    if (Maze[i, j] == StaticMazeData.MAZE_START)
                    {
                        startPosition = [i, j];
                        isStart = true;
                        break;
                    }
                }
                if (isStart) break;
            }
            return startPosition;
        }

        /// <summary>
        /// Calculates the next position based on the current position and an optional last move direction.
        /// </summary>
        /// <remarks>The method determines the next position by calculating a new direction based on the
        /// current position and the last move. The first move is null because it cannot have moved before.
        /// The resulting position is adjusted according to the calculated direction.</remarks>
        /// <param name="actualPosition">An array of two integers representing the current position, where the first element is the row and the
        /// second element is the column.</param>
        /// <param name="lastMove">An optional parameter specifying the last move direction. If provided, it may influence the calculation of
        /// the next position.</param>
        /// <returns>An array of two integers representing the next position, where the first element is the row and the second
        /// element is the column.</returns>
        private int[] GetNextPosition(int[] actualPosition, Directions? lastMove = null)
        {
            int[] nextPosition = new int[2];
            Directions newDirection = GetDirection(actualPosition, lastMove);
            int actualRow = actualPosition[0];
            int actualColumn = actualPosition[1];

            DirectionsSolution.Add(newDirection);
            switch (newDirection)
            {
                case Directions.Arriba:
                    nextPosition = [actualRow - 1, actualColumn];
                    break;
                case Directions.Derecha:
                    nextPosition = [actualRow, actualColumn + 1];
                    break;
                case Directions.Abajo:
                    nextPosition = [actualRow + 1, actualColumn];
                    break;
                case Directions.Izquierda:
                    nextPosition = [actualRow, actualColumn - 1];
                    break;
            }
            return nextPosition;
        }

        /// <summary>
        /// Represents a collection of predefined movement directions, each associated with a row delta,  column delta,
        /// the direction of movement, and its opposite direction.
        /// </summary>
        /// <remarks>This array defines the possible moves in a grid-based system, where each entry
        /// specifies: - The change in row and column coordinates for the move. - The direction of the move. - The
        /// opposite direction of the move.  The directions are represented using the <see cref="Directions"/>
        /// enumeration.</remarks>
        private static readonly (int rowDelta, int colDelta, Directions direction, Directions opposite)[] DirectionMoves =
        {
            (-1, 0, Directions.Arriba, Directions.Abajo),    // Arriba
            (0, 1, Directions.Derecha, Directions.Izquierda), // Derecha  
            (1, 0, Directions.Abajo, Directions.Arriba),     // Abajo
            (0, -1, Directions.Izquierda, Directions.Derecha) // Izquierda
        };

        /// <summary>
        /// Determines the next valid direction to move within the maze, avoiding the previous cell.
        /// </summary>
        /// <remarks>This method evaluates potential moves based on the current position and the last
        /// move, ensuring that the next move does not return to the previous cell. It checks the boundaries of the maze
        /// and considers only cells that are part of the path or the maze's endpoint.</remarks>
        /// <param name="actualPosition">The current position in the maze, represented as an array where the first element is the row index and the
        /// second element is the column index.</param>
        /// <param name="lastMove">The direction of the last move, or <see langword="null"/> if no previous move exists.</param>
        /// <returns>The next valid direction to move within the maze. If no valid direction is found, defaults to <see
        /// cref="Directions.Izquierda"/>.</returns>
        private Directions GetDirection(int[] actualPosition, Directions? lastMove)
        {
            int rows = Maze.GetLength(0);
            int columns = Maze.GetLength(1);
            int actualRow = actualPosition[0];
            int actualColumn = actualPosition[1];

            // Search the next valid direction to move that isn't the previous cell 
            foreach (var (rowDelta, colDelta, direction, opposite) in DirectionMoves)
            {
                // Skip if is the opposite of the last move. Avoid infinite loop.
                if (lastMove == opposite) continue;

                int newRow = (actualRow + rowDelta);
                int newColumn = (actualColumn + colDelta);

                // Check the limits of the maze (Bidimensional Array)
                if (newRow >= rows || newColumn >= columns) continue;

                char cellValue = Maze[newRow, newColumn];

                // Chek if the cell is path or the end
                if (cellValue == StaticMazeData.MAZE_PATH || cellValue == StaticMazeData.MAZE_END) return direction;
            }

            // If the direcctions aren't valid, ther's only one left, literally left
            return Directions.Izquierda;
        }
        
    }
}
