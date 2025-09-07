using Godot;

// player's deck of cards
public partial class Deck : CardZone
{
    [Signal]
    public delegate void RequestReshuffleEventHandler(Deck deck);

    [Signal]
    public delegate void CardDrawnEventHandler(Card card);

    [Signal]
    public delegate void ShuffleEventHandler();

    [Signal]
    public delegate void MillCardEventHandler(Card card);

    public void Initialize(DeckData deckData)
    {
        foreach (var cardData in deckData.Cards)
        {
            var card = CardManager.Instance.BuildCard(cardData);
            card.FlipCard(false);
            AddCard(card);
        }
    }

    public override int AddCard(Card c)
    {
        // flip down when added to deck
        var count = base.AddCard(c);
        c.FlipCard(false);
        return count;
    }

    public void DrawCards(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            // flip up when drawn
            Card c = this.GetCard();
            c.FlipCard(true);
            EmitSignal(SignalName.CardDrawn, c);
        }
    }
}
