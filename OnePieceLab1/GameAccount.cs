using System;
using System.Collections.Generic;

namespace OnePieceLab1
{
    public class GameAccount
    {
        private readonly List<Game> _games = new List<Game>();

        public string UserName { get; }
        public int CurrentRating { get; private set; }
        public int GamesCount => _games.Count;

        public GameAccount(string userName, int initialRating = 100)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException(
                    "Ім'я гравця не може бути порожнім.");
            }

            if (initialRating < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(initialRating),
                    "Початковий рейтинг повинен бути не меншим за 1.");
            }

            UserName = userName.Trim();
            CurrentRating = initialRating;
        }

        public void WinGame(string opponentName, int rating)
        {
            ValidateGame(opponentName, rating);

            int newRating = checked(CurrentRating + rating);

            Game game = new Game(
                opponentName, rating, true, GamesCount + 1);

            _games.Add(game);
            CurrentRating = newRating;
        }

        public void LoseGame(string opponentName, int rating)
        {
            ValidateGame(opponentName, rating);

            int newRating = Math.Max(1, CurrentRating - rating);

            Game game = new Game(
                opponentName, rating, false, GamesCount + 1);

            _games.Add(game);
            CurrentRating = newRating;
        }

        public void GetStats()
        {
            Console.WriteLine($"\n--- Статистика: {UserName} ---");
            Console.WriteLine($"Поточний рейтинг: {CurrentRating}");
            Console.WriteLine($"Кількість ігор: {GamesCount}");

            if (GamesCount == 0)
            {
                Console.WriteLine("Історія ігор порожня.");
                return;
            }

            foreach (Game game in _games)
            {
                string result = game.IsWin ? "Перемога" : "Поразка";

                Console.WriteLine(
                    $"Гра №{game.Index} | " +
                    $"ID: {game.Id} | " +
                    $"Опонент: {game.OpponentName} | " +
                    $"Результат: {result} | " +
                    $"Рейтинг гри: {game.Rating}");
            }
        }

        private void ValidateGame(string opponentName, int rating)
        {
            if (string.IsNullOrWhiteSpace(opponentName))
            {
                throw new ArgumentException(
                    "Ім'я суперника не може бути порожнім.");
            }

            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(rating),
                    "Рейтинг гри не може бути від'ємним.");
            }
        }
    }
}
