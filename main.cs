using Godot;
using System;

public partial class main : Node2D
{
	private string QueuedScene = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (this.QueuedScene != null)
		{
			GetTree().ChangeSceneToFile("res://" + this.QueuedScene + ".tscn");
			this.QueuedScene = null;
		}
	}

	private void OnEnemyDied()
	{
		this.QueuedScene = "winner";
	}

	private void OnPlayerDied()
	{
		this.QueuedScene = "loser";
	}
}
