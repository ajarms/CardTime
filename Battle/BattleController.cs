using Godot;

[GlobalClass]
public partial class BattleController : Control
{
    [Export]
    public Deck DeckNode { get; set; }

    public override void _Ready()
    {
        StartGame();
    }

    public void StartGame()
    {
        DeckNode.Initialize(PlayerManager.Instance.GetPlayerDeck());

        DeckNode.DrawCards(5);
        
        // begin turn sequence
    }

    // TODO user input
}
