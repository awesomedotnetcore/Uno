using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.Foundation;
using System.Text;
using Uno.Extensions;
using Uno.Logging;

namespace Windows.UI.Xaml.Media
{
	/// <summary>
	/// Transform: Android part
	/// </summary>
	public partial class Transform
	{
		//internal virtual Android.Graphics.Matrix ToNativeTransform(Android.Graphics.Matrix targetMatrix = null, Size size = new Size(), bool isBrush = false)
		//{
		//	throw new NotImplementedException();
		//}

		// Not implemented yet
		// The transform matrix cannot be applied directly and must
		// first be decomposed to fit in the Android API.
		// See https://math.stackexchange.com/questions/13150/extracting-rotation-scale-values-from-2d-transformation-matrix

		private void NativeCommonApply(Matrix3x2 m, View view)
		{
			this.Log().Error("MatrixTransform is not implemented");
		}

		private void NativeCommonCleanup(View view)
		{
			this.Log().Error("MatrixTransform is not implemented");
		}
	}
}
