
using System.Collections.Generic;

public class PlayerTurn : Turn
{

    public PlayerTurn() : base(new List<Phase> {
        new StartTurnPhase(),
        new DrawPhase(),
        new MainPhase() })
    { }
}

public class StartTurnPhase : Phase
{
    public override string Name => "Start";
}

public class DrawPhase : Phase
{
    public override string Name => "Draw";
}

public class MainPhase : Phase
{
    public override string Name => "Main";
}