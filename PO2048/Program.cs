using System;

namespace CS2048
{
    // Klasa reprezentująca planszę gry
    class Board
    {
        private int size;
        private int[,] grid;

        public Board(int size)
        {
            this.size = size;
            this.grid = new int[size, size];
        }

        // Metoda wyświetlająca planszę gry
        public void Display()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(grid[row, col] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Metoda sprawdzająca, czy gra jest zakończona
        public bool IsGameOver()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Metoda losująca nową liczbę na planszy
        public void AddNewNumber()
        {
            Random random = new Random();
            int row, col;
            do
            {
                row = random.Next(size);
                col = random.Next(size);
            }
            while (grid[row, col] != 0);

            grid[row, col] = random.Next(1, 3) * 2;
        }

        // Metoda przesuwająca kafelki w lewo
        public void MoveLeft()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 1; col < size; col++)
                {
                    if (grid[row, col] != 0)
                    {
                        int currentCol = col;
                        while (currentCol > 0 && grid[row, currentCol - 1] == 0)
                        {
                            grid[row, currentCol - 1] = grid[row, currentCol];
                            grid[row, currentCol] = 0;
                            currentCol--;
                        }

                        if (currentCol > 0 && grid[row, currentCol - 1] == grid[row, currentCol])
                        {
                            grid[row, currentCol - 1] *= 2;
                            grid[row, currentCol] = 0;
                        }
                    }
                }
            }
        }

        // Metoda przesuwająca kafelki w górę
        public void MoveUp()
        {
            for (int col = 0; col < size; col++)
            {
                for (int row = 1; row < size; row++)
                {
                    if (grid[row, col] != 0)
                    {
                        int currentRow = row;
                        while (currentRow > 0 && grid[currentRow - 1, col] == 0)
                        {
                            grid[currentRow - 1, col] = grid[currentRow, col];
                            grid[currentRow, col] = 0;
                            currentRow--;
                        }

                        if (currentRow > 0 && grid[currentRow - 1, col] == grid[currentRow, col])
                        {
                            grid[currentRow - 1, col] *= 2;
                            grid[currentRow, col] = 0;
                        }
                    }
                }
            }
        }

        // Metoda przesuwająca kafelki w dół
        public void MoveDown()
        {
            for (int col = 0; col < size; col++)
            {
                for (int row = size - 2; row >= 0; row--)
                {
                    if (grid[row, col] != 0)
                    {
                        int currentRow = row;
                        while (currentRow < size - 1 && grid[currentRow + 1, col] == 0)
                        {
                            grid[currentRow + 1, col] = grid[currentRow, col];
                            grid[currentRow, col] = 0;
                            currentRow++;
                        }

                        if (currentRow < size - 1 && grid[currentRow + 1, col] == grid[currentRow, col])
                        {
                            grid[currentRow + 1, col] *= 2;
                            grid[currentRow, col] = 0;
                        }
                    }
                }
            }
        }

        // Metoda przesuwająca kafelki w prawo
        public void MoveRight()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = size - 2; col >= 0; col--)
                {
                    if (grid[row, col] != 0)
                    {
                        int currentCol = col;
                        while (currentCol < size - 1 && grid[row, currentCol + 1] == 0)
                        {
                            grid[row, currentCol + 1] = grid[row, currentCol];
                            grid[row, currentCol] = 0;
                            currentCol++;
                        }

                        if (currentCol < size - 1 && grid[row, currentCol + 1] == grid[row, currentCol])
                        {
                            grid[row, currentCol + 1] *= 2;
                            grid[row, currentCol] = 0;
                        }
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(4);
            board.AddNewNumber();
            board.AddNewNumber();
            board.Display();

            while (!board.IsGameOver())
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();

                if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    board.MoveLeft();
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    board.MoveRight();
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    board.MoveUp();
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    board.MoveDown();
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }

                board.AddNewNumber();
                board.Display();
            }

            Console.WriteLine("Przegrales!");
        }
    }
}
