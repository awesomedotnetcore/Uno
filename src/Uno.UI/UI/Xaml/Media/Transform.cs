using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Windows.Foundation;
#if XAMARIN_ANDROID
using Android.Views;
#elif XAMARIN_IOS_UNIFIED
using View = UIKit.UIView;
#elif __MACOS__
using View = AppKit.NSView;
#elif __WASM__
using View = Windows.UI.Xaml.UIElement;
#else
using View = System.Object;
#endif

namespace Windows.UI.Xaml.Media
{
	/// <summary>
	/// Transform :  Based on the WinRT Transform
	/// 
	/// https://msdn.microsoft.com/en-us/library/system.windows.media.transform(v=vs.110).aspx
	/// </summary>
	public abstract partial class Transform : GeneralTransform
	{
		protected static PropertyChangedCallback NotifyChangedCallback { get; } = (snd, args) =>
		{
			// Don't update the internal value if the value is being animated.
			// The value is being animated by the platform itself.

			if (snd is Transform transform
				&& transform._currentView != null
				&& !(args.NewPrecedence == DependencyPropertyValuePrecedences.Animations && args.BypassesPropagation))
			{
				transform.NotifyChanged();
			}
		};

		internal event EventHandler Changed;

		private View _currentView;
		private Size _currentViewSize;
		private Point _currentViewOrigin;

		protected void NotifyChanged()
		{
			// If the View is null, it usually means that this transform is part of a group,
			// so we have to notify the change so the group will be able to aggregate all the changes at once.
			if (_currentView == null)
			{
				Changed?.Invoke(this, EventArgs.Empty);
			}
			else
			{
				ApplyTo(_currentView, GetAbsoluteOrigin());
			}
		}

		/// <summary>
		/// Applies this transform to the given view
		/// </summary>
		/// <remarks>
		/// Note to implementers:
		/// By default this will convert this transform to a Matrix and will apply the matrix to the view,
		/// but this behavior can be overridden by sub classes to use a faster solution.
		/// In that case implementers should not invoke the base.ApplyTo.
		/// </remarks>
		/// <param name="view">The view on which this transform have to be applied</param>
		/// <param name="absoluteOrigin">The origin to use for this transform (in absolute virtual pixels)</param>
		protected virtual void ApplyTo(View view, Point absoluteOrigin)
		{
			// virtual: Gives the opportunity to the transform to apply it in a more specific / smarter way than the default matrix fallback

			NativeCommonApply(ToMatrix(absoluteOrigin), view);
		}

		/// <summary>
		/// This removes this current transform from the given view
		/// </summary>
		/// <param name="view">The view from which this transform should be removed</param>
		protected virtual void Cleanup(View view)
		{
			// virtual: Gives the opportunity to the transform to apply it in a more specific / smarter way than the default matrix fallback

			NativeCommonCleanup(view);
		}

		/// <summary>
		/// Converts the transform to a standard transform matrix
		/// </summary>
		/// <param name="absoluteOrigin">The absolute origin of the transform, in virtual pixels.</param>
		/// <returns></returns>
		internal abstract Matrix3x2 ToMatrix(Point absoluteOrigin);

		// Currently we support only one view par transform.
		// But we can declare a Transform as a static resource and use it on multiple views.
		internal View View => _currentView;

		internal void AttachToView(View newView, Point origin)
		{
			var oldView = _currentView;
			if (oldView == newView)
			{
				return;
			}

			if (oldView != null)
			{
				Cleanup(oldView);
			}

			_currentViewOrigin = origin;
			_currentView = newView;

			if (newView != null)
			{
				ApplyTo(newView, GetAbsoluteOrigin());
			}
		}

		internal void DetachFromView(View view)
		{
			AttachToView(null, default(Point));
		}

		// Fast path to notifty that the size of the control changed without registering to the event
		// On iOS it's also usefull to avoid useless work (capture the Transform before setting the Frame and restore it after)
		internal void OnViewSizeChanged(View view, Size newSize)
		{
			_currentViewSize = newSize;

			// This is invoked only if the View is set, so we don't have to 'NotifyChanged',
			// instead we can directly request to update the view using the 'ApplyTo'.
			ApplyTo(_currentView, GetAbsoluteOrigin());
		}

		internal void SetOrigin(View view, Point origin)
		{
			_currentViewOrigin = origin;

			// This is invoked only if the View is set, so we don't have to 'NotifyChanged',
			// instead we can directly request to update the view using the 'ApplyTo'.
			ApplyTo(_currentView, GetAbsoluteOrigin());
		}

		/// <summary>
		/// Gets the origin of the transform in absolute logical pixels.
		/// </summary>
		private Point GetAbsoluteOrigin()
			=> GetAbsoluteOrigin(_currentViewOrigin, _currentViewSize);

		private static Point GetAbsoluteOrigin(Point relativeOrigin, Size size)
		{
			var x = relativeOrigin.X * size.Width;
			var y = relativeOrigin.Y * size.Height;

			return new Point(x, y);
		}
	}
}


