﻿namespace Maze
{
    /// <summary>
    /// Класс лабиринта.
    /// </summary>
    internal class Maze
    {
        public int[,] Grid { get; private set; }
        public bool[,] Revealed { get; private set; }
        public int Width { get; }
        public int Height { get; }

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new int[height, width];
            Revealed = new bool[height, width];
        }

        /// <summary>
        /// Генерирация лабиринта.
        /// </summary>
        public void GenerateMaze()
        {
            Stack<(int x, int y)> stack = new Stack<(int x, int y)>();
            var rand = new Random();
            int[] dx = { 1, 0, -1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    Grid[i, j] = 1;
                }
            }

            var startX = 1;
            var startY = 1;
            Grid[startY, startX] = 0;
            stack.Push((startX, startY));

            while (stack.Count > 0)
            {
                var (posX, posY) = stack.Pop();
                List<int> directions = new List<int> { 0, 1, 2, 3 }.OrderBy(d => rand.Next()).ToList();

                foreach (var direction in directions)
                {
                    var newX = posX + dx[direction] * 2;
                    var newY = posY + dy[direction] * 2;

                    if (newX > 0 && newY > 0 && newX < Width - 1 && newY < Height - 1 && Grid[newY, newX] == 1)
                    {
                        Grid[newY, newX] = 0;
                        Grid[posY + dy[direction], posX + dx[direction]] = 0;
                        stack.Push((newX, newY));
                    }
                }
            }
        }
        /// <summary>
        /// Отрисовывает лабиринт с учетом видимости.
        /// </summary>
        /// <remarks>Туман войны</remarks>
        /// <param name="player">Позиция игрока</param>
        public void Draw(Player player)
        {
            var visionRange = 3;

            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    if (Math.Abs(i - player.Y) <= visionRange && Math.Abs(j - player.X) <= visionRange)
                    {
                        Revealed[i, j] = true;
                    }

                    if (Revealed[i, j])
                    {
                        Console.SetCursorPosition(j, i);
                        if (Grid[i, j] == 1)
                        {
                            Console.Write('█');
                        }
                        else if (Grid[i, j] == 0)
                        {
                            Console.Write(' ');
                        }
                        else if (Grid[i, j] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write('*');
                            Console.ResetColor();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получает случайную проходимую позицию.
        /// </summary>
        public (int, int) GetRandomFreePosition(Random rand)
        {
            List<(int, int)> freePositions = new List<(int, int)>();
            for (var i = 1; i < Height - 1; i++)
            {
                for (var j = 1; j < Width - 1; j++)
                {
                    if (Grid[i, j] == 0 && !(i == Height - 2 && j == Width - 2))
                    {
                        freePositions.Add((j, i));
                    }
                }
            }

            return freePositions.Count > 0 ? freePositions[rand.Next(freePositions.Count)] : (1, 1);
        }
    }
}
