/*
Eternal Quest Program
- Tracks multiple goal types (Simple, Eternal, Checklist)
- Uses inheritance, encapsulation, and polymorphism
- Saves and loads goals from text file
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
