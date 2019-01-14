using CoreAnimation;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using CoreGraphics;
using UIKit;
using Uno.Extensions;
using Uno.Logging;

namespace Windows.UI.Xaml.Media
{

	/// <summary>
	/// TranslateTransform: iOS part
	/// </summary>
	public partial class TranslateTransform
	{
		//partial void SetX(DependencyPropertyChangedEventArgs args)
		//{
		//	// Don't update the internal value if the value is being animated.
		//	// The value is being animated by the platform itself.
		//	if (View != null && !(args.NewPrecedence == DependencyPropertyValuePrecedences.Animations && args.BypassesPropagation))
		//	{
		//		Update();
		//	}
		//}

		//partial void SetY(DependencyPropertyChangedEventArgs args)
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
		//	if (this.Log().IsEnabled(Microsoft.Extensions.Logging.LogLevel.Debug))
		//	{
		//		this.Log().DebugFormat("Updating UIView Transform based on TranslateTransform with X [{0}] and Y [{1}].", X, Y);
		//	}

		//	if (this.View != null)
		//	{
		//		this.View.Transform = ToNativeTransform(GetViewSize(View));
		//	}
		//}

		//protected override void OnAttachedToView()
		//{
		//	base.OnAttachedToView();

		//	SetNeedsUpdate();
		//}

		//internal override CGAffineTransform ToNativeTransform(CGSize size)
		//{
		//	return CGAffineTransform.MakeTranslation((nfloat)X, (nfloat)Y);
		//}

		protected override void ApplyTo(UIView view, Point absoluteOrigin)
		{
			view.Transform = CGAffineTransform.MakeTranslation((nfloat)X, (nfloat)Y);
		}
	}
}

