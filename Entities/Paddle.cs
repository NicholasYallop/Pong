using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
	public partial class Paddle : Area2D
	{
		public bool IsAgainstBottomEdge = false;
		public bool IsAgainstTopEdge = false;
		public const float paddleSpeed = 400;

		private void OnTopOOB(Area2D arg)
		{

			if (arg.Name == this.Name)
			{
				IsAgainstTopEdge = true;
			}
		}
		private void OnLeavingTopOOB(Area2D arg)
		{
			if (arg.Name == this.Name)
			{
				IsAgainstTopEdge = false;
			}
		}
		private void OnBottomOOB(Area2D arg)
		{
			if (arg.Name == this.Name)
			{
				IsAgainstBottomEdge = true;
			}
		}
		private void OnLeavingBottomOOB(Area2D arg)
		{
			if (arg.Name == this.Name)
			{
				IsAgainstBottomEdge = false;
			}
		}

		public Vector2 Move(Vector2 velocity, float frameDelta)
		{
			if (IsAgainstTopEdge)
			{
				velocity.Y = Math.Max(velocity.Y, 0);
			}
			if (IsAgainstBottomEdge)
			{
				velocity.Y = Math.Min(0, velocity.Y);
			}

			this.Position += velocity * frameDelta * paddleSpeed;
			return velocity;
		}
	}
}
