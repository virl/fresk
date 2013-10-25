using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	/// <summary>
	/// ��������� ���������� �������, ���������� �� �����.
	/// ������������� ��������, ����������� ��� �������
	/// � ���������� �� ������.
	/// </summary>
	public interface IContour
	{
		/// <summary>
		/// ����� �������.
		/// </summary>
		ReadOnlyCollection<Point> Points
		{
			get;
		}

		/// <summary>
		/// ����� ����� ����������� ������� �� �������.
		/// </summary>
		/// <param name="row">�������� ������.</param>
		/// <param name="xl">���� �������� �������� �����.</param>
		void CalcRowIntersection(int row, ICollection<int> xl);

		/// <summary>
		/// ��������, ��������� �� ����� ������ �������.
		/// </summary>
		/// <param name="p">�����.</param>
		/// <returns>1 ���� ����� ����� ������ �������,
		/// 0 - ���� �� ��� �������,
		/// -1 - ���� ����� ��������� ��� �������.
		/// ����� false.</returns>
		bool IsInside(Point p);

		/// <summary>
		/// ����� ����� ��������� �������� �������.
		/// </summary>
		/// <param name="a">������ �������.</param>
		/// <param name="b">����� �������.</param>
		/// <param name="inside">���������, ���� ��������� ���������� ����� �������.</param>
		/// <param name="outside">���������, ���� ��������� ������� ����� �������.</param>
		void CalcSegmentIntersection(
			Point a,
			Point b,
			ICollection<Point> inside,
			ICollection<Point> outside
			);
	}
}
