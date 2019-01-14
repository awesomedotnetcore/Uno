using CoreAnimation;
using Foundation;
using Uno.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using CoreGraphics;
using Windows.Foundation;
using Uno.UI;

namespace Windows.UI.Xaml.Media
{
	/// <summary>
	/// RotateTransform: iOS part
	/// </summary>
	public partial class RotateTransform
	{

		//partial void SetCenterY(DependencyPropertyChangedEventArgs args)
		//{
		//	// Don't update the internal value if the value is being animated.
		//	// The value is being animated by the platform itself.
		//	if (View != null && !(args.NewPrecedence == DependencyPropertyValuePrecedences.Animations && args.BypassesPropagation))
		//	{
		//		Update();
		//	}
		//}

		//partial void SetCenterX(DependencyPropertyChangedEventArgs args)
		//{
		//	// Don't update the internal value if the value is being animated.
		//	// The value is being animated by the platform itself.
		//	if (View != null && !(args.NewPrecedence == DependencyPropertyValuePrecedences.Animations && args.BypassesPropagation))
		//	{
		//		Update();
		//	}
		//}

		//partial void SetAngle(DependencyPropertyChangedEventArgs args)
		//{
		//	// Don't update the internal value if the value is being animated.
		//	// The value is being animated by the platform itself.
		//	if (View != null && !(args.NewPrecedence == DependencyPropertyValuePrecedences.Animations && args.BypassesPropagation))
		//	{
		//		Update();
		//	}
		//}


		//protected override void Update()
		//{
		//	if (View != null)
		//	{
		//		View.Transform = ToNativeTransform(GetViewSize(View));
		//	}

		//	base.Update();
		//}



		//protected override void OnAttachedToView()
		//{
		//	base.OnAttachedToView();

		//	SetNeedsUpdate();
		//}

		protected override void ApplyTo(UIView view, Point absoluteOrigin)
		{
			var abc = true;

			if (abc)
			{

				var pivotX = absoluteOrigin.X + CenterX;
				var pivotY = absoluteOrigin.Y + CenterY;

				var transform = CGAffineTransform.MakeTranslation((nfloat) pivotX, (nfloat) pivotY);
				transform = CGAffineTransform.Rotate(transform, (nfloat) MathEx.ToRadians(Angle));
				transform = CGAffineTransform.Translate(transform, -(nfloat) pivotX, -(nfloat) pivotY);

				view.Layer.AnchorPoint = CGPoint.Empty;
				view.Transform = transform;

			}
			else
			{
				base.ApplyTo(view, absoluteOrigin);
			}
		}
	}
}

