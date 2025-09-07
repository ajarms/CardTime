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

	public Card() {
		Data = new CardData();
	}

	public void Initialize(CardData data)
	{
		Data = data;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		NameLabel.Text = Data?.CardName ?? "Test";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void FlipCard(bool up)
	{
		CardFront.Visible = up;
		CardBack.Visible = !up;
	}
}
