namespace Maze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear(); // Очищаем консоль для новой игры
                Console.WriteLine("Введите размер лабиринта (ширина и высота):");
                Console.WriteLine("Минимум: 5x5, Максимум: 100x25");

                int height, width;

                // Проверяем корректность ввода для высоты
                while (true)
                {
                    Console.Write("Высота (5-50): ");
                    if (int.TryParse(Console.ReadLine(), out height) && height >= 5 && height <= 50)
                    {
                        break; // Корректный ввод, выходим из цикла
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите число от 5 до 25.");
                    }
                }

                // Проверяем корректность ввода для ширины
                while (true)
                {
                    Console.Write("Ширина (5-25): ");
                    if (int.TryParse(Console.ReadLine(), out width) && width >= 5 && width <= 25)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод. Пожалуйста, введите число от 5 до 100.");
                    }
                }

                Console.Clear();

                var game = new Game(height, width);
                game.Run();

                Console.WriteLine("\nХотите сыграть еще раз? (Y/N): ");
                var response = Console.ReadKey(true).Key;

                // Проверка ответа пользователя
                if (response == ConsoleKey.N)
                {
                    playAgain = false;
                }
            }

            Console.WriteLine("Спасибо за игру! Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
