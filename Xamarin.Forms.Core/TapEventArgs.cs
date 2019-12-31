using System;

namespace Xamarin.Forms
{
	public class TapEventArgs : EventArgs
	{
		public TapEventArgs(object parameter, Point position = new Point())
		{
			Parameter = parameter;
			Position = position;
		}

		public object Parameter { get; }
		public Point Position { get; }
	}
}