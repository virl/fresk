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
		/// Координата X.
		/// </summary>
		int X
		{
			get;
			set;
		}

		/// <summary>
		/// Координата Y.
		/// </summary>
		int Y
		{
			get;
			set;
		}

		/// <summary>
		/// Ширина.
		/// </summary>
		int Width
		{
			get;
		}

		/// <summary>
		/// Высота.
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
		/// Отображаемое название объекта.
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
		/// Родительский объект.
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
		/// Является ли объект составным или примитивным.
		/// </summary>
		bool IsPrimitive
		{
			get;
		}

		bool IsInside(int x, int y);

		/// <summary>
		/// Регион объекта.
		/// </summary>
		IRegion Region
		{
			get;
		}

		void Draw(DrawEventArgs e);

		/// <summary>
		/// Возвращает объекты, из которых составлен данный.
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
