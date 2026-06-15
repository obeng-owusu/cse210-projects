using System;

namespace FitnessTracker
{
    public class Cycling : Activity
    {
        private double _speed;

        public Cycling(DateTime date, int lengthInMinutes, double speed)
            : base(date, lengthInMinutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * LengthInMinutes) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            return 60 / _speed;
        }
    }
}