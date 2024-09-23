using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// Основной класс игры.
    /// </summary>
    internal class Game
    {
        private Maze maze;
        private Player player;
        private int enxPosX;
        private int endPosY;

        public Game(int width, int height)
        {
            maze = new Maze(width, height);
            player = new Player('☺');
            var rand = new Random();
            maze.Generate();
            (player.X, player.Y) = maze.GetRandomFreePosition(rand);
            (enxPosX, endPosY) = maze.GetRandomFreePosition(rand);
            maze.Grid[endPosY, enxPosX] = 3; // Финиш
        }

        /// <summary>
        /// Запускает игру.
        /// </summary>
        public void Run()
        {
            Console.CursorVisible = false;
            maze.Draw(player);
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(player.Symbol);

            bool running = true;

            while (running)
            {
                var key = Console.ReadKey(true);
                MovePlayer(key.Key);

                maze.Draw(player);
                Console.SetCursorPosition(player.X, player.Y);
                Console.Write(player.Symbol);

                // Проверка на победу
                if (player.X == enxPosX && player.Y == endPosY)
                {
                    running = false;
                }
            }

            Console.Clear();
            Console.SetCursorPosition(50, 15);
            Console.WriteLine("Вы прошли лабиринт");
        }

        private void MovePlayer(ConsoleKey key)
        {
            int newX = player.X, newY = player.Y;

            if (key == ConsoleKey.W && maze.Grid[player.Y - 1, player.X] != 1)
            {
                newY--;
            }
            if (key == ConsoleKey.S && maze.Grid[player.Y + 1, player.X] != 1)
            {
                newY++;
            }

            if (key == ConsoleKey.A && maze.Grid[player.Y, player.X - 1] != 1)
            {
                newX--;
            }

            if (key == ConsoleKey.D && maze.Grid[player.Y, player.X + 1] != 1)
            {
                newX++;
            }

            // Обновляем положение игрока
            if (newX != player.X || newY != player.Y)
            {
                player.X = newX;
                player.Y = newY;
            }
        }
    }

}
