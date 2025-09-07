using Godot;

// player's hand of cards
public partial class Hand : CardZone
{
    [Signal]
    public delegate void PlayCardEventHandler(Card card);

    [Signal]
    public delegate void DiscardCardEventHandler(Card card);

    [Signal]
    public delegate void InscribeSigilEventHandler(Card c1, Card c2, Card c3 = null, Card c4 = null, Card c5 = null, Card c6 = null);

    [Signal]
    public delegate void ReturnToDeckEventHandler(Card card);

    public void OnDeckCardDrawn(Card card)
    {
        AddCard(card);
    }
}
