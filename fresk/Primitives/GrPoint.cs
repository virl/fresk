using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace Virl.Fresk.Primitives
{
	public class GrPoint : GrObjBase
	{
		int _width = 8;
		int _height = 8;

		public GrPoint(IGrObj parent, int x, int y) : base(parent)
		{
			BasicContour contour = new BasicContour();
			contour.DrawningPoints.Add(new Point(0, 0));
			this.DrawningRegion.DrawningContours.Add(contour);
			this.Trans.Move(x, y, false);

			Name = "Точка";
		}
		
		#region IGrObj Members

		public override int Width
		{
			get
			{
				return _width;
			}
		}

		public override int Height
		{
			get
			{
				return _height;
			}
		}

		public override void Draw(DrawEventArgs e)
		{
			if (e.Draw)
			{
				Point pnt = GetObjectToWorldTransform().Apply(0, 0);

				Rectangle rect = new Rectangle(
					pnt.X - _width / 2,
					pnt.Y - _height / 2,
					_width - 1,
					_height - 1
					);

				e.Gr.FillEllipse(
					Brushes.Blue,
					rect
					);
			}
		}

		public override bool IsInside(int x, int y)
		{
			if (X - _width / 2 <= x && x < X + _width / 2
				&& Y - _width / 2 <= y && y < Y + _height / 2)
				return true;

			return false;
		}

		public override bool IsPrimitive
		{
			get
			{
				return true;
			}
		}

		public override void OnStructureChanged(EventArgs e)
		{
			base.OnStructureChanged(e);
		}

		#endregion
	}
}
