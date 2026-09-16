using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you pace your breathing to have a session of deep breathing for a certain amount of time. It aims to clear your mind and promote focused awareness.")
    {}

    protected override void ExecuteActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            Console.WriteLine();
            
            Console.Write("Breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }
    }
}
