using Android.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.Foundation;
using System.Text;
using Android.Views;
using Uno.Extensions;
using Uno.Logging;
using Uno.UI;

namespace Windows.UI.Xaml.Media
{
	/// <summary>
	/// Transform: Android part
	/// </summary>
	public partial class Transform
	{
		internal virtual Android.Graphics.Matrix ToNative(Android.Graphics.Matrix targetMatrix = null, Size size = new Size(), bool isBrush = false)
		{
			throw new NotImplementedException();
		}

		private void NativeCommonApply(Matrix3x2 matrix, View view)
		{
			//// The transform matrix cannot be applied directly and must first be decomposed to fit in the Android API.
			//// See:
			//// - https://stackoverflow.com/questions/45159314/decompose-2d-transformation-matrix
			//// - https://math.stackexchange.com/questions/13150/extracting-rotation-scale-values-from-2d-transformation-matrix

			//var translationX = ViewHelper.LogicalToPhysicalPixels(matrix.Translation.X);
			//var translationY = ViewHelper.LogicalToPhysicalPixels(matrix.Translation.Y);
			//var scaleX = (float) Math.Sqrt(Math.Pow(matrix.M11, 2) + Math.Pow(matrix.M12, 2));
			//var scaleY = (float) Math.Sqrt(Math.Pow(matrix.M21, 2) + Math.Pow(matrix.M22, 2));

			//double rotationDegree;
			//if (scaleX != 0)
			//{
			//	rotationDegree = matrix.M12 > 0
			//		? Math.Acos(matrix.M11 / scaleX)
			//		: -Math.Acos(matrix.M11 / scaleX);
			//}
			//else if (scaleY != 0)
			//{
			//	rotationDegree = Math.PI / 2 - matrix.M22 > 0
			//		? Math.Acos(-matrix.M21 / scaleY)
			//		: -Math.Acos(matrix.M21 / scaleY);
			//}
			//else
			//{
			//	rotationDegree = 0;
			//}

			//var rotation = (float)MathEx.ToDegree(rotationDegree);

			////var orientation = Math.Atan(-matrix.M21 / matrix.M11);
			////var rotation = (float) MathEx.ToDegree(Math.Acos(matrix.M11 / scaleX));

			////if ((rotation > 90 && orientation > 0)
			////	|| (rotation < 90 && orientation < 0))
			////{
			////	rotation = 360 - rotation;
			////}

			//Matrix4x4.Decompose(new Matrix4x4(matrix), out var scale, out var rotation, out var translation);


			// Matrix4x4.Decompose()

			//view.TranslationX = translationX;
			//view.TranslationY = translationY;
			//view.PivotX = 0;
			//view.PivotY = 0;
			//view.ScaleX = scaleX;
			//view.ScaleY = scaleY;
			//view.Rotation = rotation;
			//view.Ro

			Matrix4x4.Decompose(new Matrix4x4(matrix), out var scale, out var rotation, out var translation);

			view.TranslationX = ViewHelper.LogicalToPhysicalPixels(translation.X);
			view.TranslationY = ViewHelper.LogicalToPhysicalPixels(translation.Y);
			view.PivotX = 0;
			view.PivotY = 0;
			view.ScaleX = scale.X;
			view.ScaleY = scale.Y;
			view.Rotation = (float)MathEx.ToDegree(rotation.Z);
			//view.Rotation = 0;//(float)MathEx.ToDegree(rotation.W);
			//view.RotationX = (float)MathEx.ToDegree(rotation.X);
			//view.RotationY = (float)MathEx.ToDegree(rotation.Y);
		}

		private void NativeCommonCleanup(View view)
		{
			view.TranslationX = 0;
			view.TranslationY = 0;
			view.PivotX = 0;
			view.PivotY = 0;
			view.ScaleX = 0;
			view.ScaleY = 0;
			view.Rotation = 0;
			view.RotationX = 0;
			view.RotationY = 0;
		}
	}
}
