using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	public class BasicContour : ContourBase
	{
		List<Point> _pointsCol;
		ReadOnlyCollection<Point> _roPointCol;

		public BasicContour()
		{
			_pointsCol = new List<Point>();
			_roPointCol = new ReadOnlyCollection<Point>(_pointsCol);
		}

		public IList<Point> DrawningPoints
		{
			get { return _pointsCol; }
		}

		/// <summary>
		/// �������� ����� ������� �������, ��������
		/// � ��� �������������.
		/// </summary>
		/// <param name="contour">������, �� �������� ���������� �����.</param>
		/// <param name="trans">�������������, ������� ����������� � ������.</param>
		public void AddWithTransform(IContour contour, Transform trans)
		{
			foreach (Point pnt in contour.Points)
				DrawningPoints.Add(trans.Apply(pnt));
		}

		#region IContour Members

		public override ReadOnlyCollection<Point> Points
		{
			get { return _roPointCol; }
		}

		#endregion
	}
}
