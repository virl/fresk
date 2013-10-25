using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Virl.Fresk.Primitives;
using Virl.Fresk.Compound;
using Virl.Fresk.Tools;

namespace Virl.Fresk
{
	public partial class GrPanel : UserControl
	{
		IGrObj _root = null;
		IGrObj _edited = null;
		ITool _tool = null;
		Color _spawnColor = Color.Black;
		PropertyGrid _grid = null;
		List<IGrObj> _sel = new List<IGrObj>();
		ReadOnlyCollection<IGrObj> _roSel;

		public GrPanel()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

			_roSel = new ReadOnlyCollection<IGrObj>(_sel);
		}

		public IGrObj Root
		{
			get
			{
				return _root;
			}
			set
			{
				_root = value;
				_edited = value;
			}
		}

		public IGrObj Edited
		{
			get
			{
				return _edited;
			}
			set
			{
				_edited = value;
				_sel.Clear();
			}
		}

		public ITool Tool
		{
			get
			{
				return _tool;
			}
			set
			{
				if (_tool != null)
				{
					_tool.Deactivate(this);
				}

				_tool = value;

				if (_tool != null)
				{
					_tool.Activate(this);
				}
			}
		}

		/// <summary>
		/// ÷вет, который будут иметь новые объекты на панели.
		/// </summary>
		public Color SpawnColor
		{
			get { return _spawnColor; }
			set { _spawnColor = value; }
		}

/*		public IGrObj GetObjectUnder(IGrObj obj, int x, int y)
		{
			if (obj == null)
				return null;

			foreach (IGrObj gro in obj.Objects)
			{
				IGrObj ou = GetObjectUnder(gro, x, y);
				if (ou != null)
					return ou;
			}

			if(obj.IsInside(x, y))
				return obj;

			return null;
		}*/

		public IGrObj GetObjectUnder(int x, int y)
		{
			if (_edited == null)
				return null;

			foreach (IGrObj grobj in _edited.Objects)
			{
				if (grobj.IsInside(x, y))
					return grobj;
			}

			return null;
		}

		public void AddToSelected(IGrObj grobj)
		{
			_sel.Add(grobj);
			_grid.SelectedObjects = _sel.ToArray();
		}

		public void RemoveFromSelected(IGrObj grobj)
		{
			_sel.Remove(grobj);
			_grid.SelectedObjects = _sel.ToArray();
		}

		public void ClearSelected()
		{
			_sel.Clear();
			_grid.SelectedObjects = _sel.ToArray();
		}

		public ReadOnlyCollection<IGrObj> SelectedObjects
		{
			get { return _roSel; }
		}

		public PropertyGrid Grid
		{
			get { return _grid; }
			set { _grid = value; }
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (_root == null)
				return;

			_root.Draw(new DrawEventArgs(e.Graphics, _edited, true));

			// –исуем выделение.
			foreach (IGrObj selobj in this.SelectedObjects)
			{
				e.Graphics.DrawRectangle(
					Pens.LightGray,
					selobj.X - selobj.Width / 2,
					selobj.Y - selobj.Height / 2,
					selobj.Width - 1,
					selobj.Height - 1
				);
			}

			if(_tool != null)
				_tool.OnPaint(this, e.Graphics);
		}

		private void GrPanel_MouseDown(object sender, MouseEventArgs e)
		{
			if (_tool != null)
				_tool.OnMouseDown(this, e);
		}

		private void GrPanel_MouseUp(object sender, MouseEventArgs e)
		{
			if (_tool != null)
				_tool.OnMouseUp(this, e);
		}

		private void GrPanel_MouseMove(object sender, MouseEventArgs e)
		{
			if (_tool != null)
				_tool.OnMouseMove(this, e);
		}

		private void GrPanel_MouseClick(object sender, MouseEventArgs e)
		{
			if (_tool != null)
				_tool.OnMouseClick(this, e);
		}
	}
}
