using Godot;
using System;
using System.Security.Cryptography;

public partial class Ball : Area2D
{
	private Random randomiser;
	private Vector2 velocity = Vector2.Zero;
	private Vector2 respawnPoint;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		randomiser = new Random();
		velocity = Vector2.Left * 400;

		respawnPoint = this.Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var _delta = (float)delta;

		this.Position += this.velocity * _delta;
	}

	#region signals
	private void OnPaddleEntered(Area2D arg)
	{
		if (arg.Name == this.Name)
		{
			var rand = randomiser.Next(10);
			this.velocity = this.velocity.Rotated((1 + rand / 50f) * (float)Math.PI);

			var speedSquared = this.velocity.LengthSquared();
			var rightSpeed = this.velocity.Dot(Vector2.Right);
			if (rightSpeed * rightSpeed < speedSquared * 2 / 3)
			{
				this.velocity = this.velocity.X > 0
								? Vector2.Right * this.velocity.Length()
								: Vector2.Left * this.velocity.Length();
			}
		}
	}

	private void OnVerticalOOB(Area2D arg)
	{
		if (arg.Name == this.Name)
		{
			var newVelocity = this.velocity;
			newVelocity.Y = -newVelocity.Y;
			this.velocity = newVelocity;
		}
	}

	private void OnHorizontalOOB(Area2D arg)
	{
		if (arg.Name == this.Name)
		{
			this.Respawn();
		}
	}
	#endregion signals

	#region helpers
	private void Respawn()
	{
		this.Position = respawnPoint;
		this.velocity = Vector2.Left * 400;
	}
	#endregion helpers
}
