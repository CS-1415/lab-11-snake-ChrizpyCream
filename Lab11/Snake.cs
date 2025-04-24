using System;

namespace Lab11
{
    public class Snake
    {
        public string? Name { get; set; } //  name
        public List<IGraphic2D> Body { get; set; } // List of body segments
        public Board Board { get; set; } // Reference to the game board
        private Direction Current { get; set; } // Current direction
        public int MoveX { get; set; } // Current X position of head
        public int MoveY { get; set; } // Current Y position of head
        public bool IsAlive { get; private set; } = true; //      Status of the snake

        public event Action? KeyPressed;

        public Snake(string? name, int movex, int movey, Board board)
        {
            Name = name;
            MoveX = movex;
            MoveY = movey;
            Current = Direction.East;
            Board = board;
            Body = new List<IGraphic2D>
            {
                new Cell(MoveX - 1, MoveY) { BackgroundColor = ConsoleColor.Green, DisplayChar = '>' },
                new Cell(MoveX, MoveY) { BackgroundColor = ConsoleColor.Green, DisplayChar = '>' }
            };

            Board.snakes.Add(this);
        }

        public void TurnWest() => Current = Direction.West;
        public void TurnEast() => Current = Direction.East;
        public void TurnNorth() => Current = Direction.North;
        public void TurnSouth() => Current = Direction.South;

        public void MoveForward()
        {
            if (!IsAlive) return;

            int newX = MoveX;
            int newY = MoveY;

            switch (Current)
            {
                case Direction.North: newY--; break;
                case Direction.South: newY++; break;
                case Direction.West:  newX--; break;
                case Direction.East:  newX++; break;
            }

            // Check collision with wall or self
            if (!CanMove(newX, newY))
            {
                IsAlive = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\n\t\tGAME OVER, {Name}!");
                Console.ResetColor();
                return;
            }

            MoveX = newX;
            MoveY = newY;

            Cell newCell = new Cell(MoveX, MoveY)
            {
                BackgroundColor = ConsoleColor.Green,
                DisplayChar = Current switch
                {
                    Direction.North => '^',
                    Direction.South => 'v',
                    Direction.West => '<',
                    Direction.East => '>',
                    _ => ' '
                }
            };

            if (MoveX == Board.Apple.X && MoveY == Board.Apple.Y)
            {
                Body.Add(newCell);
                while (IsSnake(Board.Apple.X, Board.Apple.Y))
                {
                    Board.NextApple();
                }
            }
            else
            {
                Body.RemoveAt(0);
                Body.Add(newCell);
            }
        }

        public bool CanMove(int x, int y)
        {
            return x > 0 && x < Board.Width &&
                   y > 0 && y < Board.Height &&
                   !IsSnake(x, y);
        }

        public bool IsSnake(decimal x, decimal y)
        {
            foreach (Cell cell in Body)
            {
                if (cell.X == x && cell.Y == y)
                    return true;
            }
            return false;
        }

        enum Direction { North, South, East, West }
    }
}
