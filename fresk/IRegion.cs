using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	/// <summary>
	/// ��������� ������������� ������� �� ���������.
	/// �������� �� ������ � ������ ������ ��������, ������������
	/// ������, � ����� � ������ ���������� � ���.
	/// </summary>
	public interface IRegion
	{
		/// <summary>
		/// ������� ������� �������. ����� ���� ���������
		/// ��� ����������.
		/// </summary>
		ReadOnlyCollection<IContour> Contours
		{
			get;
		}

		/// <summary>
		/// �������� �� ������� ������� �����,
		/// ��������� ��������������� ��������.
		/// </summary>
		/// <param name="contour">������-����������.</param>
		/// <param name="outer">��� ���������: false - ����������,
		/// true - �������.</param>
		void CutOff(IContour wnd, bool outer);

		/// <summary>
		/// �������� �� ������� ������� �����,
		/// ��������� ��������������� ��������.
		/// </summary>
		/// <param name="wnd">������-����������.</param>
		/// <param name="outer">��� ���������: false - ����������,
		/// true - �������.</param>
		void CutOff(IRegion wnd, bool outer);
	}
}
