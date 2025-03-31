using HKDXX6_PSO.PSOLib;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var n = 5;
        var pso = new Pso(n, n * 5, AckleyFitness, 1, 1.5, 500);
        pso.Run(TimeSpan.FromMinutes(1));
    }
    
    public static double AckleyFitness(double[] x)
    {
        int n = x.Length;
        double sum1 = 0.0;
        double sum2 = 0.0;
        
        for (int i = 0; i < n; i++)
        {
            sum1 += x[i] * x[i];
            sum2 += Math.Cos(2 * Math.PI * x[i]);
        }
        
        double term1 = -20.0 * Math.Exp(-0.2 * Math.Sqrt(sum1 / n));
        double term2 = -Math.Exp(sum2 / n);
        
        return term1 + term2 + 20 + Math.E;
    }
}