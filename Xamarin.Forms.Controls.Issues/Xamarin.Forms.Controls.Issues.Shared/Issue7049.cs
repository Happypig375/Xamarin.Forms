﻿using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

#if UITEST
using NUnit.Framework;
using Xamarin.UITest;
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve (AllMembers=true)]
	[Issue (IssueTracker.Github, 7049, "Null reference exception on some Android devices - Xamarin.Forms.Platform.Android.PageRenderer.Xamarin.Forms.Platform.Android.IOrderedTraversalController.UpdateTraversalOrder", PlatformAffected.Android)]
	public class Issue7049 : TestContentPage
	{
		private bool _flag = true;

		protected override void Init()
		{

			var button = new Button { Text = "Continue" };
			button.Clicked += (_, __) =>
			{
				var view = _flag ?
					(View)new Entry { AutomationId = "View2", Text = "Press 1 time to crash" } :
					new Label { AutomationId = "View3", Text = "I'm shown, bug fixed!" };
				_flag ^= true;
				(Content as StackLayout).Children[1] = view;
			};
			Content = new StackLayout
			{
				Children =
				{
					button,
					new Label { AutomationId = "View1", Text = "Press 2 times to crash" }
				}
			};
		}

#if UITEST
		[Test]
		[Description ("Test null reference in IOrderedTraversalController.UpdateTraversalOrder of Android PageRenderer")]
		public void Issue7049TestsNullRefInUpdateTraversalOrder()
		{
			RunningApp.WaitForElement ("View1");
			RunningApp.Tap ("View1");
			RunningApp.WaitForElement("View2");
			RunningApp.Tap("View2");
			RunningApp.WaitForElement("View3");
			RunningApp.Tap("View3");
		}
#endif
	}
}
