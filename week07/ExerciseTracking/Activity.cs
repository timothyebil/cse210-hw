using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        // Encapsulation: Member variables are private and stored in the base class
        private string _date;
        private int _minutes;

        public Activity(string date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public string Date => _date;
        public int Minutes => _minutes;

        // Polymorphism: Abstract methods declared in the base class to be overridden
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Virtual method defined solely in the base class using dynamic binding hooks
        public virtual string GetSummary()
        {
            return $"{_date} {GetType().Name} ({_minutes} min): " +
                   $"Distance {GetDistance():F1} km, " +
                   $"Speed {GetSpeed():F1} kph, " +
                   $"Pace: {GetPace():F2} min per km";
        }
    }
}
