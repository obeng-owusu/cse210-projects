using System;

namespace FitnessTracker
{
    public class Swimming : Activity
    {
        private int _numberOfLaps;

        public Swimming(DateTime date, int lengthInMinutes, int numberOfLaps)
            : base(date, lengthInMinutes)
        {
            _numberOfLaps = numberOfLaps;
        }

        public override double GetDistance()
        {
            // Using the exact formula from the assignment:
            // Distance (miles) = swimming laps * 50 / 1000 * 0.62
            return ((_numberOfLaps * 50) / 1000.0) * 0.62;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / LengthInMinutes) * 60;
        }

        public override double GetPace()
        {
            return LengthInMinutes / GetDistance();
        }
    }
}