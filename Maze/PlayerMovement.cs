using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    /// <summary>
    /// Передвижение игрока
    /// </summary>
    internal class PlayerMovement
    {
        private Maze maze;
        private Player player;

        public PlayerMovement(Maze maze, Player player)
        {
            this.maze = maze;
            this.player = player;
        }

        public void Move(ConsoleKey key)
        {
            int targePosX = player.X, targetPosY = player.Y;

            if (key == ConsoleKey.W && maze.Grid[player.Y - 1, player.X] != 1)
            {
                targetPosY--;
            }
            if (key == ConsoleKey.S && maze.Grid[player.Y + 1, player.X] != 1)
            {
                targetPosY++;
            }

            if (key == ConsoleKey.A && maze.Grid[player.Y, player.X - 1] != 1)
            {
                targePosX--;
            }

            if (key == ConsoleKey.D && maze.Grid[player.Y, player.X + 1] != 1)
            {
                targePosX++;
            }

            if (targePosX != player.X || targetPosY != player.Y)
            {
                player.X = targePosX;
                player.Y = targetPosY;
            }
        }

    }
}
