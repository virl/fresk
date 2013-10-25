using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	public class BasicRegion : RegionBase
	{
		List<BasicContour> _contCol;
		List<IContour> _icontCol;
		ReadOnlyCollection<IContour> _roContCol;

		public BasicRegion()
		{
			_contCol = new List<BasicContour>();
			_icontCol = new List<IContour>();
			_roContCol = new ReadOnlyCollection<IContour>(_icontCol as List<IContour>);
		}

		public IList<BasicContour> DrawningContours
		{
			get { return _contCol; }
		}

		/// <summary>
		/// Добавить контуры другого региона, применив к ним трансформацию.
		/// </summary>
		/// <param name="region">Регион, из которого будут копироваться контуры.</param>
		/// <param name="trans">Трансформация, которая будет применяться к контурам.</param>
		public void AddWithTransform(IRegion region, Transform trans)
		{
			foreach (IContour cont in region.Contours)
			{
				BasicContour ncont = new BasicContour();
				ncont.AddWithTransform(cont, trans);
				DrawningContours.Add(ncont);
			}
		}

		/// <summary>
		/// Сгенерировать контуры по списку отрезков.
		/// </summary>
		/// <param name="points">Массив начальных и конечных точек отрезков.
		/// ([0] - начало первого, [1] - конец первого, [2] - начало второго и т.п.)</param>
		/// <returns>Сгенерированные контуры.</returns>
		static List<BasicContour> GenerateContours(ICollection<Point> segments)
		{
			List<Point> segs = new List<Point>(segments);
			List<BasicContour> contours = new List<BasicContour>();
			if (segments.Count < 2 || segments.Count % 2 != 0)
				return contours;

			BasicContour cont = new BasicContour();
			cont.DrawningPoints.Add(segs[0]);
			cont.DrawningPoints.Add(segs[1]);
			segs.RemoveAt(0);
			segs.RemoveAt(0); // Не ошибка.

			while (segs.Count != 0)
			{
				bool inserted = false;

				for (int i = 0; i < segs.Count - 1; i += 2)
				{
					Point p1 = segs[i];
					Point p2 = segs[i+1];
					bool contFinished = false;

					if (GrUtil.IsPointsEqual(
						p1,
						cont.DrawningPoints[cont.DrawningPoints.Count - 1],
						2
						))
					{
						if(!GrUtil.IsPointsEqual(
							p2,
							cont.DrawningPoints[0],
							2
							))
						{
							cont.DrawningPoints.Add(p2);
						}
						else
						{
							contFinished = true;
						}

						inserted = true;

					}
					else
					if (GrUtil.IsPointsEqual(
						p2,
						cont.DrawningPoints[cont.DrawningPoints.Count - 1],
						2
						))
					{
						if (!GrUtil.IsPointsEqual(
							p1,
							cont.DrawningPoints[0],
							2
							))
						{
							cont.DrawningPoints.Add(p1);
						}
						else
						{
							contFinished = true;
						}
						inserted = true;
					}

					if (inserted)
					{
						segs.RemoveAt(i);
						segs.RemoveAt(i); // Не ошибка.

						if (contFinished)
						{
							contours.Add(cont);
							cont = null;

							if (segs.Count >= 2)
							{
								cont = new BasicContour();
								cont.DrawningPoints.Add(segs[0]);
								cont.DrawningPoints.Add(segs[1]);
								segs.RemoveAt(0);
								segs.RemoveAt(0); // Не ошибка.
							}
						}

						break;
					}

				} // for i
			} // while

			if (cont != null)
				contours.Add(cont);

			return contours;
		}

		#region IRegion Members

		public override ReadOnlyCollection<IContour> Contours
		{
			get
			{
				_icontCol.Clear();
				foreach (BasicContour cont in _contCol)
					_icontCol.Add(cont);

				return _roContCol;
			}
		}

		public override void CutOff(IContour wnd, bool outer)
		{
			List<Point> segments = new List<Point>();

			int inext;
			int iprev;

			foreach (IContour cont in this.Contours)
			{
				for(int i = 0, n = cont.Points.Count - 1; i <= n; ++i)
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

					if (outer)
					{
						wnd.CalcSegmentIntersection(
							cont.Points[i],
							cont.Points[inext],
							null,
							segments
							);
					}
					else
					{
						wnd.CalcSegmentIntersection(
							cont.Points[i],
							cont.Points[inext],
							segments,
							null
							);
					}
				}

				for (int i = 0, n = wnd.Points.Count - 1; i <= n; ++i)
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

					cont.CalcSegmentIntersection(
						wnd.Points[i],
						wnd.Points[inext],
						null,
						segments
						);
				}

			} // foreach cont

			_contCol.Clear();
			_contCol.AddRange(BasicRegion.GenerateContours(segments));
		}

		public override void CutOff(IRegion wnd, bool outer)
		{
			foreach (IContour cont in wnd.Contours)
			{
				this.CutOff(cont, outer);
			}
		}

		#endregion
	}
}
