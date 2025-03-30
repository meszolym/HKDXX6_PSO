using HKDXX6_PSO.Models;

namespace HKDXX6_PSO;

public class Pso
{
    public ParticleSwarm Swarm { get; init; }
    private double _wOwn = 0.5;
    private double _wSwarm = 0.5;
    private readonly Func<double[], double> _fitnessFunction;
    
    public Pso(int dimensions, int numberOfParticles, Func<double[], double> fitnessFunction, Random? random = null)
    {
        random ??= Random.Shared;
        
        Swarm = new ParticleSwarm(dimensions);
        _fitnessFunction = fitnessFunction;
        
        for (var i = 0; i < numberOfParticles; i++)
        {
            Swarm.Particles.Add(Particle.FromRandom(dimensions, random));
        }
        Swarm.GlobalBestPosition = Swarm.Particles[0].BestPosition;
        
        
    }

    public void Run()
    {
        while (!StopCondition())
        {
            Swarm.MoveAll();
            Swarm.UpdateBestPositions(_fitnessFunction);
            Swarm.UpdateVelocities(_wOwn, _wSwarm);
        }
    }
    
    public bool StopCondition() => _fitnessFunction(Swarm.GlobalBestPosition) < 0.01;
}