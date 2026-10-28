using Godot;

public partial class StatsDemo : Node2D
{
	public override void _Ready()
	{
		Stats defaultStats = new Stats();
		GD.Print("Default stats: Energy=", defaultStats.Energy,
			", MaxEnergy=", defaultStats.MaxEnergy,
			", Focus=", defaultStats.Focus);

		Stats initializedStats = new Stats(100, 10);
		GD.Print("Initialized stats: Energy=", initializedStats.Energy,
			", MaxEnergy=", initializedStats.MaxEnergy,
			", Focus=", initializedStats.Focus);

		Participant anna = GetNode<Participant>("Anna");
		anna.Setup("Anna", 100);
		anna.ApplyPenalty(30);
		anna.Heal(50);
		GD.Print(anna.GetEnergy());

		Stats statsCopy = anna.GetStats();
		statsCopy.Energy = 1;
		GD.Print("Copy Energy=", statsCopy.Energy,
			", Anna Energy=", anna.GetEnergy());

		anna.AddBuff(new Buff { Name = "Atbalsts", FocusBonus = 5 });
		anna.AddBuff(new Buff { Name = "Atpūta", FocusBonus = 3 });
		GD.Print("Total Focus=", anna.GetTotalFocus());
		GD.Print("Total Focus=", anna.GetTotalFocus());
	}
}
