using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

using Aga.Controls.Tree;

namespace Virl.Fresk.Primitives
{
	public abstract class GrObjBase : IGrObj
	{
		Transform _trans = new Transform();
		BrowserTreeModel _model = null;
		string _name = "";
		Color _color = Color.Black;
		IGrObj _parent;
		BasicRegion _region = new BasicRegion();
		BasicRegion _trRegion = new BasicRegion();

		GrObjCollection _objects;

		#region GrObjCollection

		private class GrObjCollection : Collection<IGrObj>
		{
			private GrObjBase _owner;

			public GrObjCollection(GrObjBase owner)
			{
				_owner = owner;
			}

			protected override void ClearItems()
			{
				while (this.Count != 0)
					this.RemoveAt(this.Count - 1);
			}

			protected override void InsertItem(int index, IGrObj item)
			{
				if (item == null)
					throw new ArgumentNullException("item");

				if (item.Parent != _owner)
				{
					if (item.Parent != null)
						item.Parent.Objects.Remove(item);
					item.Parent = _owner;
					base.InsertItem(index, item);

					BrowserTreeModel model = _owner.FindModel();
					if (model != null)
						model.OnNodeInserted(_owner, index, item);

					_owner.OnObjectAdd(item);
				}
			}

			protected override void RemoveItem(int index)
			{
				IGrObj item = this[index];
				item.Parent = null;
				base.RemoveItem(index);

				BrowserTreeModel model = _owner.FindModel();
				if (model != null)
					model.OnNodeRemoved(_owner, index, item);

				_owner.OnObjectRemove(item);
			}

			protected override void SetItem(int index, IGrObj item)
			{
				if (item == null)
					throw new ArgumentNullException("item");

				RemoveAt(index);
				InsertItem(index, item);
			}
		}

		#endregion

		public GrObjBase(IGrObj parent)
		{
			_objects = new GrObjCollection(this);
			_parent = parent;
		}

		protected BasicRegion DrawningRegion
		{
			get { return _region; }
		}

		protected internal virtual void OnObjectAdd(IGrObj grobj)
		{
			//SanitizeCoordinates();
			OnStructureChanged(new EventArgs());
		}

		protected internal virtual void OnObjectRemove(IGrObj grobj)
		{
			//SanitizeCoordinates();
			OnStructureChanged(new EventArgs());
		}

		protected IRegion GetTransformedRegion()
		{
			Transform tr = GetObjectToWorldTransform();

			_trRegion.DrawningContours.Clear();
			_trRegion.AddWithTransform(_region, tr);

			return _trRegion;
		}

/*		void SanitizeCoordinates()
		{
			return;

			if (_drPoints.Count == 0)
				return;

			int minx = int.MaxValue;
			int maxx = int.MinValue;
			int miny = int.MaxValue;
			int maxy = int.MinValue;
			foreach (Point pnt in _drPoints)
			{
				if (pnt.X < minx)
					minx = pnt.X;
				if (pnt.X > maxx)
					maxx = pnt.X;
				if (pnt.Y < miny)
					miny = pnt.Y;
				if (pnt.Y > maxy)
					maxy = pnt.Y;
			}

			int dx = minx + (maxx - minx) / 2;
			int dy = miny + (maxy - miny) / 2;

			foreach (IGrObj grobj in Objects)
			{
				grobj.Trans.Move(-dx, -dy, false);
			}
			
			this.Trans.Move(dx, dy, false);
		}*/

		#region IGrObj Members

		public virtual Transform Trans
		{
			get
			{
				return _trans;
			}
		}

		public virtual Transform GetObjectToWorldTransform()
		{
			Transform ntr = new Transform(this.Trans);
			IGrObj grobj = this;
			while ((grobj = grobj.Parent) != null)
				ntr.Mult(grobj.Trans, false);

			return ntr;
		}

		public virtual int X
		{
			get
			{
				int min = int.MaxValue;
				int max = int.MinValue;
				foreach (IContour cont in GetTransformedRegion().Contours)
				foreach (Point pnt in cont.Points)
				{
					if (pnt.X < min)
						min = pnt.X;
					if (pnt.X > max)
						max = pnt.X;
				}

				return min + (max - min) / 2;
			}
			set
			{
				int d = value - X;
				Trans.Move(d, 0, false);

				OnStructureChanged(new EventArgs());
			}
		}

		public virtual int Y
		{
			get
			{
				int min = int.MaxValue;
				int max = int.MinValue;
				foreach (IContour cont in GetTransformedRegion().Contours)
				foreach (Point pnt in cont.Points)
				{
					if (pnt.Y < min)
						min = pnt.Y;
					if (pnt.Y > max)
						max = pnt.Y;
				}

				return min + (max - min) / 2;
			}
			set
			{
				int d = value - Y;
				Trans.Move(0, d, false);

				OnStructureChanged(new EventArgs());
			}
		}

		public virtual int Width
		{
			get
			{
				if (Region.Contours.Count == 0
					|| Region.Contours[0].Points.Count == 0)
					return 0;

				int min = int.MaxValue;
				int max = int.MinValue;
				foreach (IContour cont in GetTransformedRegion().Contours)
				foreach (Point pnt in cont.Points)
				{
					if (pnt.X < min)
						min = pnt.X;
					if (pnt.X > max)
						max = pnt.X;
				}

				return max - min;
			}
		}

		public virtual int Height
		{
			get
			{
				if (Region.Contours.Count == 0
					|| Region.Contours[0].Points.Count == 0)
					return 0;

				int min = int.MaxValue;
				int max = int.MinValue;
				foreach (IContour cont in GetTransformedRegion().Contours)
				foreach (Point pnt in cont.Points)
				{
					if (pnt.Y < min)
						min = pnt.Y;
					if (pnt.Y > max)
						max = pnt.Y;
				}

				return max - min;
			}
		}

		public virtual double Angle
		{
			get
			{
				return 0;
			}
			set
			{
				Trans.Rotate(value, false);
			}
		}

		public virtual string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public virtual Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
			}
		}

		public virtual IGrObj Parent
		{
			get
			{
				return _parent;
			}
			set
			{
				_parent = value;
			}
		}

		public virtual BrowserTreeModel Model
		{
			get
			{
				return _model;
			}
			set
			{
				_model = value;
			}
		}

		public virtual bool IsPrimitive
		{
			get
			{
				return false;
			}
		}

		public virtual bool IsInside(int x, int y)
		{
			return false;
		}

		public IRegion Region
		{
			get
			{
				return _region;
			}
		}

		public virtual void Draw(DrawEventArgs e)
		{
			foreach (IGrObj obj in _objects)
				obj.Draw(e);
		}

		public virtual Collection<IGrObj> Objects
		{
			get
			{
				return _objects;
			}
		}

		public int Index
		{
			get
			{
				if (_parent != null)
					return _parent.Objects.IndexOf(this);
				else
					return -1;
			}
		}

		public BrowserTreeModel FindModel()
		{
			IGrObj node = this;
			while (node != null)
			{
				if (node.Model != null)
					return node.Model;
				node = node.Parent;
			}
			return null;
		}

		protected void NotifyModel()
		{
			BrowserTreeModel model = FindModel();
			if (model != null && Parent != null)
			{
				TreePath path = model.GetPath(Parent);
				if (path != null)
				{
					TreeModelEventArgs args = new TreeModelEventArgs(path, new int[] { Index }, new object[] { this });
					model.OnNodesChanged(args);
				}
			}
		}

		public IGrObj NextObject
		{
			get
			{
				int index = Index;
				if (index >= 0 && index < _parent.Objects.Count - 1)
					return _parent.Objects[index + 1];
				else
					return null;
			}
		}

		public virtual void OnStructureChanged(EventArgs e)
		{
			if (Parent != null)
			{
				Parent.OnStructureChanged(e);
			}
		}

		#endregion
	}
}
