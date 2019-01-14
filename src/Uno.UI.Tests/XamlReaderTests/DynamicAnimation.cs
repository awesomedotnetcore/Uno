using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace Uno.UI.Demo.Behaviors
{
	public static class DynamicAnimation
    {
		public static readonly DependencyProperty StoryboardProperty = DependencyProperty.RegisterAttached(
			"Storyboard", typeof(Storyboard), typeof(DependencyObject), new PropertyMetadata(default(Storyboard), OnStoryBoardChanged));

		private static void OnStoryBoardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Console.Error.WriteLine("Got new storyboard: " + e.NewValue);

			(e.OldValue as Storyboard)?.Stop();
			if (e.NewValue is Storyboard storyboard)
			{
				foreach (var timeline in storyboard.Children)
				{
					Storyboard.SetTarget(timeline, d);
				}

				try
				{
					Console.Error.WriteLine("Starting storyboard: " + e.NewValue);
					storyboard.Begin();
					Console.Error.WriteLine("Storyboard started: " + e.NewValue);
				}
				catch (Exception err)
				{
					Console.Error.WriteLine("Failed to start storyboard: " + err);
				}
			}
		}

		public static Storyboard GetStoryboard(DependencyObject target)
			=> (Storyboard) target.GetValue(StoryboardProperty);

		public static void SetStoryboard(DependencyObject target, Storyboard value)
			=> target.SetValue(StoryboardProperty, value);
	}
}
