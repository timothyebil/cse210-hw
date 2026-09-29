using System;

/*
================================================================================
Student Name: Timothy Ebil
Course: CSE 210
Project: Eternal Quest (Week 06 Prove Assignment)

Exceeded Requirements Manifest:
1. Dynamic Leveling Calculation System: Transformed simple point tracking into a fully 
   interactive level status matrix, which checks exactly how many points remain to access the next level threshold.
2. Streak Modifier Multiplier: Programmed a custom task tracking streak mechanism (`_streak`) 
   within `GoalManager`. Completing tasks consecutively applies a compounding baseline bonus (+10 pts x streak level). 
   Attempting to process fully completed targets breaks the loop cycle and drops the modifier baseline.
================================================================================
*/

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}
