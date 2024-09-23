namespace Maze
{
    /// <summary>
    /// Основной класс программы
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Управление на WASD");
            Console.WriteLine("Нажмите любую клавишу для продолжения: ");
            Console.ReadKey();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите размер лабиринта (высота и ширина):");
                Console.WriteLine("Минимум: 5x5, Максимум: 25х50");

                int width, height;

                width = GetValidSize("Ширина", 5, 50);
                height = GetValidSize("Высота", 5, 25);

                Console.Clear();

                var game = new Game(width, height);
                game.Run();

                Console.WriteLine("\nХотите сыграть еще раз? (Y/N): ");
                while (true)
                {
                    var response = Console.ReadKey(true).Key;

                    if (response == ConsoleKey.Y)
                    {
                        break;
                    }
                    else if (response == ConsoleKey.N)
                    {
                        Console.WriteLine("\nСпасибо за игру! Нажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\nНеверная клавиша. Пожалуйста, нажмите Y, чтобы продолжить, или N, чтобы выйти.");
                    }
                }
            }
        }

        private static int GetValidSize(string dimension, int min, int max)
        {
            int size;
            while (true)
            {
                Console.Write($"{dimension} ({min}-{max}): ");
                if (int.TryParse(Console.ReadLine(), out size) && size >= min && size <= max)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный ввод. Пожалуйста, введите число от {min} до {max}.");
                }
            }
            return size;
        }
    }
}
