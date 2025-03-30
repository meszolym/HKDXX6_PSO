namespace HKDXX6_PSO.Models;

public class ParticleSwarm(int dimensions)
{
    public List<Particle> Particles { get; set; } = [];
    public double[] GlobalBestPosition { get; set; } = new double[dimensions];

    public void MoveAll() => Particles.ForEach(p => p.Move());
    public void UpdateBestPositions(Func<double[], double> fitnessFunction)
    {
        foreach (var particle in Particles)
        {
            var isUpdated = particle.UpdateBestPosition(fitnessFunction);
            if (isUpdated)
            {
                var fitness = fitnessFunction(particle.BestPosition);
                if (fitness < fitnessFunction(GlobalBestPosition))
                {
                    GlobalBestPosition = particle.BestPosition;
                }
            }
        }
    }
    
    public void UpdateVelocities(double wOwn, double wSwarm, Random? random = null)
    {
        foreach (var particle in Particles)
        {
            particle.UpdateVelocity(GlobalBestPosition, wOwn, wSwarm, random);
        }
    }
}