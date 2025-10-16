using System;

public class Running : Activity
{
    private double _distance; // in kilometers

    public Running(DateTime date, int length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // Speed = distance / time * 60
        return (_distance / Length) * 60;
    }

    public override double GetPace()
    {
        // Pace = time / distance
        return Length / _distance;
    }
}
