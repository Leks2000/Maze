namespace Maze
{
    /// <summary>
    /// Основной класс игры.
    /// </summary>
    internal class Game
    {
        private Maze maze;
        private Player player;
        private PlayerMovement playerMovement;
        private int exitX;
        private int exitY;

        public Game(int width, int height)
        {
            maze = new Maze(width, height);
            player = new Player('☺');
            var rand = new Random();
            maze.GenerateMaze();
            (player.X, player.Y) = maze.GetRandomFreePosition(rand);
            (exitX, exitY) = maze.GetRandomFreePosition(rand);
            maze.Grid[exitY, exitX] = 3;

            playerMovement = new PlayerMovement(maze, player);
        }

        public void Run()
        {
            Console.CursorVisible = false;
            maze.Draw(player);
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(player.Symbol);


            while (true)
            {
                var key = Console.ReadKey(true);
                playerMovement.Move(key.Key);

                maze.Draw(player);
                Console.SetCursorPosition(player.X, player.Y);
                Console.Write(player.Symbol);

                if (player.X == exitX && player.Y == exitY)
                {
                    break;
                }
            }

            Console.Clear();
            Console.SetCursorPosition(50, 15);
            Console.WriteLine("Вы прошли лабиринт");
        }
    }

}
