using Windows.Foundation;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Numerics;
using System.Text;
using Windows.UI.Xaml.Markup;

namespace Windows.UI.Xaml.Media
{
	/// <summary>
	/// TransformGroup :  Based on the WinRT TransformGroup
	/// https://msdn.microsoft.com/en-us/library/system.windows.media.transformgroup(v=vs.110).aspx
	/// </summary>
	[ContentProperty(Name = "Children")]
	public partial class TransformGroup : Transform
	{
		internal override Matrix3x2 ToMatrix(Point absoluteOrigin)
		{
			var matrix = Matrix3x2.Identity;
			if (Children != null)
			{
				foreach (var child in Children)
				{
					matrix = child.ToMatrix(absoluteOrigin);
				}
			}

			return matrix;
		}

		//protected override void OnAttachedToView()
		//{
		//	base.OnAttachedToView();
		//	if (View != null)
		//	{
		//		foreach (var item in Children)
		//		{
		//			item.View = View;
		//		}
		//	}
		//}

		//internal override Foundation.Point Origin
		//      {
		//          get => base.Origin;
		//	set
		//          {
		//              base.Origin = value;
		//              foreach (var item in Children)
		//              {
		//                  item.Origin = value;
		//              }
		//          }
		//      }     

		public TransformCollection Children
		{
			get
			{
				var collection = (TransformCollection)this.GetValue(ChildrenProperty);
				if (collection == null)
				{
					this.SetValue(ChildrenProperty, collection = new TransformCollection());
				}

				return collection;
			}
			set => this.SetValue(ChildrenProperty, value);
		}

		public static readonly DependencyProperty ChildrenProperty =
			DependencyProperty.Register("Children", typeof(TransformCollection), typeof(TransformGroup), new PropertyMetadata(OnChildrenChanged));

		private static void OnChildrenChanged(DependencyObject dependencyobject, DependencyPropertyChangedEventArgs args)
			=> ((TransformGroup)dependencyobject).OnChildrenChanged(args);

		private void OnChildrenChanged(DependencyPropertyChangedEventArgs args)
		{
			if (args.OldValue is TransformCollection oldItems)
			{
				oldItems.CollectionChanged -= OnChildrenItemsChanged;
				foreach (var item in oldItems)
				{
					OnChildRemoved(item);
				}
			}

			if (args.NewValue is TransformCollection newItems)
			{
				newItems.CollectionChanged += OnChildrenItemsChanged;
				foreach (var item in newItems)
				{
					OnChildAdded(item);
				}
			}

			NotifyChanged();
		}

		private void OnChildrenItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
				case NotifyCollectionChangedAction.Remove:
				case NotifyCollectionChangedAction.Replace:
					if (e.NewItems != null)
					{
						foreach (var child in e.NewItems)
						{
							if (child is Transform transform)
							{
								OnChildAdded(transform);
							}
						}
					}

					if (e.OldItems != null)
					{
						foreach (var child in e.OldItems)
						{
							if (child is Transform transform)
							{
								OnChildRemoved(transform);
							}
						}
					}
					break;
			}

			NotifyChanged();
		}

		private void OnChildAdded(Transform transform) => transform.Changed += OnChildTransformChanged;
		private void OnChildRemoved(Transform transform) => transform.Changed -= OnChildTransformChanged;

		private void OnChildTransformChanged(object sender, EventArgs e) => NotifyChanged();
	}

}

