using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance in km = laps * 50m / 1000
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        // Speed = (distance / time) * 60
        return (GetDistance() / Length) * 60;
    }

    public override double GetPace()
    {
        // Pace = time / distance
        return Length / GetDistance();
    }
}
