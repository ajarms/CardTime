using Godot;

// player's hand of cards
public partial class Hand : CardZone
{
    /*
        Signals
    */
    [Signal]
    public delegate void PlayCardEventHandler(Card card);

    [Signal]
    public delegate void DiscardCardEventHandler(Card card);

    [Signal]
    public delegate void InscribeSigilEventHandler(Card[] cards);

    [Signal]
    public delegate void ReturnToDeckEventHandler(Card card);

    /*
        Signal Handlers
    */
    public void OnDeckCardDrawn(Card card) => AddCard(card);

    public void OnDiscardReturnToHand(Card card) => AddCard(card);
}
