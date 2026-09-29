using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _shortName;
        protected string _description;
        protected int _points;

        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }

        public string ShortName => _shortName;
        public int Points => _points;

        public abstract void RecordEvent();
        public abstract bool IsComplete();
        
        public virtual string GetDetailsString()
        {
            string statusCheckbox = IsComplete() ? "[X]" : "[ ]";
            return $"{statusCheckbox} {_shortName} ({_description})";
        }

        public abstract string GetStringRepresentation();
    }
}
