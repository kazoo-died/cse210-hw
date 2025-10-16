using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length; // in minutes

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime Date => _date;
    public int Length => _length;

    // Abstract methods to be overridden
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Shared summary output
    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Length} min) - " +
               $"Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace {GetPace():0.0} min per km";
    }
}
