using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Virl.Fresk
{
	public class Transform
	{
		double[,] m = new double[3, 3] {
			{1, 0, 0},
			{0, 1, 0},
			{0, 0, 1}
		};

		double[,] tmp = new double[3, 3];

		double[] c0 = new double[3];
		double[] c = new double[3];

		public Transform()
		{
		}

		public Transform(Transform trans)
		{
			for (int i = 0; i < 3; ++i)
				for (int j = 0; j < 3; ++j)
					this.m[i, j] = trans.m[i, j];
		}

		/// <summary>
		/// Загрузить единичную матрицу.
		/// </summary>
		public void LoadIdentity()
		{
			this.m = new double[3, 3] {
				{1, 0, 0},
				{0, 1, 0},
				{0, 0, 1}
			};
		}

/*		/// <summary>
		/// Сложить трансформации.
		/// </summary>
		/// <param name="trans">С чем перемножаем.</param>
		/// <returns>Новая трансформация.</returns>
		public Transform Add(Transform trans)
		{
			Transform ntr = new Transform(this);

			ntr.Mult(trans);

			return ntr;
		}*/

		/// <summary>
		/// Умножить данную трансформацию на другую.
		/// </summary>
		/// <param name="trans">С чем сливаем.</param>
		/// <returns>Эта же трансформация, но измененная.</returns>
		public Transform Mult(Transform trans, bool isBefore)
		{
			Mult(trans.m, isBefore);

			return this;
		}

		/// <summary>
		/// Умножить данную трансформацию на другую.
		/// </summary>
		/// <param name="trans">С чем сливаем.</param>
		/// <returns>Эта же трансформация, но измененная.</returns>
		public Transform Mult(Transform trans)
		{
			return Mult(trans, false);
		}

		private void Mult(double[,] mtr, bool isBefore)
		{
			for (int i = 0; i < 3; ++i)
				for (int j = 0; j < 3; ++j)
				{
					tmp[i, j] = 0;
					for (int n = 0; n < 3; ++n)
						if (isBefore)
							tmp[i, j] += mtr[i, n] * this.m[n, j];
						else
							tmp[i, j] += this.m[i, n] * mtr[n, j];
				}

			for (int i = 0; i < 3; ++i)
				for (int j = 0; j < 3; ++j)
					this.m[i, j] = tmp[i, j];
		}

		public PointF ApplyF(PointF pnt)
		{
			c0[0] = pnt.X;
			c0[1] = pnt.Y;
			c0[2] = 1;

			for (int j = 0; j < 3; ++j)
			{
				c[j] = 0;
				for (int n = 0; n < 3; ++n)
					c[j] += c0[n] * this.m[n, j];
			}

			return new PointF((float) c[0], (float) c[1]);
		}

		public PointF ApplyF(float x, float y)
		{
			return ApplyF(new PointF(x, y));
		}

		public Point Apply(Point pnt)
		{
			PointF pntf = ApplyF(new PointF(pnt.X, pnt.Y));

			return new Point((int) pntf.X, (int) pntf.Y);
		}

		public Point Apply(int x, int y)
		{
			return Apply(new Point(x, y));
		}

		/// <summary>
		/// Переместить систему координат на заданное расстояние.
		/// </summary>
		/// <param name="dx"></param>
		/// <param name="dy"></param>
		public void Move(double dx, double dy, bool isBefore)
		{
			double[,] mtr = new double[3, 3] {
				{1,  0,  0},
				{0,  1,  0},
				{dx, dy, 1}
			};

			this.Mult(mtr, isBefore);
		}

		/// <summary>
		/// Повернуть систему координат относительно центра
		/// координат.
		/// </summary>
		/// <param name="angle">Угол поворота в градусах.</param>
		public void Rotate(double da, bool isBefore)
		{
			double rad = da * Math.PI / 180;

			double[,] mtr = new double[3, 3] {
				{  Math.Cos(rad),  Math.Sin(rad),  0},
				{- Math.Sin(rad),  Math.Cos(rad),  0},
				{  0,              0,              1}
			};

			this.Mult(mtr, isBefore);
		}

		/// <summary>
		/// Нахождение определителя матрицы трансформации.
		/// </summary>
		/// <returns>Определитель.</returns>
		public double GetDeterminant()
		{
			return m[0, 0] * m[1, 1] * m[2, 2] + m[0, 1] * m[1, 2] * m[2, 0] + m[0, 2] * m[1, 0] * m[2, 1]
				- m[0, 2] * m[1, 1] * m[2, 0] - m[0, 0] * m[1, 2] * m[2, 1] - m[0, 1] * m[1, 0] * m[2, 2];
		}

		/// <summary>
		/// Получить обратную трансформацию.
		/// </summary>
		/// <returns>Трансформация, обратная данной.</returns>
		public Transform GetReverse()
		{
			double det = GetDeterminant();

			Transform ntr = new Transform();

			for (int i = 0; i < 3; ++i)
			for (int j = 0; j < 3; ++j)
			{
				double add = 0;
				for (int k = 0; k < 3; ++k)
				for (int p = 0; p < 3; ++p)
				{
					if ((k + p) % 2 == 0)
					{
						add += m[k, p];
					}
					else
					{
						add -= m[k, p];
					}
				}

				if ((i + j) % 2 != 0)
					add = -add;

				ntr.m[i, j] = add / det;
			}

			return ntr;
		}
	}
}
