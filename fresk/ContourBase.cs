using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	public abstract class ContourBase : IContour
	{
		public ContourBase()
		{
		}

		#region IContour Members

		public abstract ReadOnlyCollection<Point> Points
		{
			get;
		}

		public virtual void CalcRowIntersection(int row, ICollection<int> xl)
		{
			int inext;
			int iprev;

			ReadOnlyCollection<Point> pnt = this.Points;
			for (int i = 0, n = pnt.Count - 1; i <= n; ++i)
			{
				if (i < n)
				{
					inext = i + 1;
				}
				else
				{
					inext = 0;
				}

				if (i > 0)
				{
					iprev = i - 1;
				}
				else
				{
					iprev = n;
				}

				int sdypred = Math.Sign(pnt[i].Y - pnt[iprev].Y);

				if (pnt[i].Y == row)
				{
					xl.Add(pnt[i].X);

					while (Math.Sign(pnt[inext].Y - pnt[i].Y) == 0)
					{
						if (i == n)
							break;

						++i;
						if (i < n)
						{
							inext = i + 1;
						}
						else
						{
							inext = 0;
						}
					}

					int ski = Math.Sign(pnt[inext].Y - pnt[i].Y);
					if (sdypred != ski)
					{
						xl.Add(pnt[i].X);
					}
				}
				else if ((pnt[i].Y < row && pnt[inext].Y > row)
						|| (pnt[i].Y > row && pnt[inext].Y < row))
				{
					int xi = (int)(
						(row - pnt[i].Y) * (pnt[inext].X - pnt[i].X)
									/ ((double)(pnt[inext].Y - pnt[i].Y)) + pnt[i].X
						);

					xl.Add(xi);
				}

			} // for i
		}

		List<int> _xl = new List<int>();

		public virtual bool IsInside(Point p)
		{
			_xl.Clear();
			this.CalcRowIntersection(p.Y, _xl);

			_xl.RemoveAll(new Predicate<int>(
				delegate(int target)
				{
					return target <= p.X;
				}));

			return _xl.Count % 2 != 0;
		}

		List<double> _ls = new List<double>();

		public virtual void CalcSegmentIntersection(
			Point a,
			Point b,
			ICollection<Point> inside,
			ICollection<Point> outside
			)
		{
			_ls.Clear();
			_ls.Add(0);
			_ls.Add(1);

			int inext;
			int iprev;
			int n = this.Points.Count - 1;

			for (int i = 0; i <= n; ++i)
			{
				if (i < n)
				{
					inext = i + 1;
				}
				else
				{
					inext = 0;
				}

				if (i > 0)
				{
					iprev = i - 1;
				}
				else
				{
					iprev = n;
				}

				double t;
				double T;
				Point q;
				bool inter = GrUtil.Intersect(
					a,
					b,
					this.Points[i],
					this.Points[inext],
					out t,
					out T,
					out q
					);

				if (inter)
					_ls.Add(t);
			}

			_ls.Sort();

			for (int k = 0; k < _ls.Count - 1; ++k)
			{
				Point rk = new Point(
					a.X + (int)((b.X - a.X) * _ls[k]),
					a.Y + (int)((b.Y - a.Y) * _ls[k])
					);

				Point rkn = new Point(
					a.X + (int)((b.X - a.X) * _ls[k + 1]),
					a.Y + (int)((b.Y - a.Y) * _ls[k + 1])
					);

				Point mk = new Point(
					a.X + (int)((b.X - a.X) * (_ls[k] + _ls[k + 1]) / 2),
					a.Y + (int)((b.Y - a.Y) * (_ls[k] + _ls[k + 1]) / 2)
					);

				if (this.IsInside(mk))
				{
					if (inside != null)
					{
						inside.Add(rk);
						inside.Add(rkn);
					}
				}
				else
				{
					if (outside != null)
					{
						outside.Add(rk);
						outside.Add(rkn);
					}
				}
			}
		}

		#endregion
	}
}
