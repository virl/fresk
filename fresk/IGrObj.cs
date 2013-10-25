using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Virl.Fresk
{
	public interface IGrObj
	{
		Transform Trans
		{
			get;
		}

		Transform GetObjectToWorldTransform();

		/// <summary>
		/// ���������� X.
		/// </summary>
		int X
		{
			get;
			set;
		}

		/// <summary>
		/// ���������� Y.
		/// </summary>
		int Y
		{
			get;
			set;
		}

		/// <summary>
		/// ������.
		/// </summary>
		int Width
		{
			get;
		}

		/// <summary>
		/// ������.
		/// </summary>
		int Height
		{
			get;
		}

		double Angle
		{
			get;
			set;
		}

		/// <summary>
		/// ������������ �������� �������.
		/// </summary>
		string Name
		{
			get;
			set;
		}

		Color Color
		{
			get;
			set;
		}

		/// <summary>
		/// ������������ ������.
		/// </summary>
		IGrObj Parent
		{
			get;
			set;
		}

		BrowserTreeModel Model
		{
			get;
			set;
		}

		/// <summary>
		/// �������� �� ������ ��������� ��� �����������.
		/// </summary>
		bool IsPrimitive
		{
			get;
		}

		bool IsInside(int x, int y);

		/// <summary>
		/// ������ �������.
		/// </summary>
		IRegion Region
		{
			get;
		}

		void Draw(DrawEventArgs e);

		/// <summary>
		/// ���������� �������, �� ������� ��������� ������.
		/// </summary>
		Collection<IGrObj> Objects
		{
			get;
		}

		BrowserTreeModel FindModel();

		IGrObj NextObject
		{
			get;
		}

		void OnStructureChanged(EventArgs e);
	}
}
