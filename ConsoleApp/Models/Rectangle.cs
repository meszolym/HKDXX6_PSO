namespace ConsoleApp.Models;

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