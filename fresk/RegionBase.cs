using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	/// <summary>
	/// ����������� �����, ���������� ������� ��� ����������
	/// ���������� IRegion. �������� � ���� ������ ���
	/// ���������� ���������-������������� �������� ���
	/// ���������.
	/// </summary>
	public abstract class RegionBase : IRegion
	{
		public RegionBase()
		{ 
		}

		#region IRegion Members

		public abstract ReadOnlyCollection<IContour> Contours
		{
			get;
		}

		public abstract void CutOff(IContour wnd, bool outer);

		public abstract void CutOff(IRegion wnd, bool outer);

		#endregion
	}
}
