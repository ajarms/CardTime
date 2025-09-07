using Godot;

// player's deck of cards
public partial class Deck : CardZone
{
    /*
        Signals
    */
    [Signal]
    public delegate void EmptiedEventHandler(Deck deck);

    [Signal]
    public delegate void CardDrawnEventHandler(Card card);

    [Signal]
    public delegate void ShuffleEventHandler();

    [Signal]
    public delegate void MillCardEventHandler(Card card);

    /*
        Signal Handlers
    */
    public void OnDiscardReturnToDeck(Card card) => AddCard(card);

    public void OnHandReturnToDeck(Card card) => AddCard(card);

    /*
        Functions
    */
    public void Initialize(DeckData deckData)
    {
        foreach (var cardData in deckData.Cards)
        {
            var card = CardManager.Instance.BuildCard(cardData);
            card.FlipCard(false);
            AddCard(card);
        }
    }

    // Override to add cards face-down
    public override int AddCard(Card c)
    {
        var count = base.AddCard(c);
        c.FlipCard(false);
        return count;
    }

    public void ShuffleDeck()
    {
        cardContainer.GetChildren().Shuffle();
        EmitSignal(SignalName.Shuffle);
        if (waitingDraws > 0)
        {
            DrawCards(waitingDraws);
            waitingDraws = 0;
        }
    }

    private int waitingDraws = 0;
    public void DrawCards(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            if (Empty)
            {
                // signal and wait for shuffle
                EmitSignal(SignalName.Emptied, this);
                waitingDraws = count - i;
                return;
            }
            
            // flip up when drawn
            Card c = GetCard();
            c.FlipCard(true);
            EmitSignal(SignalName.CardDrawn, c);
        }
    }
    
    public void MillCards(int count = 1)
    {
        for (int i = 0; i < count; i++)
        {
            var c = GetCard();
            c.FlipCard(true);
            EmitSignal(SignalName.MillCard, c);
        }
    }
}
