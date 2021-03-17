namespace PointLib
{
    public class Point
    {   
        private double x = 0;
        private double y = 0;
        public Point(double x, double y){
            this.x = x;
            this.y = y;
        }

        public double getModule(){
            return System.Math.Sqrt(x*x + y*y);
        }

    }
}