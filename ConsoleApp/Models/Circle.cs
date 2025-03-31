namespace ConsoleApp.Models;

class Circle
{
    public Point Center { get; set; }
    public double Radius { get; set; }

    public Circle(double radius, double x, double y)
    {
        Radius = radius;
    }

    public double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public double Circumference()
    {
        return 2 * Math.PI * Radius;
    }
}