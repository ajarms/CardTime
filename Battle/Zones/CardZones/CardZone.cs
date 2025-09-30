using System.Threading;
using Godot;

// Base class for card zones like hand, deck, etc
[GlobalClass]
public abstract partial class CardZone : Control
{
    [Export]
    protected Container cardContainer = null;

    public int Count => cardContainer?.GetChildCount() ?? 0;
    public bool Empty => Count == 0;

    public override void _Ready()
    {
        if (cardContainer == null)
        {
            GD.PrintErr($"{this.GetType()} card container not configured in scene tree.");
        }
    }

    public virtual void AddCard(Card c)
    {
        // Thread.Sleep(100);
        if (c.GetParent() == null)
        {
            cardContainer.AddChild(c);
        }
        else
        {
            c.Reparent(cardContainer);
        }
    }

    public virtual Card GetCard(int index = 0)
    {
        if (Empty || index >= cardContainer.GetChildCount())
        {
            return null;
        }
        
        // support negative index
        if (index < 0)
        {
            index += cardContainer.GetChildCount();
        }
        var c = (Card)cardContainer.GetChild(index);
        return c;
    }
}
