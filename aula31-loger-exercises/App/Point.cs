using System;

public struct Point{
    [ToLog("Blue and White")] public readonly int x;
    [ToLog] public readonly int y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    [ToLog(typeof(LogFormatterTruncate))] public double GetModule() {
            return System.Math.Sqrt(x*x + y*y);
    }
    
}

class LogFormatterTruncate : IFormatter
{
    readonly int decimals = 2;
    public object Format(object val)
    {
        return Math.Round((double) val, decimals);
    }
}