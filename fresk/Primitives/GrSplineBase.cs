using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk.Primitives
{
	public abstract class GrSplineBase : GrObjBase
	{
		double _deltaMax = 10;
		bool _useStep = false;
		double _dt = 0.01;

		public GrSplineBase(IGrObj parent) : base(parent)
		{
			Name = "Сплайн";
			this.DrawningRegion.DrawningContours.Add(
				new BasicContour()
			);
		}

		protected abstract PointF GeneratePoint(double t);

		private void Approx(double t0, double t1)
		{
			PointF p_t = GeneratePoint(t0);
			PointF p_dt = GeneratePoint((t1 + t0) / 2);
			PointF p_2dt = GeneratePoint(t1);

			PointF dp = new PointF(
				p_2dt.X - p_t.X,
				p_2dt.Y - p_t.Y
				);

			double delta =
				(dp.Y * (p_dt.X - p_t.X) - dp.X * (p_dt.Y - p_t.Y))
				/ Math.Sqrt(dp.X * dp.X + dp.Y * dp.Y);

			if (Math.Abs(delta) >= _deltaMax)
			{
				Approx(t0, (t1 + t0) / 2);
				Approx((t1 + t0) / 2, t1);
				return;
			}

			this.DrawningRegion.DrawningContours[0].DrawningPoints
				.Add(new Point((int)p_dt.X, (int)p_dt.Y));

			this.DrawningRegion.DrawningContours[0].DrawningPoints
				.Add(new Point((int)p_2dt.X, (int)p_2dt.Y));
		}

		public bool UseStep
		{
			get
			{
				return _useStep;
			}
			set
			{
				_useStep = value;
			}
		}

		public double dt
		{
			get
			{
				return _dt;
			}
			set
			{
				_dt = value;
			}
		}

		#region IGrObj Members

		public override bool IsInside(int x, int y)
		{
			IList<Point> drPoints = this.DrawningRegion.DrawningContours[0].DrawningPoints;

			Transform tr = GetObjectToWorldTransform();

			Point prev = tr.Apply(drPoints[0]);
			Point cur;

			for (int i = 1; i < drPoints.Count; ++i)
			{
				cur = tr.Apply(drPoints[i]);

				if(GrUtil.IsNearLine(
					2,
					x,
					y,
					prev.X,
					prev.Y,
					cur.X,
					cur.Y
					)
					)
				{
					return true;
				}

				prev = cur;
			}

			return false;
		}

		protected virtual void DrawSpline(Graphics gr)
		{
			IList<Point> drPoints = this.DrawningRegion.DrawningContours[0].DrawningPoints;

			Transform tr = GetObjectToWorldTransform();

			Point prev = tr.Apply(drPoints[0]);
			Point cur;

			for (int i = 1; i < drPoints.Count; ++i)
			{
				cur = tr.Apply(drPoints[i]);

				GrUtil.DrawLine(
					gr,
					this.Color,
					prev.X,
					prev.Y,
					cur.X,
					cur.Y
					);

				prev = cur;
			}
		}

		public override bool IsPrimitive
		{
			get
			{
				return false;
			}
		}

		public double DeltaMax
		{
			get
			{
				return _deltaMax;
			}
			set
			{
				_deltaMax = value;
			}
		}

		public override void OnStructureChanged(EventArgs e)
		{
			IList<Point> drPoints = this.DrawningRegion.DrawningContours[0].DrawningPoints;
			drPoints.Clear();
			PointF sp = GeneratePoint(0);
			drPoints.Add(new Point((int)sp.X, (int)sp.Y));

			if (_useStep)
			{
				for (double t = 0; t <= 1; t += _dt * 2)
				{
					double t2dt = t + _dt * 2;

					if (t2dt > 1)
						t2dt = 1;

					Approx(t, t2dt);
				}
			}
			else
			{
				for (double t = 0; t <= 1; t += _dt)
				{
					sp = GeneratePoint(t);
					drPoints.Add(
						new Point(
						(int)sp.X,
						(int)sp.Y
						)
						);
				}
			}

			PointF ep = GeneratePoint(1);
			drPoints.Add(new Point((int)ep.X, (int)ep.Y));

			base.OnStructureChanged(e);
		}

		#endregion
	}
}
