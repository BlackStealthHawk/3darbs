using Godot;

public partial class LessonDemo : Node
{
	public override void _Ready()
	{
		Participant anna = new Participant("Anna", 100);
		Participant janis = new Participant("Jānis", 80);
		anna.ApplyPenalty(30);
		GD.Print(anna.Name, ": ", anna.GetEnergy());
		GD.Print(janis.Name, ": ", janis.GetEnergy());
		anna.ApplyPenalty(100);
		GD.Print("Anna: ", anna.GetEnergy(), ", aktīva: ", anna.IsActive());
	}
}
