using System.Collections.Generic;
using Godot;

[GlobalClass]
public partial class BattleController : Control
{
    [Export]
    public Deck DeckNode { get; set; }

    private List<Turn> Turns = null;

    private Phase CurrentPhase = null;

    public override void _Ready()
    {
        DeckNode.Initialize(PlayerManager.Instance.GetPlayerDeck());

        DeckNode.DrawCards(5);
    }

    // TODO user input
}
