using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Virl.Fresk.Primitives
{
	public class GrHermite : GrSplineBase
	{
		static double[,] Mh = new double[4, 4]
			{
				{ 2, -2,  1,  1},
				{-3,  3, -2, -1},
				{ 0,  0,  1,  0},
				{ 1,  0,  0,  0}
			};

		double[,] Gh = new double[4, 2];

		double[,] L = new double[4, 2];

		GrLine _line1;
		GrLine _line2;

		public GrHermite(IGrObj parent, GrLine line1, GrLine line2)
			: base(parent)
		{
			_line1 = line1;
			_line2 = line2;

			Objects.Add(_line1);
			Objects.Add(_line2);

			Name = "Кривая Эрмита";
		}

		protected override PointF GeneratePoint(double t)
		{
			Point pa1 = new Transform(_line1.First.Trans).Mult(this.Trans).Apply(0, 0);
			Point pa2 = new Transform(_line1.Second.Trans).Mult(this.Trans).Apply(0, 0);
			Point pb1 = new Transform(_line2.First.Trans).Mult(this.Trans).Apply(0, 0);
			Point pb2 = new Transform(_line2.Second.Trans).Mult(this.Trans).Apply(0, 0);

			Gh[0, 0] = pa1.X;
			Gh[0, 1] = pa1.Y;
			Gh[1, 0] = pb1.X;
			Gh[1, 1] = pb1.Y;
			Gh[2, 0] = pa2.X - pa1.X;
			Gh[2, 1] = pa2.Y - pa1.Y;
			Gh[3, 0] = pb2.X - pb1.X;
			Gh[3, 1] = pb2.Y - pb1.Y;

			for (int i = 0; i < 4; ++i)
				for (int j = 0; j < 2; ++j)
				{
					L[i, j] = 0;
					for (int n = 0; n < 4; ++n)
						L[i, j] += Mh[i, n] * Gh[n, j];
				}

			return new PointF(
				(float)(
				L[0, 0] * t * t * t +
				L[1, 0] * t * t +
				L[2, 0] * t +
				L[3, 0]
				),

				(float)(
				L[0, 1] * t * t * t +
				L[1, 1] * t * t +
				L[2, 1] * t +
				L[3, 1]
				)
				);
		}

		public override void Draw(DrawEventArgs e)
		{
			if (e.Draw || e.Edited == this)
			{
				DrawSpline(e.Gr);
			}

			if (e.Edited != this)
			{
				e.Draw = false;
			}
			_line1.Draw(e); _line2.Draw(e);
		}
	}
}
