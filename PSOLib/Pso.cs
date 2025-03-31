using System;
using System.Diagnostics;
using System.Timers;
using HKDXX6_PSO.PSOLib.Models;

namespace HKDXX6_PSO.PSOLib;

public class Pso
{
    public ParticleSwarm Swarm { get; init; }
    private readonly double _wOwn;
    private readonly double _wSwarm;
    private readonly Func<double[], double> _fitnessFunction;
    private readonly Stopwatch _stopwatch = new();
    private int _iter = 0;
    private int _lastUpdate = 0;
    
    public Pso(int dimensions, int numberOfParticles, Func<double[], double> fitnessFunction, double wOwn, double wSwarm, Random? random = null)
    {
        random ??= Random.Shared;
        
        Swarm = new ParticleSwarm(dimensions);
        _fitnessFunction = fitnessFunction;
        _wOwn = wOwn;
        _wSwarm = wSwarm;

        for (var i = 0; i < numberOfParticles; i++)
        {
            Swarm.Particles.Add(Particle.FromRandom(dimensions, random));
        }
        Swarm.GlobalBestPosition = Swarm.Particles.OrderBy(p => fitnessFunction(p.BestPosition))
            .First().BestPosition;
    }

    private TimeSpan _maxTime;
    private int _maxNoUpdateIter;
    private double _minFitness;
    public void Run(TimeSpan maxTime, int maxNoUpdateIter, double minFitness)
    {
        _maxTime = maxTime;
        _maxNoUpdateIter = maxNoUpdateIter;
        _minFitness = minFitness;
        
        _stopwatch.Start();   
        while (!StopCondition())
        {
            Swarm.MoveAll();
            var updated = Swarm.UpdateBestPositions(_fitnessFunction);
            if (updated) _lastUpdate = _iter;
            Swarm.UpdateVelocities(_wOwn, _wSwarm);
            _iter++;
        }
        _stopwatch.Stop();
        _stopwatch.Reset();
    }
    private bool StopCondition() => _fitnessFunction(Swarm.GlobalBestPosition) < _minFitness 
                                    || _iter - _lastUpdate >= _maxNoUpdateIter 
                                    || _stopwatch.Elapsed > _maxTime;
}