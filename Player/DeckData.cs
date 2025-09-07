using Godot;

[GlobalClass, Tool]
public partial class DeckData : Resource
{
    [Export]
    public int[] Cards { get; set; }

    public DeckData() { }
}