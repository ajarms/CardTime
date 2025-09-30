using System.Collections.Generic;
using Godot;

[GlobalClass]
public partial class BattleController : Control
{
    [Export]
    public Deck DeckNode { get; set; }

    private List<Turn> Turns = null;

    private Phase currentPhase = null;

    public override void _Ready()
    {
<<<<<<< HEAD
        StartGame();
    }

    public void StartGame()
    {
=======
        Turns = new List<Turn>();
>>>>>>> df8d74578ddde9cbc23c087b453390decfa96049
        DeckNode.Initialize(PlayerManager.Instance.GetPlayerDeck());
        DeckNode.DrawCards(5);
        
        // begin turn sequence
    }

    // BattleController can listen for all inputs and pass them along to the currently executing
    // turn phase.  The phase will decide what to do, if anything, with the input.
    public void OnUserInput(int PlaceholderInputKey)
    {
        currentPhase?.HandleInput(PlaceholderInputKey);
    }

    public void StartBattle()
    {
        // TODO pre-turn logging?
        DeckNode.Initialize(PlayerManager.Instance.GetPlayerDeck());
        DeckNode.DrawCards(5);
        Turns.Add(new PlayerTurn());
        PlayTurn();
    }

    private void PlayTurn()
    {
        var turn = Turns[-1];
        currentPhase = turn.CurrentPhase;
        while (currentPhase != null)
        {
            currentPhase.Play();
            currentPhase = turn.NextPhase();
        }
        // Turn is over; add another turn and keep going
        // alternate between PlayerTurn and EnemyTurn        
    }
}
