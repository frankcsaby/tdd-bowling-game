using System;

namespace BowlingGame
{
    public class TenthFrame : Frame
    {
        private const int MaxPins = 10;

        public int Roll3 { get; private set; }
        public bool HasBonusRoll { get; private set; }
        public bool HasSecondBonusRoll { get; private set; }
        public new bool AddRoll(int pins)
        {
            if (IsComplete)
            {
                throw new InvalidOperationException("Frame is already complete");
            }

            if (base.Roll1 == 0)
            {
                base.AddRoll(pins);
                HasBonusRoll = pins == MaxPins;
                return false;
            }
            else if (base.Roll2 == 0)
            {
                base.AddRoll(pins);


                HasBonusRoll = base.IsStrike || base.IsSpare;
                HasSecondBonusRoll = base.IsStrike && pins == MaxPins;

                return !HasBonusRoll;
            }
            else
            {
                Roll3 = pins;
                return !HasSecondBonusRoll || HasSecondBonusRoll;
            }
        }
        public new int BaseScore => base.BaseScore + Roll3;
        public new void Reset()
        {
            base.Reset();
            Roll3 = 0;
            HasBonusRoll = false;
            HasSecondBonusRoll = false;
        }
    }
}