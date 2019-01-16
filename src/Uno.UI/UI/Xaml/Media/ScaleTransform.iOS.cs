using CoreAnimation;
using Foundation;
using Uno.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using UIKit;
using CoreGraphics;

namespace Windows.UI.Xaml.Media
{
	/// <summary>
	/// ScaleTransform: iOS part
	/// </summary>
	public partial class ScaleTransform
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

		//partial void SetScaleX(DependencyPropertyChangedEventArgs args)
		//{
		//	// Don't update the internal value if the value is being animated.
		//	// The value is being animated by the platform itself.
		//	if (View != null && !(args.NewPrecedence == DependencyPropertyValuePrecedences.Animations && args.BypassesPropagation))
		//	{
		//		Update();
		//	}
		//}

		//partial void SetScaleY(DependencyPropertyChangedEventArgs args)
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
		//		DoScale();
		//	}

		//	base.Update();
		//}

		//private void DoScale()
		//{
		//	this.View.Transform = ToNativeTransform(GetViewSize(View));
		//}


		//protected override void OnAttachedToView()
		//{
		//	base.OnAttachedToView();

		//	SetNeedsUpdate();
		//}

		//protected override void ApplyTo(UIView view, Point absoluteOrigin)
		//{
		//	var pivotX = absoluteOrigin.X + CenterX;
		//	var pivotY = absoluteOrigin.Y + CenterY;

		//	var transform = CGAffineTransform.MakeIdentity();

		//	//Perform transformations about centre
		//	transform = CGAffineTransform.Translate(transform, (nfloat)pivotX, (nfloat)pivotY);

		//	//Apply transformations in order
		//	transform = CGAffineTransform.Scale(transform, (nfloat)ScaleX, (nfloat)ScaleY);

		//	//Unapply centering
		//	transform = CGAffineTransform.Translate(transform, -(nfloat)pivotX, -(nfloat)pivotY);

		//	view.Transform = transform;
		//}
	}
}

