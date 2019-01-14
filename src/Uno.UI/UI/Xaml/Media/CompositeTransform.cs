﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Windows.Foundation;

namespace Windows.UI.Xaml.Media
{
	/// <summary>
	/// CompositeTransform :  Based on the WinRT Composite transform
	/// https://searchcode.com/codesearch/view/10522146/
	/// </summary>
	public partial class CompositeTransform : Transform
	{
		//private readonly ScaleTransform _scale = new ScaleTransform();
		//private readonly SkewTransform _skew = new SkewTransform();
		//private readonly RotateTransform _rotation = new RotateTransform();
		//private readonly TranslateTransform _translation = new TranslateTransform();
		////TODO: this doubles up on the 'ToNativeTransform' method and should be removed.
		//private readonly Transform _innerTransform;


		//public CompositeTransform()
		//{
		//	// Creates native transform which applies multiple transformations in this order:
		//	// Scale(ScaleX, ScaleY )
		//	// Skew(SkewX, SkewY)
		//	// Rotate(Rotation)
		//	// Translate(TranslateX, TranslateY)
		//	// https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.compositetransform.aspx

		//	//_innerTransform = new TransformGroup
		//	//{
		//	//	Children = new TransformCollection
		//	//	{
		//	//		_scale,
		//	//		_skew,
		//	//		_rotation,
		//	//		_translation
		//	//	}
		//	//};
		//	//_innerTransform.Changed += (snd, e) => NotifyChanged();
		//}

		//internal override void OnViewSizeChanged(Size oldSize, Size newSize)
		//{
		//	_innerTransform.OnViewSizeChanged(oldSize, newSize);
		//}

		internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
		{
			// Creates native transform which applies multiple transformations in this order:
			// Scale(ScaleX, ScaleY )
			// Skew(SkewX, SkewY)
			// Rotate(Rotation)
			// Translate(TranslateX, TranslateY)
			// https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.compositetransform.aspx

			var matrix = Matrix3x2.Identity;

			matrix *= ScaleTransform.GetMatrix(CenterX, CenterY, ScaleX, ScaleY);
			matrix *= SkewTransform.GetMatrix(CenterX, CenterY, SkewX, SkewY);
			matrix *= RotateTransform.GetMatrix(CenterX, CenterY, Rotation);
			matrix *= TranslateTransform.GetMatrix(TranslateX, TranslateY);

			return matrix;
		}

		//internal override Point Origin
		//      {
		//          get => _innerTransform.Origin;
		//	set => _innerTransform.Origin = value;
		//}

		public double CenterX
		{
			get => (double)this.GetValue(CenterXProperty);
			set => this.SetValue(CenterXProperty, value);
		}

		public static readonly DependencyProperty CenterXProperty =
			DependencyProperty.Register("CenterX", typeof(double), typeof(CompositeTransform), new PropertyMetadata(0.0d, NotifyChangedCallback));

		public double CenterY
		{
			get => (double)this.GetValue(CenterYProperty);
			set => this.SetValue(CenterYProperty, value);
		}

		public static readonly DependencyProperty CenterYProperty =
			DependencyProperty.Register("CenterY", typeof(double), typeof(CompositeTransform), new PropertyMetadata(0.0d, NotifyChangedCallback));

		public double Rotation
		{
			get => (double)this.GetValue(RotationProperty);
			set => this.SetValue(RotationProperty, value);
		}

		public static readonly DependencyProperty RotationProperty =
			DependencyProperty.Register("Rotation", typeof(double), typeof(CompositeTransform), new PropertyMetadata(0.0d, NotifyChangedCallback));

		public double ScaleX
		{
			get => (double)this.GetValue(ScaleXProperty);
			set => this.SetValue(ScaleXProperty, value);
		}

		public static readonly DependencyProperty ScaleXProperty =
			DependencyProperty.Register("ScaleX", typeof(double), typeof(CompositeTransform), new PropertyMetadata(1.0d, NotifyChangedCallback));

		public double ScaleY
		{
			get => (double)this.GetValue(ScaleYProperty);
			set => this.SetValue(ScaleYProperty, value);
		}

		public static readonly DependencyProperty ScaleYProperty =
			DependencyProperty.Register("ScaleY", typeof(double), typeof(CompositeTransform), new PropertyMetadata(1.0d, NotifyChangedCallback));

		public double SkewX
		{
			get => (double)this.GetValue(SkewXProperty);
			set => this.SetValue(SkewXProperty, value);
		}

		public static readonly DependencyProperty SkewXProperty =
			DependencyProperty.Register("SkewX", typeof(double), typeof(CompositeTransform), new PropertyMetadata(0.0d, NotifyChangedCallback));

		public double SkewY
		{
			get => (double)this.GetValue(SkewYProperty);
			set => this.SetValue(SkewYProperty, value);
		}

		public static readonly DependencyProperty SkewYProperty =
			DependencyProperty.Register("SkewY", typeof(double), typeof(CompositeTransform), new PropertyMetadata(0.0d, NotifyChangedCallback));

		public double TranslateX
		{
			get => (double)this.GetValue(TranslateXProperty);
			set => this.SetValue(TranslateXProperty, value);
		}

		public static readonly DependencyProperty TranslateXProperty =
			DependencyProperty.Register("TranslateX", typeof(double), typeof(CompositeTransform), new PropertyMetadata(0.0d, NotifyChangedCallback));

		public double TranslateY
		{
			get => (double)this.GetValue(TranslateYProperty);
			set => this.SetValue(TranslateYProperty, value);
		}

		public static readonly DependencyProperty TranslateYProperty =
			DependencyProperty.Register("TranslateY", typeof(double), typeof(CompositeTransform), new PropertyMetadata(0.0d, NotifyChangedCallback));
	}
}
