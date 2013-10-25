using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	/// <summary>
	/// Интерфейс представления региона на плоскости.
	/// Отвечает за доступ к точкам границ контуров, составляющих
	/// регион, а также к другой информации о нем.
	/// </summary>
	public interface IRegion
	{
		/// <summary>
		/// Контуры данного региона. Могут быть соседними
		/// или вложенными.
		/// </summary>
		ReadOnlyCollection<IContour> Contours
		{
			get;
		}

		/// <summary>
		/// Отсекает от данного региона часть,
		/// описанную предоставленным контуром.
		/// </summary>
		/// <param name="contour">Контур-отсекатель.</param>
		/// <param name="outer">Тип отсечения: false - внутреннее,
		/// true - внешнее.</param>
		void CutOff(IContour wnd, bool outer);

		/// <summary>
		/// Отсекает от данного региона части,
		/// описанные предоставленным регионом.
		/// </summary>
		/// <param name="wnd">Регион-отсекатель.</param>
		/// <param name="outer">Тип отсечения: false - внутреннее,
		/// true - внешнее.</param>
		void CutOff(IRegion wnd, bool outer);
	}
}
