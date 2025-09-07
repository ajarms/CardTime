using Godot;

[GlobalClass]
public partial class Card : Control
{
	public CardData Data { get; private set; } = null;

	[Export]
	public Container CardFront { get; set; }

	[Export]
	public Container CardBack { get; set; }

	[Export]
	public Label NameLabel { get; set; }

	public Card()
	{
		Data = new CardData();
	}

	public void Initialize(CardData data)
	{
		Data = data;
	}

	public override void _Ready()
	{
		NameLabel.Text = Data?.CardName ?? "Test";
	}

	public void FlipCard(bool up)
	{
		CardFront.Visible = up;
		CardBack.Visible = !up;
	}

	public void Resolve()
	{
		GD.Print($"Resolving {Data.CardName}");
	}
}
