using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Virl.Fresk.Primitives;

namespace Virl.Fresk.Compound
{
	public class GrTso : GrContour
	{
		// Тип ТМО.
		public enum TsoType
		{
			Addition,		// Объединение
			Intersection,	// Пересечение
			Xor,			// Исключающее ИЛИ
			Substraction	// Вычитание
		}

		TsoType _tsoType = TsoType.Addition;

		public GrTso(IGrObj parent)
			: base(parent)
		{
			Name = "ТМО";
		}

		public TsoType Tso
		{
			get { return _tsoType; }
			set { _tsoType = value; }
		}

		public override bool IsPrimitive
		{
			get
			{
				return false;
			}
		}

		public override void OnStructureChanged(EventArgs e)
		{
			if (this.Objects.Count > 0)
			{
				this.DrawningRegion.DrawningContours.Clear();

				this.DrawningRegion.AddWithTransform(
					this.Objects[0].Region,
					this.Objects[0].Trans
					);

				for(int i = 1; i < this.Objects.Count; ++i)
				{
					BasicRegion region = new BasicRegion();
					region.AddWithTransform(
						this.Objects[i].Region,
						this.Objects[i].Trans
						);

					this.Region.CutOff(
						region,
						false
						);
				}
			}

			if (Parent != null)
			{
				Parent.OnStructureChanged(e);
			}
		}
	}
}
