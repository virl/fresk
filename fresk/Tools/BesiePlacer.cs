using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Virl.Fresk.Primitives;

namespace Virl.Fresk.Tools
{
	public class BesiePlacer : ITool
	{
		GrBesie _besie = null;

		public BesiePlacer()
		{
		}

		#region ITool Members

		public void Activate(GrPanel panel)
		{
			_besie = new GrBesie(null);
			_besie.Color = panel.SpawnColor;
		}

		public void Deactivate(GrPanel panel)
		{
			_besie = null;
		}

		public void OnMouseClick(GrPanel panel, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			IGrObj grobj = panel.GetObjectUnder(e.X, e.Y);

			if (grobj != null && grobj is GrPoint)
			{
				_besie.Objects.Add(grobj as GrPoint);

				if (_besie.PointCount == 2)
					panel.Edited.Objects.Add(_besie);

				panel.Invalidate();
			}
			else
			{
				GrPoint pnt = new GrPoint(null, e.X, e.Y);
				panel.Root.Objects.Add(pnt);

				_besie.Objects.Add(pnt);

				if (_besie.PointCount == 2)
					panel.Edited.Objects.Add(_besie);

				panel.Invalidate();
			}
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
