using Godot;
using Pong;
using System;

public partial class Enemy : Paddle
{
	private Ball ball;
	private CollisionShape2D shape;

	private const float initialBallThirst = 0.001f;
	private const float maxBallThirst = 10f;
	private const float ballThirst_maxGain = maxBallThirst - initialBallThirst;
	private float ballThirst = initialBallThirst;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ball = this.GetParent().GetNode<Ball>("Ball");
		shape = this.GetNode<CollisionShape2D>("EnemyShape");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var _delta = (float)delta;

		var ballAttraction = Math.Min(1, Math.Max(-1, (this.Position.Y - ball.Position.Y) * this.ballThirst));

		this.Move(Vector2.Up  * ballAttraction, _delta);
	}

	private void OnEnemyHurt(int score)
	{
		ballThirst = initialBallThirst + ballThirst_maxGain * ((5 - score) / 5);
	}
}
