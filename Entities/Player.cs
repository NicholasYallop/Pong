using Godot;
using Pong;
using System;

public partial class Player : Paddle
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var _delta = (float)delta;
		if (Input.IsKeyPressed(Key.Up))
		{
			this.Move(Vector2.Up, _delta);
		}
		else if (Input.IsKeyPressed(Key.Down))
		{
			this.Move(Vector2.Down, _delta);
		}
	}
}
