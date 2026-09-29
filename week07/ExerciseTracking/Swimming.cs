namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        // Encapsulation: Unique attribute is private and stored only in the derived class
        private int _laps;

        public Swimming(string date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }

        // Distance formula using math hints: laps * 50 meters / 1000 to convert to km
        public override double GetDistance() => (_laps * 50.0) / 1000.0;

        public override double GetSpeed() => (GetDistance() / Minutes) * 60;

        public override double GetPace() => Minutes / GetDistance();
    }
}
