using Godot;
using System;
using System.Collections.Generic;

public partial class Participant : Node
{
	[Signal]
	public delegate void FinishedEventHandler(string participantName);

	public string ParticipantName = "Dalībnieks";
	private Stats stats = new Stats(100, 10);
	private readonly List<Buff> buffs = new List<Buff>();

	public void Setup(string name, int initialEnergy)
	{
		ParticipantName = name;
		stats.Energy = Math.Max(0, initialEnergy);
	}

	public virtual void ApplyPenalty(int amount)
	{
		if (!IsActive() || amount <= 0) return;
		stats.Energy = Math.Max(0, stats.Energy - amount);
		if (stats.Energy == 0)
			EmitSignal(SignalName.Finished, ParticipantName);
	}

	public int GetEnergy()
	{
		return stats.Energy;
	}

	public Stats GetStats()
	{
		return stats;
	}

	public void Heal(int amount)
	{
		if (!IsActive()) return;
		stats.Heal(amount);
	}

	public bool IsActive()
	{
		return stats.Energy > 0;
	}

	public void AddBuff(Buff buff)
	{
		buffs.Add(buff);
	}

	public int GetTotalFocus()
	{
		int total = stats.Focus;
		foreach (Buff buff in buffs)
		{
			total += buff.FocusBonus;
		}
		return total;
	}
}
