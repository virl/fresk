using System;
using System.Collections.Generic;
using System.Text;

using Virl.Fresk.Primitives;

namespace Virl.Fresk.Compound
{
	public class GrGroup : GrObjBase
	{
		public GrGroup(IGrObj parent)
			: base(parent)
		{
			Name = "Группа";
		}

		public override bool IsPrimitive
		{
			get
			{
				return false;
			}
		}
	}
}
