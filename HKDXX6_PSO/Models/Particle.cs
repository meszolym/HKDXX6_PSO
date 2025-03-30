namespace HKDXX6_PSO.Models;

public class Particle(int dimensions)
{
    private readonly double[] _position = new double[dimensions];
    private readonly double[] _velocity = new double[dimensions];
    public double[] BestPosition { get; private set; } = new double[dimensions];

    public static Particle FromRandom(int dimensions, Random? random = null)
    {
        random ??= Random.Shared;
        var particle = new Particle(dimensions);
        for (var i = 0; i < particle._position.Length; i++)
        {
            particle._position[i] = random.NextDouble() * 100;
            particle._velocity[i] = random.NextDouble() * 10;
            particle.BestPosition[i] = particle._position[i];
        }
        return particle;
    }
    
    public void Move()
    {
        for (var i = 0; i < dimensions; i++)
        {
            _position[i] += _velocity[i];
        }
    }
    
    public bool UpdateBestPosition(Func<double[], double> fitnessFunction)
    {
        if (fitnessFunction(_position) >= fitnessFunction(BestPosition)) return false;
        
        BestPosition = _position;
        return true;
    }

    public void UpdateVelocity(double[] swarmBestPosition, double wOwn, double wSwarm, Random? random = null)
    {
        random ??= Random.Shared;
        for (var i = 0; i < dimensions; i++)
        {
            _velocity[i] = _velocity[i] 
                          + random.NextDouble() * wOwn * (BestPosition[i]- _position[i])
                          + random.NextDouble() * wSwarm * (swarmBestPosition[i] - _position[i]);
        }
    }
}