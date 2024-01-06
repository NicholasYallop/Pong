using Godot;

namespace Pong
{
	public abstract partial class LivesDisplay : Label
	{
		private int _lives = 5;

		public int Lives
		{
			get
			{
				return _lives;
			}
			set
			{
				_lives = value;
				this.Text = _lives.ToString();
			}
		}

	}
}
