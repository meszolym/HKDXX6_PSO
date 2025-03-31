using System;
using System.Collections.Generic;
using System.Linq;

namespace HKDXX6_PSO;

class Program
{
    static void Main(string[] args)
    {
        
    }
    

}

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}
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

public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }
    
    public double Area()
    {
        return Math.Abs(TopLeft.X - BottomRight.X) * Math.Abs(TopLeft.Y - BottomRight.Y);
    }
    
    public double Perimeter()
    {
        return 2 * (Math.Abs(TopLeft.X - BottomRight.X) + Math.Abs(TopLeft.Y - BottomRight.Y));
    }
}