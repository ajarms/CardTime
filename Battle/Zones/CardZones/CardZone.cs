using Godot;

// Base class for card zones like hand, deck, etc
[GlobalClass]
public abstract partial class CardZone : Control
{
    [Export]
    protected Container cardContainer = null;

    public bool Empty => cardContainer.GetChildCount() == 0;

    public virtual int AddCard(Card c)
    {
        if (c.GetParent() == null)
        {
            cardContainer.AddChild(c);
        }
        else
        {
            c.Reparent(cardContainer);
        }
        return cardContainer.GetChildCount();
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
