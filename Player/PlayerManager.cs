using Godot;

// Autoload singleton
public partial class PlayerManager : Node
{
    public static readonly DeckData STARTER_DECK = GD.Load<DeckData>("res://Player/starterDeck.tres");

    public static PlayerManager Instance { get; private set; } = null;

    private DeckData playerDeck = null;

    public PlayerManager()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            GD.PrintErr("PlayerManager: multiple instances!");
        }
    }

    public override void _Ready()
    {
        GD.Print("PlayerManager ready");
    }

    public DeckData GetPlayerDeck()
    {
        if (playerDeck == null)
        {
            playerDeck = STARTER_DECK;
        }
        return playerDeck;
    }
}
