using Godot;
using Pong;
using System;

public partial class EnemyLives : LivesDisplay
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnRightOOB(Area2D arg)
	{
		if (arg.Name == "Ball")
		{
			this.Lives -= 1;
			this.EmitSignal(SignalName.EnemyHurt, this.Lives);
			if (this.Lives <= 0)
			{
				this.EmitSignal(SignalName.EnemyDied);
			}
		}
	}

	[Signal]
	public delegate void EnemyHurtEventHandler(int lives);

	[Signal]
	public delegate void EnemyDiedEventHandler();
}
