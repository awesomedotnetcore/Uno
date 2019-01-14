using System;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Uno.UI.Samples.Controls;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

#if NETFX_CORE

namespace System
{
	public static class DEBUG
	{
		public static void Trace(string message = null, [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
			=> Console.WriteLine($"{method}@{line}: {message}");
	}
}
#endif

namespace SamplesApp.Wasm.Windows_UI_Xaml_Media.Transform
{
	[SampleControlInfo("Transform", "Border_With_CompositeTransform")]
	public sealed partial class Border_With_CompositeTransform : UserControl
	{
		public Border_With_CompositeTransform()
		{
			this.InitializeComponent();

			//Loaded += (snd, e) =>
			//{
			//	DEBUG.Trace();
			//	try
			//	{

			//		AnimateRed();
			//		AnimateOrange();
			//		AnimateYellow();
			//		AnimateGreen();
			//		AnimateBlue();
			//		AnimatePurple();

			//		DEBUG.Trace("Animations started");
			//	}
			//	catch (Exception error)
			//	{
			//		Console.Error.WriteLine("Animation star failed: " + error);
			//	}
			//};
		}

		//private void AnimateRed()
		//	=> new DoubleAnimation
		//	{
		//		From = 0,
		//		To = 360,
		//		Duration = new Duration(TimeSpan.Parse("0:0:10")),
		//		RepeatBehavior = RepeatBehavior.Forever
		//	}.Animate(RedRotate, nameof(RedRotate.Angle));

		//private void AnimateOrange()
		//	=> new DoubleAnimation
		//		{
		//			From = -150,
		//			To = 0,
		//			Duration = new Duration(TimeSpan.Parse("0:0:2")),
		//			RepeatBehavior = RepeatBehavior.Forever
		//		}
		//		.Animate(OrangeTranslate, nameof(OrangeTranslate.Y));

		//private void AnimateYellow()
		//	=> new DoubleAnimation
		//		{
		//			From = 0,
		//			To = 180,
		//			Duration = new Duration(TimeSpan.Parse("0:0:5")),
		//			RepeatBehavior = RepeatBehavior.Forever
		//		}
		//		.Animate(YellowSkew, nameof(YellowSkew.AngleX));


		//private void AnimateGreen()
		//	=> new Storyboard()
		//		.Add(new DoubleAnimation
		//			{
		//				From = .8,
		//				To = 1.2,
		//				Duration = new Duration(TimeSpan.Parse("0:0:1")),
		//				AutoReverse = true,
		//				RepeatBehavior = RepeatBehavior.Forever
		//			},
		//			GreenScale,
		//			nameof(GreenScale.ScaleX))
		//		.Add(new DoubleAnimation
		//			{
		//				From = .8,
		//				To = 1.2,
		//				Duration = new Duration(TimeSpan.Parse("0:0:1")),
		//				AutoReverse = true,
		//				RepeatBehavior = RepeatBehavior.Forever
		//			},
		//			GreenScale,
		//			nameof(GreenScale.ScaleY))
		//		.Begin();


		//private void AnimateBlue()
		//	=> new Storyboard()
		//		.Add(new DoubleAnimation
		//			{
		//				From = 0,
		//				To = 360,
		//				Duration = new Duration(TimeSpan.Parse("0:0:1")),
		//				RepeatBehavior = RepeatBehavior.Forever
		//			},
		//			BlueComposite,
		//			nameof(BlueComposite.Rotation))
		//		.Add(new DoubleAnimation
		//			{
		//				From = 0,
		//				To = 50,
		//				Duration = new Duration(TimeSpan.Parse("0:0:1")),
		//				AutoReverse = true,
		//				RepeatBehavior = RepeatBehavior.Forever
		//			},
		//			BlueComposite,
		//			nameof(BlueComposite.TranslateX))
		//		.Add(new DoubleAnimation
		//			{
		//				From = 0,
		//				To = 50,
		//				Duration = new Duration(TimeSpan.Parse("0:0:1")),
		//				AutoReverse = true,
		//				RepeatBehavior = RepeatBehavior.Forever
		//			},
		//			BlueComposite,
		//			nameof(BlueComposite.TranslateY))
		//		.Begin();

		//private void AnimatePurple()
		//	=> new DoubleAnimation
		//		{
		//			From = 1,
		//			To = 0,
		//			Duration = new Duration(TimeSpan.Parse("0:0:4")),
		//			AutoReverse = true,
		//			RepeatBehavior = RepeatBehavior.Forever
		//		}
		//		.Animate(PurpleOpacity, nameof(PurpleOpacity.Opacity));

	}

	public static class StoryboardExtensions
	{
		public static void Animate(this Timeline animation, DependencyObject target, string targetProperty)
			=> animation.ToStoryboard(target, targetProperty).Begin();

		public static Storyboard ToStoryboard(this Timeline animation, DependencyObject target, string targetProperty)
		{
			Storyboard.SetTarget(animation, target);
			Storyboard.SetTargetProperty(animation, targetProperty);

			return new Storyboard
			{
				Children = { animation }
			};
		}

		public static Storyboard Add(this Storyboard storyboard, Timeline animation, DependencyObject target, string targetProperty)
		{
			Storyboard.SetTarget(animation, target);
			Storyboard.SetTargetProperty(animation, targetProperty);

			storyboard.Children.Add(animation);

			return storyboard;
		}
	}
}
