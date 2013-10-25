using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	class GrUtil
	{
		static Dictionary<long, long> _factHash = new Dictionary<long, long>();

		static Bitmap _pixelBitmap = new Bitmap(1, 1);

		// Последнее число, для которого был вычислен факториал.
		static long _maxFactHash = 1;

		static GrUtil()
		{
			_factHash.Add(0, 1);
			_factHash.Add(1, 1);

			_pixelBitmap.SetPixel(0, 0, Color.Red);
		}

		public static long Fact(long a)
		{
			if(!_factHash.ContainsKey(a))
			{
				_factHash.Add(a, _maxFactHash * RFact(_maxFactHash + 1, a));
			}
			return (long) _factHash[a];
		}

		public static long RFact(long a)
		{
			long fact = 1;

			long i;
			for (i = 1; i <= a; ++i)
			{
				fact *= i;
			}

			return fact;
		}

		public static long RFact(long from, long to)
		{
			if (from == 0)
				from = 1;

			long fact = 1;

			long i;
			for (i = from; i <= to; ++i)
			{
				fact *= i;
			}

			return fact;
		}

		public static double Dist(Point a, Point b)
		{
			return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
		}

		public static void DrawLine(Graphics gr, Color color, int x1, int y1, int x2, int y2)
		{
			_pixelBitmap.SetPixel(0, 0, color);

			int pntx = x1;
			int pnty = y1;

			int f = 0;
			int fx;

			int dx = x2 - x1;
			int dy = y2 - y1;

			int sx = Math.Sign(dx);
			int sy = Math.Sign(dy);
			dx *= sx;
			dy *= sy;

			bool drawHoriz = false;
			if (Math.Abs(x2 - x1) > Math.Abs(y2 - y1))
			{
				drawHoriz = true;
			}

			while (true)
			{
				gr.DrawImageUnscaled(_pixelBitmap, pntx, pnty);

				if ((drawHoriz && pntx == x2)
				|| (!drawHoriz && pnty == y2))
					break;

				if (drawHoriz)
				{
					fx = f + dy;
					f = fx - dx;

					pntx += sx;
				}
				else
				{
					fx = f + dx;
					f = fx - dy;

					pnty += sy;
				}

				if (Math.Abs(fx) < Math.Abs(f))
					f = fx;
				else
					if (drawHoriz)
						pnty += sy;
					else
						pntx += sx;
			} //while
		}

		public static bool IsNearLine(double dist, int xm, int ym, int x1, int y1, int x2, int y2)
		{
			int pntx = x1;
			int pnty = y1;

			int f = 0;
			int fx;

			int dx = x2 - x1;
			int dy = y2 - y1;

			int sx = Math.Sign(dx);
			int sy = Math.Sign(dy);
			dx *= sx;
			dy *= sy;

			bool drawHoriz = false;
			if (Math.Abs(x2 - x1) > Math.Abs(y2 - y1))
			{
				drawHoriz = true;
			}

			while (true)
			{
				if(Math.Sqrt( (pntx - xm)*(pntx - xm) + (pnty - ym)*(pnty - ym) ) <= dist )
					return true;

				if ((drawHoriz && pntx == x2)
				|| (!drawHoriz && pnty == y2))
					break;

				if (drawHoriz)
				{
					fx = f + dy;
					f = fx - dx;

					pntx += sx;
				}
				else
				{
					fx = f + dx;
					f = fx - dy;

					pnty += sy;
				}

				if (Math.Abs(fx) < Math.Abs(f))
					f = fx;
				else
					if (drawHoriz)
						pnty += sy;
					else
						pntx += sx;
			} //while

			return false;
		}

		public static bool IsPointsEqual(Point p1, Point p2, int eps)
		{
			return Math.Abs(p2.X - p1.X) <= eps && Math.Abs(p2.Y - p1.Y) <= eps;
		}

		/// <summary>
		/// Нахождение точки пересечения отрезков ab и cd.
		/// </summary>
		/// <param name="a">Первая точка отрезка ab.</param>
		/// <param name="b">Вторая точка отрезка ab.</param>
		/// <param name="c">Первая точка отрезка cd.</param>
		/// <param name="d">Вторая точка отрезка cd.</param>
		/// <returns></returns>
/*		public static bool Intersect(Point a, Point b, Point c, Point d, out double t, out double T, out Point q)
		{
			Point v1 = new Point(b.X - a.X, b.Y - a.Y);
			Point v2 = new Point(c.X - d.X, c.Y - d.Y);

			Point n = new Point(-v2.Y, v2.X);
			int denom = n.X * v1.X + n.Y * v1.Y;

			if (denom == 0)
			{
				t = 0;
				T = 0;
				q = new Point();
				return false;
			}

			Point v3 = new Point(c.X - a.X, c.Y - a.Y);
			int num = n.X * v3.X + n.Y * v3.Y;
			t = num / (double) denom;
			T = 0;

			q = new Point(a.X + (int) (v1.X * t), a.Y + (int) (v1.Y * t));
			return 0 <= t && t <= 1 && 0 <= T && T <= 1;
		}*/

		public static bool Intersect(Point a, Point b, Point c, Point d, out double t, out double s, out Point q)
		{
			int ma,mb,mc,md,me,mf;
			int dt,ds,det;

			ma=b.X-a.X;
			mb=c.X-d.X;
			mc=c.X-a.X;
			md=b.Y-a.Y;
			me=c.Y-d.Y;
			mf=c.Y-a.Y;

			det=ma*me-mb*md;
			if (det == 0)
			{
				t = 0;
				s = 0;
				q = new Point();
				return false; // Параллельны.
			}

			dt=mc*me-mf*mb;
			ds=ma*mf-mc*md;
			t=dt/(double)det;
			s=ds/(double)det;

			if(0<=s && s<=1
				&& 0<=t && t<=1)
			{
				q = new Point();
				q.X = (int) ( a.X*(1-t)+b.X*t );
				q.Y = (int) ( a.Y*(1-t)+b.Y*t );
				return true; // Пересекаются.
			}

			q = new Point();
			return false; // Не параллельны и не пересекаются.
		}

/*		public static bool Intersect(Point a, Point b, Point c, Point d, out double t, out double s, out Point q)
		{
			q = new Point();
			int det = (b.Y - a.Y) * (c.X - d.X) - (c.Y - d.Y) * (b.X - a.X);
			int det1 = (c.Y - a.Y) * (c.X - d.X) - (c.Y - d.Y) * (c.X - a.X);
			int det2 = (b.Y - a.Y) * (c.X - a.X) - (c.Y - a.Y) * (b.X - a.X);
			t = 0;
			s = 0;
			if (det != 0)
			{
				t = det1 / (double) det;
				s = det2 / (double) det;
				if ((t <= 1) && (t >= 0) &&
				(s >= 0) && (s <= 1))
				{
					q.X = (int) ( a.X + (b.X - a.X) * t );
					q.Y = (int) ( a.Y + (b.Y - a.Y) * t );
					return true; // Пересекаются.
				}
			}
			if ((det1 == 0) && (det2 == 0))
			{
				if (a.X != b.X)
				{
					t = (c.X - a.X) / (b.X - a.X);
					s = (d.X - a.X) / (b.X - a.X);
				}
				else
				{
					if (a.Y != b.Y)
					{
						t = (c.Y - a.Y) / (b.Y - a.Y);
						s = (d.Y - a.Y) / (b.Y - a.Y);
					}
				}
				if (t > s)
				{
					double tmpt = s;
					q.X = c.X;
					q.Y = c.Y;
					s = t;
					c.X = d.X;
					c.Y = d.Y;
					t = tmpt;
					d.X = q.X;
					d.Y = q.Y;
				}
				if (t < 0)
				{
					if (s >= 1)
					{
						return false; // Совпадают.
					}
					else
					{
						if (s > 0)
						{
							return false; // Совпадают.
						}
						else
						{
							if (s == 0)
							{
								q.X = a.X;
								q.Y = a.Y;

								return true; // Пересекаются.
							}
						}
					}
				}
				else
				{
					if (t <= 1)
					{
						if (t == 1)
						{
							q.X = b.X;
							q.Y = b.Y;

							return true; // Пересекаются.
						}
						else
						{
							return false; // Совпадают.
						}
					}
				}
			}

			return false;
		} // Intersect*/

	} // class
}
