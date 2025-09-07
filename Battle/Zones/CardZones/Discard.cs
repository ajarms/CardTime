using Godot;

// player's discard pile
public partial class Discard : CardZone
{
    [Signal]
    public delegate void ReturnToHandEventHandler(Card card);

    [Signal]
    public delegate void ReturnToDeckEventHandler(Card card);
}
