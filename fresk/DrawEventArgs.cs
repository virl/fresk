using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Virl.Fresk.Primitives;

namespace Virl.Fresk
{
	public struct DrawEventArgs
	{
		Graphics _gr;
		IGrObj _edited;
		bool _draw;

		public DrawEventArgs(Graphics gr, IGrObj edited, bool draw)
		{
			_gr = gr;
			_edited = edited;
			_draw = draw;
		}

		public DrawEventArgs(DrawEventArgs args)
		{
			_gr = args._gr;
			_edited = args._edited;
			_draw = args._draw;
		}

		public Graphics Gr
		{
			get { return _gr; }
			set { _gr = value; }
		}

		public IGrObj Edited
		{
			get { return _edited; }
			set { _edited = value; }
		}

		public bool Draw
		{
			get { return _draw; }
			set { _draw = value; }
		}
	}
}
