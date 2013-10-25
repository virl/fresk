using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Virl.Fresk.Primitives;

namespace Virl.Fresk.Tools
{
	public class LinePlacer : ITool
	{
		GrPoint _linePnt = null;

		public LinePlacer()
		{
		}

		#region ITool Members

		public void Activate(GrPanel panel)
		{
		}

		public void Deactivate(GrPanel panel)
		{
			_linePnt = null;
		}

		public void OnMouseClick(GrPanel panel, System.Windows.Forms.MouseEventArgs e)
		{
			IGrObj grobj = panel.GetObjectUnder(e.X, e.Y);

			IGrObj parent = grobj;
			if (grobj == null || grobj.IsPrimitive)
			{
				parent = panel.Root;
			}

			if (_linePnt == null)
			{
				if (grobj is GrPoint)
				{
					_linePnt = grobj as GrPoint;
				}
				else
				{
					_linePnt = new GrPoint(parent, e.X, e.Y);
				}
			}
			else if (parent == _linePnt.Parent)
			{
				GrLine line;
				if (grobj is GrPoint)
				{
					line = new GrLine(null, _linePnt, grobj as GrPoint);
				}
				else
				{
					line = new GrLine(null, _linePnt, new GrPoint(null, e.X, e.Y));
				}

				line.Color = panel.SpawnColor;
				panel.Edited.Objects.Add(line);
				_linePnt = null;
				panel.Invalidate();
			}
		}

		public void OnMouseDown(GrPanel panel, System.Windows.Forms.MouseEventArgs e)
		{
		}

		public void OnMouseUp(GrPanel panel, System.Windows.Forms.MouseEventArgs e)
		{
		}

		public void OnMouseMove(GrPanel panel, System.Windows.Forms.MouseEventArgs e)
		{
		}

		public void OnPaint(GrPanel panel, Graphics gr)
		{
		}

		#endregion
	}
}
