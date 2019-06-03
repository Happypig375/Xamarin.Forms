using System;

namespace Xamarin.Forms
{
	public class TappedEventArgs : EventArgs
	{
		public TappedEventArgs(object parameter, Point position)
		{
			Parameter = parameter;
			Position = position;
		}

		public object Parameter { get; }
		public Point Position { get; }
	}
}