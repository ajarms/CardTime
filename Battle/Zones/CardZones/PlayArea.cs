using Godot;

// play cards here
public partial class PlayArea : CardZone
{
    [Signal]
    public delegate void CardResolvedEventHandler(Card card);
}
