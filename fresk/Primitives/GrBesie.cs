using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Virl.Fresk.Primitives
{
	public class GrBesie : GrSplineBase
	{
		List<GrPoint> _points = new List<GrPoint>();

		double[] _lpx = new double[0];
		double[] _lpy = new double[0];

		Pen _boundsPen = new Pen(Color.FromArgb(200, 200, 200), 0.01f);

		public GrBesie(IGrObj parent)
			: base(parent)
		{
			Name = "Кривая Безье";
		}

		protected internal override void OnObjectAdd(IGrObj grobj)
		{
			if (grobj is GrPoint)
			{
				_points.Add(grobj as GrPoint);
				_lpx = new double[_points.Count];
				_lpy = new double[_points.Count];

				base.OnObjectAdd(grobj);
			}
		}

		protected internal override void OnObjectRemove(IGrObj grobj)
		{
			base.OnObjectRemove(grobj);
			if (grobj is GrPoint)
			{
				_points.Remove(grobj as GrPoint);
				_lpx = new double[_points.Count];
				_lpy = new double[_points.Count];

				base.OnObjectAdd(grobj);
			}
		}

		public int PointCount
		{
			get { return _points.Count; }
		}

		protected override PointF GeneratePoint(double t)
		{
			int n = _points.Count - 1;

			// x(t) = C(n,0) * t^0 * (1-t)^n * x0
			// + C(n,1) * t^1 * (1-t)^(n-1) * x1
			// + C(n,2) * t^2 * (1-t)^(n-2) * x2
			// + ... + C(n,n) * t^n * (1-t)^0 * xn 

			double c = 1;
			double p = 1;
			double r = 1;
			for (int i = 0; i <= n; ++i)
			{
				if ((n % 2 == 0
					&& i == (n + 1) / 2)
					|| (i < (n + 1) / 2)
					)
				{
					PointF pnti = _points[i].Trans.ApplyF(0, 0);
					PointF pntni = _points[n - i].Trans.ApplyF(0, 0);

					_lpx[i] = pnti.X;
					_lpy[i] = pnti.Y;
					_lpx[n - i] = pntni.X;
					_lpy[n - i] = pntni.Y;
				}

				_lpx[i] *= c * p;
				_lpy[i] *= c * p;
				c *= ((double)(n - i)) / (i + 1);
				p *= t;

				_lpx[n - i] *= r;
				_lpy[n - i] *= r;
				r *= 1 - t;
			}

			double xt = 0;
			double yt = 0;
			for (int i = 0; i <= n; ++i)
			{
				xt += _lpx[i];
				yt += _lpy[i];
			}

			return new PointF((float) xt, (float) yt);
		}

		#region IGrObj Members

		public override void Draw(DrawEventArgs e)
		{
			if (e.Edited == this)
			{
				for (int i = 0; i < _points.Count - 1; ++i)
				{
					e.Gr.DrawLine(
						_boundsPen,
						_points[i].X,
						_points[i].Y,
						_points[i + 1].X,
						_points[i + 1].Y
						);
				}

				DrawEventArgs args = new DrawEventArgs(e);
				args.Draw = true;

				foreach(GrPoint pnt in _points)
					pnt.Draw(args);
			}

			if (e.Draw || e.Edited == this)
			{
				DrawSpline(e.Gr);
			}
		}

		#endregion
	}
}
