namespace ExerciseTracking
{
    public class Running : Activity
    {
        // Encapsulation: Unique attribute is private and stored only in the derived class
        private double _distance; 

        public Running(string date, int minutes, double distance) : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;

        public override double GetSpeed() => (_distance / Minutes) * 60;

        public override double GetPace() => Minutes / _distance;
    }
}
