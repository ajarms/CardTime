
using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

public class Turn
{
    public List<Phase> Phases { get; private set; }

    private Phase currentPhase = null;

    public Turn(List<Phase> phases)
    {
        Phases = phases;
        currentPhase = Phases.First();
    }
}

public abstract class Phase
{
    public abstract string Name { get; }

    public virtual void DoPhase()
    {
        // default phase execution, none!
    }

    public virtual void HandleInput(int PlaceholderInputKey)
    {
        // default input handling, no handling!
    }
}