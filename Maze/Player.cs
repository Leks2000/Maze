namespace Maze
{

    /// <summary>
    /// Представляет игрока в лабиринте.
    /// </summary>
    internal class Player
    {
        public char Symbol { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Player(char symbol)
        {
            Symbol = symbol;
        }
    }
}
