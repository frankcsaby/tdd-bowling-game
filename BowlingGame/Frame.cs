using System;

namespace BowlingGame
{
    public class Frame
    {
        private const int MaxPins = 10;

        public int Roll1 { get; private set; }
        public int Roll2 { get; private set; }
        public bool IsComplete { get; private set; }

        public bool AddRoll(int pins)
        {
            if (IsComplete)
            {
                throw new InvalidOperationException("Frame is already complete");
            }

            if (Roll1 == 0)
            {
                Roll1 = pins;
                IsComplete = pins == MaxPins;
            }
            else
            {
                if (pins + Roll1 > MaxPins && Roll1 != MaxPins)
                {
                    throw new ArgumentException($"Total pins for a frame cannot exceed {MaxPins}");
                }

                Roll2 = pins;
                IsComplete = true;
            }

            return IsComplete;
        }

        public int BaseScore => Roll1 + Roll2;

        public bool IsStrike => Roll1 == MaxPins;

        public bool IsSpare => !IsStrike && BaseScore == MaxPins;

        public void Reset()
        {
            Roll1 = 0;
            Roll2 = 0;
            IsComplete = false;
        }
    }
}