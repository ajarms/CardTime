
using System;
using System.Collections.Generic;
using Godot;

// Base class for the turns of a battle
public abstract class Turn : TurnLog
{
    public abstract string Name { get; }

    public Phase[] Phases { get; private set; }

    private int phaseIndex;

    public Turn(Phase[] phases)
    {
        if (phases.Length == 0)
        {
            GD.PrintErr("Turn cannot be constructed with no phases!");
        }
        Phases = phases;
        phaseIndex = 0;
        LogMessage($"Turn: {Name}");
        LogStart();
    }

    public Phase CurrentPhase => Phases[phaseIndex];

    // Advance to and return the next Phase.
    // Return null if the turn is over.
    public Phase NextPhase()
    {
        phaseIndex++;
        if (phaseIndex >= Phases.Length)
        {
            // TODO this is technically spammable
            LogEnd();
            return null;
        }
        return CurrentPhase;
    }

    public override string GetLog()
    {
        // Turn log followed by indented phase logs
        var logMessage = base.GetLog();
        foreach (var p in Phases)
        {
            logMessage += $"\t{p.GetLog()}";
        }
        return logMessage;
    }
}

// Base class for the phases of a turn
public abstract class Phase : TurnLog
{
    public abstract string Name { get; }

    public void Play()
    {
        LogMessage($"Phase: {Name}");
        LogStart();
        PlayInternal();
        LogEnd();
    }

    protected virtual void PlayInternal()
    {
        // default phase execution, none!
    }

    // TODO could define IF and WHICH inputs a phase handles on an abstract property
    // or virtual defaulting to an empty array (vs an array of enums representing inputs)
    // That way, can wrap handle input in a function that will check this prop, and only
    // if input is handled, log it and pass it on

    public virtual void HandleInput(int PlaceholderInputKey)
    {
        // default input handling, no handling!
    }
}

// Base class for logging turns and phases
public abstract class TurnLog
{
    private List<string> log = new List<string>();

    public virtual string GetLog()
    {
        var logString = "";
        foreach (var msg in log)
        {
            logString += msg;
            logString += "\n";
        }
        return logString;
    }

    protected void LogStart()
    {
        log.Add($"End: {DateTime.UtcNow}");
    }

    protected void LogEnd()
    {
        log.Add($"End: {DateTime.UtcNow}");
    }

    protected void LogMessage(string msg)
    {
        log.Add(msg);
    }
}