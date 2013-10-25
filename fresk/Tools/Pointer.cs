using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Virl.Fresk.Primitives;

namespace Virl.Fresk.Tools
{
	public class Pointer : ITool
	{
		List<IGrObj> _objs = new List<IGrObj>();
		int _moveX = 0;
		int _moveY = 0;

		bool _selecting = false;
		Point _selBoxStart = new Point();
		Point _selBoxEnd = new Point();

		public Pointer()
		{
		}

		#region ITool Members

		public void Activate(GrPanel panel)
		{
		}

		public void Deactivate(GrPanel panel)
		{
		}

		public void OnMouseClick(GrPanel panel, System.Windows.Forms.MouseEventArgs e)
		{
		}

		public void OnMouseDown(GrPanel panel, System.Windows.Forms.MouseEventArgs e)
		{
			IGrObj grobj = panel.GetObjectUnder(e.X, e.Y);
			if (grobj != null && !_objs.Contains(grobj))
			{
				panel.ClearSelected();
				panel.AddToSelected(grobj);
				panel.Invalidate();
			}
			else if (grobj == null && e.Button == MouseButtons.Left)
			{
				_selecting = true;
				_selBoxStart = new Point(e.X, e.Y);
				_selBoxEnd = new Point(e.X, e.Y);

				panel.Cursor = Cursors.Cross;
				panel.ClearSelected();
				panel.Invalidate();
			}

			if (panel.SelectedObjects.Count != 0 && e.Button == MouseButtons.Left)
			{
				_objs.Clear();
				_objs.AddRange(panel.SelectedObjects);
				_moveX = e.X;
				_moveY = e.Y;
				panel.Cursor = Cursors.SizeAll;
			}
		}

		public void OnMouseUp(GrPanel panel, System.Windows.Forms.MouseEventArgs e)
		{
			_objs.Clear();
			panel.Cursor = Cursors.Arrow;

			if (_selecting)
			{
				_selecting = false;

				panel.ClearSelected();
/*				foreach (IGrObj grobj in panel.Edited.Objects)

					panel.AddToSelected(grobj);*/

				panel.Invalidate();
			}
		}

		public void OnMouseMove(GrPanel panel, System.Windows.Forms.MouseEventArgs e)
		{
			if (_selecting)
			{
				_selBoxEnd = new Point(e.X, e.Y);
				panel.Invalidate();
			}
			else
				if (_objs.Count != 0)
				{
					foreach (IGrObj grobj in _objs)
					{
						grobj.X += e.X - _moveX;
						grobj.Y += e.Y - _moveY;
					}

					_moveX = e.X;
					_moveY = e.Y;
					panel.Invalidate();
				}
		}

		public void OnPaint(GrPanel panel, Graphics gr)
		{
			if (_selecting)
			{
				gr.DrawRectangle(
					Pens.LightBlue,
					Math.Min(_selBoxStart.X, _selBoxEnd.X),
					Math.Min(_selBoxStart.Y, _selBoxEnd.Y),
					Math.Abs(_selBoxEnd.X - _selBoxStart.X),
					Math.Abs(_selBoxEnd.Y - _selBoxStart.Y)
				);
			}

			/*			foreach (IGrObj selobj in panel.SelectedObjects)
						{
							gr.DrawRectangle(
								Pens.LightGray,
								selobj.X,
								selobj.Y,
								selobj.Width,
								selobj.Height
							);
						}*/
		}

		#endregion
	}
}
