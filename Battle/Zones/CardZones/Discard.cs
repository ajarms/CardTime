using Godot;

// player's discard pile
public partial class Discard : CardZone
{
    /*
        Signals
    */
    [Signal]
    public delegate void ReturnToHandEventHandler(Card card);

    [Signal]
    public delegate void ReturnToDeckEventHandler(Card card);

    /*
        Signal Handlers
    */
    public void OnDeckEmptied(Deck deck)
    {
        while (cardContainer.GetChildCount() > 0)
        {
            deck.AddCard(GetCard(-1));
        }
        deck.ShuffleDeck();
    }

    public void OnPlayAreaCardResolved(Card card) => AddCard(card);

    public void OnHandDiscardCard(Card card) => AddCard(card);

    public void OnDeckMillCard(Card card) => AddCard(card);
}
