using System;

namespace OnePieceLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ONE PIECE: Рейтингова система ===");

            // Створення двох гравців
            GameAccount player1 = new GameAccount("Монкі Д. Луффі", 100);
            GameAccount player2 = new GameAccount("Ророноа Зоро", 100);

            // Ігри Луффі
            player1.WinGame("Санджі", 30);
            player1.LoseGame("Кайдо", 20);
            player1.WinGame("Баггі", 50);
            player1.LoseGame("Шанкс", 200);

            // Ігри Зоро
            player2.WinGame("Намі", 25);
            player2.LoseGame("Міхок", 40);
            player2.WinGame("Санджі", 35);
            player2.WinGame("Кайдо", 60);

            // Перевірка від'ємного рейтингу гри
            Console.WriteLine("\nПеревірка некоректного рейтингу:");

            try
            {
                player2.WinGame("Баггі", -10);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Помилку перехоплено: {ex.Message}");
            }

            // Виведення статистики
            player1.GetStats();
            player2.GetStats();
        }
    }
}

