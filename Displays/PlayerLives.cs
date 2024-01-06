using Godot;
using Pong;

public partial class PlayerLives : LivesDisplay
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnLeftOOB(Area2D arg)
	{
		if (arg.Name == "Ball")
		{
			this.Lives -= 1;
			this.EmitSignal(SignalName.PlayerHurt, this.Lives);
			if (this.Lives <= 0)
			{
				this.EmitSignal(SignalName.PlayerDied);
			}
		}
	}

	[Signal]
	public delegate void PlayerHurtEventHandler(int lives);

	[Signal]
	public delegate void PlayerDiedEventHandler();
}
