public struct Point{
    [ToLog("Blue and White")] public readonly int x;
    [ToLog] public readonly int y;
    public Point(int x, int y) {
        this.x = x;
        this.y = y;
    }
    public double GetModule() {
            return System.Math.Sqrt(x*x + y*y);
    }
    
}
