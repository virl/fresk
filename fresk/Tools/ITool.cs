using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Virl.Fresk.Tools
{
	public interface ITool
	{
		void Activate(GrPanel panel);

		void Deactivate(GrPanel panel);

		void OnMouseClick(GrPanel panel, MouseEventArgs e);

		void OnMouseDown(GrPanel panel, MouseEventArgs e);

		void OnMouseUp(GrPanel panel, MouseEventArgs e);

		void OnMouseMove(GrPanel panel, MouseEventArgs e);

		void OnPaint(GrPanel panel, Graphics gr);
	}
}
