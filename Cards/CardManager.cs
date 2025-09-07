using Godot;
using System.Collections.Generic;

// Autoload singleton, manages CardData resources and Card instantiation
public partial class CardManager : Node
{
    private static readonly PackedScene CARD_SCENE = GD.Load<PackedScene>("res://Cards/card.tscn");
    private static readonly Json CARD_MANIFEST = GD.Load<Json>("res://Cards/CardData/cardManifest.json");

    public static CardManager Instance { get; private set; }

    private Dictionary<int, CardData> cards;

    public CardManager()
    {
        cards = new Dictionary<int, CardData>();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            GD.PrintErr("CardManager: multiple instances!");
        }
    }

    public override void _Ready()
    {
        // load all card data resources listed in manifest
        foreach (int id in CARD_MANIFEST.Data.AsInt32Array())
        {
            cards.Add(id, GD.Load<CardData>("res://Cards/CardData/" + id + ".tres"));
        }
        GD.Print($"CardManager ready");
    }

    public CardData GetCardData(int cardID)
    {
        if (!cards.ContainsKey(cardID))
        {
            GD.PrintErr($"CardManager: no card with ID {cardID}");
            return null;
        }
        return cards[cardID];
    }

    // Creates a Card Node with requested CardData
    // Node is orphaned and will need to added by caller
    public Card BuildCard(int cardID)
    {
        if (!cards.ContainsKey(cardID))
        {
            GD.PrintErr($"CardManager: no card with ID {cardID}");
            return null;
        }
        var card = (Card)CARD_SCENE.Instantiate();
        card.Initialize(cards[cardID]);
        return card;
    }
}
