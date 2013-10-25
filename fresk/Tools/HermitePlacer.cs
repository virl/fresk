using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Virl.Fresk.Primitives;

namespace Virl.Fresk.Tools
{
	public class HermitePlacer : ITool
	{
		GrLine _hermiteVector = null;

		#region ITool Members

		public void Activate(GrPanel panel)
		{
		}

		public void Deactivate(GrPanel panel)
		{
			_hermiteVector = null;
		}

		public void OnMouseClick(GrPanel panel, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left)
				return;

			IGrObj grobj = panel.GetObjectUnder(e.X, e.Y);

			if (_hermiteVector == null && grobj != null
				&& grobj is GrLine)
			{
				_hermiteVector = grobj as GrLine;
			}
			else if (_hermiteVector != null && grobj != null
				&& grobj is GrLine)
			{
				GrHermite hermite = new GrHermite(null, _hermiteVector, grobj as GrLine);
				hermite.Color = panel.SpawnColor;
				panel.Edited.Objects.Add(hermite);
				_hermiteVector = null;
			}

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
