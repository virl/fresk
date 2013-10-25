using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Virl.Fresk.Primitives
{
	public class GrLine : GrObjBase
	{
		private GrPoint _p1;
		private GrPoint _p2;

		public GrLine(IGrObj parent, GrPoint p1, GrPoint p2) : base(parent)
		{
			this.DrawningRegion.DrawningContours.Add(new BasicContour());

			_p1 = p1;
			_p2 = p2;

			Objects.Add(_p1);
			Objects.Add(_p2);

			Name = "Отрезок";
		}

		public GrPoint First
		{
			get
			{
				return _p1;
			}
		}

		public GrPoint Second
		{
			get
			{
				return _p2;
			}
		}

		#region IGrDrawning Members

		public override void Draw(DrawEventArgs e)
		{
			if (e.Draw || e.Edited == this)
			{
				GrUtil.DrawLine(e.Gr, this.Color, _p1.X, _p1.Y, _p2.X, _p2.Y);
			}

			e.Draw = (e.Edited == this);
			_p1.Draw(e); _p2.Draw(e);
		}

		public override bool IsInside(int x, int y)
		{
			return GrUtil.IsNearLine(2, x, y, _p1.X, _p1.Y, _p2.X, _p2.Y);
		}

		public override void OnStructureChanged(EventArgs e)
		{
			IList<Point> drPoints = this.DrawningRegion.DrawningContours[0].DrawningPoints;
			drPoints.Clear();
			drPoints.Add(_p1.Trans.Apply(0, 0));
			drPoints.Add(_p2.Trans.Apply(0, 0));

			base.OnStructureChanged(e);
		}

		#endregion
	}
}
