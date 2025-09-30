
public class PlayerTurn : Turn
{
    public override string Name => "Player";

    public PlayerTurn() : base(new Phase[] {
        new StartPhase(),
        new DrawPhase(),
        new MainPhase() })
    { }
}

public class StartPhase : Phase
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