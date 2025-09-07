using Godot;

[GlobalClass, Tool]
public partial class CardData : Resource
{
    [Export]
    public int CardID { get; set; }

    [Export]
	public string CardName { get; set; }

    public CardData() { }
}
