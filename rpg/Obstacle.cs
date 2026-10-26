using Godot;
using System;

[GlobalClass]
public partial class Obstacle : Node
{
	[Export]
	public string ObstacleName { get; set; } = "Rinda pie printera";

	private int penalty = 20;

	[Export(PropertyHint.Range, "1,50,1")]
	public int Penalty
	{
		get { return penalty; }
		set { penalty = Math.Max(1, value); }
	}

	public override void _Ready()
	{
		GD.Print(ObstacleName, ": sods ", Penalty);
	}
}
