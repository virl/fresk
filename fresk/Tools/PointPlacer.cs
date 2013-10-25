using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Virl.Fresk.Primitives;

namespace Virl.Fresk.Tools
{
	public class PointPlacer : ITool
	{
		#region ITool Members

		public void Activate(GrPanel panel)
		{
		}

		public void Deactivate(GrPanel panel)
		{
		}

		public void OnMouseClick(GrPanel panel, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			GrPoint pnt = new GrPoint(
				null,
				e.X,
				e.Y
				);

			panel.Edited.Objects.Add(pnt);
			panel.Invalidate();
		}

		public void OnMouseDown(GrPanel panel, MouseEventArgs e)
		{
		}

		public void OnMouseUp(GrPanel panel, MouseEventArgs e)
		{
		}

		public void OnMouseMove(GrPanel panel, MouseEventArgs e)
		{
		}

		public void OnPaint(GrPanel panel, Graphics gr)
		{
		}

		#endregion
	}
}
