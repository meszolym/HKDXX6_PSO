namespace HKDXX6_PSO;

class Program
{
    static void Main(string[] args)
    {
        var checkPoints = GenerateRandomTuples(50);
        var pso = new Pso(7, 250, x => Fitness(x, checkPoints));
        
        pso.Run();
        Console.WriteLine("Best position: " + string.Join(", ", pso.Swarm.GlobalBestPosition));
        Console.WriteLine("Best fitness: " + Fitness(pso.Swarm.GlobalBestPosition, checkPoints));
        Console.WriteLine("Checkpoints: " + string.Join(", ", checkPoints.Select(x => $"({x.Key}, {x.Value})")));
    }

    static Dictionary<double, double> GenerateRandomTuples(int number, Random? random = null)
    {
        random ??= Random.Shared;
        
        var tuples = new Dictionary<double, double>();
        
        for (var i = 0; i < number; i++)
        {
            tuples.Add(random.NextDouble()*100, random.NextDouble()*100);
        }
        return tuples;
    }

    static double Fitness(double[] position, Dictionary<double, double> checkPoints) 
        => checkPoints.Average(x => Math.Abs(x.Value - F(x.Key, position)));

    static double F(double x, double[] coefficients) =>
        coefficients[0] * Math.Pow(x, 2) 
        + coefficients[1] * x 
        + coefficients[2] * Math.Sin(x) 
        + coefficients[3] * Math.Cos(x) 
        + coefficients[4] * Math.Tan(x) 
        + coefficients[5] * Math.Log2(x) 
        + coefficients[6] * Math.Sqrt(x);

}