using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk.Primitives
{
	public class GrContour : GrObjBase
	{
		List<int> _xl = new List<int>();
		List<int> _xr = new List<int>();
		bool _isOriented = false;
		Pen _pen;

		public GrContour(IGrObj parent) : base(parent)
		{
			Name = "Контур";
			_pen = new Pen(Color.Black);
		}

		public bool IsOriented
		{
			get
			{
				return _isOriented;
			}
			set
			{
				_isOriented = value;
			}
		}

		public override Color Color
		{
			get
			{
				return _pen.Color;
			}
			set
			{
				_pen.Color = value;
			}
		}

		void DrawNonOriented(Graphics gr)
		{
			IRegion region = GetTransformedRegion();

			int ymin = (int)gr.ClipBounds.Height;
			int ymax = 0;
			foreach (IContour cont in region.Contours)
			foreach(Point pnt in cont.Points)
			{
				if (pnt.Y < ymin)
				{
					ymin = pnt.Y;
				}
				if (pnt.Y > ymax)
				{
					ymax = pnt.Y;
				}
			}

			ymin = Math.Max(ymin, 0);
			ymax = Math.Min(ymax, (int)gr.ClipBounds.Height);

			Transform tr = GetObjectToWorldTransform();

			for (int yj = ymin; yj <= ymax; ++yj)
			{
				_xl.Clear();

				foreach (IContour cont in region.Contours)
					cont.CalcRowIntersection(yj, _xl);

				_xl.Sort();

				if(_xl.Count < 1)
					break;

				for (int f = 0; f < _xl.Count - 1; f += 2)
				{
					gr.DrawLine(
						_pen,
						_xl[f],
						yj,
						_xl[f + 1],
						yj
						);
				}
			} // for yj
		}

/*		void DrawOriented(Graphics gr)
		{
			IRegion region = GetTransformedRegion();

            int ymin = (int)(gr.ClipBounds.Y + gr.ClipBounds.Height);
			int ymax = 0;
			int j = 0;

			foreach (IContour cont in region)
			for (int i = 0; i < cont.Points.Count; ++i)
			{
				if (cont.Points[i].Y < ymin)
				{
					ymin = cont.Points[i].Y;
					j = i;
				}
				if (pnt[i].Y > ymax)
				{
					ymax = cont.Points[i].Y;
				}
			}

			ymin = Math.Max(ymin, 0);
			ymax = Math.Min(ymax, (int)(gr.ClipBounds.Y + gr.ClipBounds.Height));

			int jprev = j - 1; if (jprev == -1) jprev = pnt.Count - 1;
			int jnext = j + 1; if (jnext == pnt.Count) jnext = 0;

			double s = 0.5 * (
				pnt[jprev].X * pnt[j].Y +
				pnt[jnext].X * pnt[jprev].Y +
				pnt[j].X * pnt[jnext].Y
				- pnt[jnext].X * pnt[j].Y
				- pnt[jprev].X * pnt[jnext].Y
				- pnt[j].X * pnt[jprev].Y
				);

			if (s < 0)
			{
				for (int yj = 0; yj <= ymin; ++yj)
				{
					gr.DrawLine(
						_pen,
						0,
						yj,
						gr.ClipBounds.Width,
						yj
						);
				}

				for (int yj = ymax; yj <= gr.ClipBounds.Height; ++yj)
				{
					gr.DrawLine(
						_pen,
						0,
						yj,
						gr.ClipBounds.Width,
						yj
						);
				}
			}

			Transform tr = GetObjectToWorldTransform();

			for (int yj = ymin; yj <= ymax; ++yj)
			{
				_xl.Clear();
				_xr.Clear();

				int inext;
				int iprev;
				int n = pnt.Count - 1;

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

					int sdypred = Math.Sign(pnt[i].Y - pnt[iprev].Y);

					if (pnt[i].Y == yj)
					{
						if (sdypred == -1)
						{
							_xl.Add(pnt[i].X);
						}
						else if (sdypred == 1)
						{
							_xr.Add(pnt[i].X);
						}

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
							if (ski == -1)
							{
								_xr.Add(pnt[i].X);
							}
							else if (ski == 1)
							{
								_xl.Add(pnt[i].X);
							}
						}
					}
					else if ((pnt[i].Y < yj && pnt[inext].Y > yj)
							|| (pnt[i].Y > yj && pnt[inext].Y < yj))
					{
						int xi = (int)(
							(yj - pnt[i].Y) * (pnt[inext].X - pnt[i].X)
														/ ((double)(pnt[inext].Y - pnt[i].Y)) + pnt[i].X
							);

						if (pnt[inext].Y - pnt[i].Y > 0)
						{
							_xr.Add(xi);
						}
						else
						{
							_xl.Add(xi);
						}
					}
				} // for i

				if (s < 0)
				{
					_xl.Add(0);
					_xr.Add((int)gr.ClipBounds.Width);
				}

				_xl.Sort();
				_xr.Sort();

				for (int f = 0; f < Math.Min(_xl.Count, _xr.Count); ++f)
				{
					if (_xl[f] <= _xr[f])
					{
						gr.DrawLine(
							_pen,
							_xl[f],
							yj,
							_xr[f],
							yj
							);
					}
				}

			} // for yj
		}*/

		#region IGrObj Members


		public override bool IsInside(int x, int y)
		{
			IRegion region = GetTransformedRegion();

			_xl.Clear();
			foreach (IContour cont in region.Contours)
				cont.CalcRowIntersection(y, _xl);

			_xl.RemoveAll(new Predicate<int>(
				delegate(int target)
			{
				return target <= x;
			}));

			return _xl.Count % 2 != 0;
		}

		public override bool IsPrimitive
		{
			get
			{
				return false;
			}
		}

		public override void Draw(DrawEventArgs e)
		{
			if (Region.Contours.Count == 0
				|| Region.Contours[0].Points.Count < 3)
			{
				base.Draw(e);
				return;
			}

			if (e.Draw || e.Edited == this)
			{
				DrawNonOriented(e.Gr);
/*				if (_isOriented)
				{
					DrawOriented(e.Gr);
				}
				else
				{
					DrawNonOriented(e.Gr);
				}*/
			}

			if(e.Edited != this)
			{
				e.Draw = false;
			}
			base.Draw(e);
		}

		public override void OnStructureChanged(EventArgs e)
		{
			this.DrawningRegion.DrawningContours.Clear();
			BasicContour contour = new BasicContour();
			this.DrawningRegion.DrawningContours.Add(contour);

			foreach (IGrObj grobj in Objects)
			{
				foreach(IContour cont in grobj.Region.Contours)
				foreach (Point pnt in cont.Points)
				{
					contour.DrawningPoints.Add(grobj.Trans.Apply(pnt));
				}
			}

			base.OnStructureChanged(e);
		}

		#endregion
	}
}
