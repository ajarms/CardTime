using Godot;

// play cards here
public partial class PlayArea : CardZone
{
    /*
        Signals
    */
    [Signal]
    public delegate void CardResolvedEventHandler(Card card);

    /*
        Signal Handlers
    */
    public void OnHandPlayCard(Card card)
    {
        AddCard(card);
        card.Resolve();
        EmitSignal(SignalName.CardResolved, card);
    }
}
