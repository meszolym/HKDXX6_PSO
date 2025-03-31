using System;
using System.Collections.Generic;

namespace HKDXX6_PSO.PSOLib.Models;

public class ParticleSwarm(int dimensions)
{
    public List<Particle> Particles { get; set; } = [];
    public double[] GlobalBestPosition { get; set; } = new double[dimensions];

    public void MoveAll() => Particles.ForEach(p => p.Move());
    public bool UpdateBestPositions(Func<double[], double> fitnessFunction)
    {
        var updated = false;
        foreach (var particle in Particles)
        {
            particle.UpdateBestPosition(fitnessFunction);

            var fitness = fitnessFunction(particle.BestPosition);
            if (fitness < fitnessFunction(GlobalBestPosition))
            {
                GlobalBestPosition = (double[]) particle.BestPosition.Clone();
                updated = true;
            }
        }
        return updated;
    }
    
    public void UpdateVelocities(double wOwn, double wSwarm, Random? random = null)
    {
        foreach (var particle in Particles)
        {
            particle.UpdateVelocity(GlobalBestPosition, wOwn, wSwarm, random);
        }
    }
}