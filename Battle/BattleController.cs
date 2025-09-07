using Godot;

[GlobalClass]
public partial class BattleController : Control
{
    [Export]
    public Deck DeckNode { get; set; }

    public override void _Ready()
    {
        DeckNode.Initialize(PlayerManager.Instance.GetPlayerDeck());

        DeckNode.DrawCards(5);
    }
}
