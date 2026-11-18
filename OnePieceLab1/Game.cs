using System;

namespace OnePieceLab1
{
    public class Game
    {
        private static int _lastId = 0;

        public int Id { get; }
        public string OpponentName { get; }
        public int Rating { get; }
        public bool IsWin { get; }
        public int Index { get; }

        public Game(string opponentName, int rating, bool isWin, int index)
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

            if (index < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    "Індекс гри повинен бути більшим за 0.");
            }

            Id = ++_lastId;
            OpponentName = opponentName.Trim();
            Rating = rating;
            IsWin = isWin;
            Index = index;
        }
    }
}
