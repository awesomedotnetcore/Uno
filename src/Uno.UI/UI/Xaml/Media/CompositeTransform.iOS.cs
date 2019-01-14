﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using CoreGraphics;
using Uno.Extensions;
using Microsoft.Extensions.Logging;
using UIKit;
using Uno.Logging;
using Uno.UI;

namespace Windows.UI.Xaml.Media
{
	/// <summary>
	/// CompositeTransform: iOS part
	/// </summary>
	public partial class CompositeTransform
	{
		///// <summary>
		///// Set the view of the inner transform
		///// </summary>
		//protected override void OnAttachedToView()
		//{
		//	base.OnAttachedToView();
		//	_innerTransform.View = View;
		//}

		/// <summary>
		/// Creates native transform which applies multiple transformations in this order:
		/// Scale(ScaleX, ScaleY )
		/// Skew(SkewX, SkewY)
		/// Rotate(Rotation)
		/// Translate(TranslateX, TranslateY)
		/// https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.compositetransform.aspx
		/// </summary>
		/// <returns></returns>
		protected override void ApplyTo(UIView view, Point absoluteOrigin)
		{
			var pivotX = absoluteOrigin.X + CenterX;
			var pivotY = absoluteOrigin.Y + CenterY;

			var transform = CGAffineTransform.MakeIdentity();

			//Perform transformations about centre
			transform = CGAffineTransform.Translate(transform, (float)(pivotX), (float)(pivotY));

			//Apply transformations in order
			transform = CGAffineTransform.Scale(transform, (float)ScaleX, (float)ScaleY);

			//TODO: implement skew (see eg http://stackoverflow.com/questions/6203738/iphone-skew-a-calayer)
			if ((SkewX != 0 || SkewY != 0) && this.Log().IsEnabled(LogLevel.Warning))
			{
				this.Log().Warn("Skew is not enabled for CompositeTransform.");
			}

			transform = CGAffineTransform.Rotate(transform, (nfloat)MathEx.ToRadians(Rotation));

			transform = CGAffineTransform.Translate(transform, (float)TranslateX, (float)TranslateY);

			//Unapply centering
			transform = CGAffineTransform.Translate(transform, (float)(-pivotX), (float)(-pivotY));

			view.Transform = transform;
		}
	}
}

