using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Drawing;

namespace Virl.Fresk
{
	/// <summary>
	/// Интерфейс замкнутого контура, состоящего из точек.
	/// Предоставляет свойства, необходимые для доступа
	/// к информации на чтение.
	/// </summary>
	public interface IContour
	{
		/// <summary>
		/// Точки контура.
		/// </summary>
		ReadOnlyCollection<Point> Points
		{
			get;
		}

		/// <summary>
		/// Найти точки пересечения контура со строкой.
		/// </summary>
		/// <param name="row">Ордината строки.</param>
		/// <param name="xl">Куда заносить абсциссы точек.</param>
		void CalcRowIntersection(int row, ICollection<int> xl);

		/// <summary>
		/// Проверка, находится ли точка внутри контура.
		/// </summary>
		/// <param name="p">Точка.</param>
		/// <returns>1 если точка лежит внутри контура,
		/// 0 - если на его границе,
		/// -1 - если точка находится вне контура.
		/// Иначе false.</returns>
		bool IsInside(Point p);

		/// <summary>
		/// Найти точки отсечения контуром отрезка.
		/// </summary>
		/// <param name="a">Начало отрезка.</param>
		/// <param name="b">Конец отрезка.</param>
		/// <param name="inside">Коллекция, куда добавлять внутренние части отрезка.</param>
		/// <param name="outside">Коллекция, куда добавлять внешние части отрезка.</param>
		void CalcSegmentIntersection(
			Point a,
			Point b,
			ICollection<Point> inside,
			ICollection<Point> outside
			);
	}
}
