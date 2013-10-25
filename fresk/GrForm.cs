using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Aga.Controls.Tree;

using Virl.Fresk.Tools;
using Virl.Fresk.Primitives;
using Virl.Fresk.Compound;

namespace Virl.Fresk
{
	public partial class GrForm : Form
	{
		BrowserTreeModel _browserModel = null;
		GrGroup _page;

		public GrForm()
		{
			InitializeComponent();

			pointerButton.Tag = new Pointer();
			createPointBtn.Tag = new PointPlacer();
			createLineBtn.Tag = new LinePlacer();
			createHermiteBtn.Tag = new HermitePlacer();
			createBesieBtn.Tag = new BesiePlacer();

			propGrid.SelectedGridItemChanged += new SelectedGridItemChangedEventHandler(propGrid_SelectedGridItemChanged);
			
			_browserModel = new BrowserTreeModel();
			_page = new GrGroup(null);
			_page.Name = "Холст 1";
			_browserModel.Root.Objects.Add(_page);
			drawPanel.Root = _page;
			browserTree.Model = _browserModel;
			drawPanel.Tool = (ITool) pointerButton.Tag;

/*			Point a = new Point(10, 0);
			Point b = new Point(10, 10);
			Point c = new Point(6, 6);
			Point d = new Point(15, 6);
			double t, T;

			Point foo = new Point();
			bool bar = GrUtil.Intersect(a, b, c, d, out t, out T, out foo);*/

/*			Point a = new Point(-12, -12);
			Point b = new Point(12, 12);
			GrContour c = new GrContour(null);
			c.Objects.Add(new GrPoint(null, 0, 0));
			c.Objects.Add(new GrPoint(null, 0, 5));
			c.Objects.Add(new GrPoint(null, 5, 5));
			c.Objects.Add(new GrPoint(null, 5, 0));

			List<Point> inside = new List<Point>();
			List<Point> outside = new List<Point>();
			c.Region.Contours[0].CalcSegmentIntersection(a, b, inside, outside);*/

/*			List<Point> pnts = new List<Point>();
			pnts.Add(new Point(0, 10));
			pnts.Add(new Point(10, 10));

			pnts.Add(new Point(0, 0));
			pnts.Add(new Point(0, 10));

			pnts.Add(new Point(6, 6));
			pnts.Add(new Point(6, 15));

			pnts.Add(new Point(15, 15));
			pnts.Add(new Point(6, 15));

			pnts.Add(new Point(6, 6));
			pnts.Add(new Point(15, 6));

			pnts.Add(new Point(15, 15));
			pnts.Add(new Point(15, 6));

			pnts.Add(new Point(10, 10));
			pnts.Add(new Point(10, 0));

			pnts.Add(new Point(10, 0));
			pnts.Add(new Point(0, 0));

			BasicRegion reg = new BasicRegion();
			List<BasicContour> ls = BasicRegion.GenerateContours(pnts);*/

/*			BasicContour cont1 = new BasicContour();
			cont1.DrawningPoints.Add(new Point(0, 0));
			cont1.DrawningPoints.Add(new Point(0, 10));
			cont1.DrawningPoints.Add(new Point(10, 10));
			cont1.DrawningPoints.Add(new Point(10, 0));

			BasicContour cont2 = new BasicContour();
			cont2.DrawningPoints.Add(new Point(6, 15));
			cont2.DrawningPoints.Add(new Point(15, 15));
			cont2.DrawningPoints.Add(new Point(15, 6));
			cont2.DrawningPoints.Add(new Point(6, 6));

			BasicRegion reg1 = new BasicRegion();
			reg1.DrawningContours.Add(cont1);

			BasicRegion reg2 = new BasicRegion();
			reg2.DrawningContours.Add(cont2);
			
			reg1.CutOff(reg2, false);*/
		}

		void propGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
		{
			drawPanel.Invalidate();
		}

		private void clearPanelBtn_Click(object sender, EventArgs e)
		{
			drawPanel.Root.Objects.Clear();
			drawPanel.Invalidate();
		}

		private void uncheckAllInstumentButtons()
		{
			pointerButton.Checked = false;

			createPointBtn.Checked = false;

			createLineBtn.Checked = false;

			createHermiteBtn.Checked = false;

			createBesieBtn.Checked = false;
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<TreeNodeAdv> selNodes = new List<TreeNodeAdv>(browserTree.SelectedNodes);
			foreach (TreeNodeAdv node in selNodes)
			{
				(node.Tag as IGrObj).Parent.Objects
					.Remove(node.Tag as IGrObj);
			}

			drawPanel.Invalidate();
		}

		private void toolButton_Click(object sender, EventArgs e)
		{
			if ((sender as ToolStripButton).Checked)
				return;

			drawPanel.Tool = (sender as ToolStripButton).Tag as ITool;

			uncheckAllInstumentButtons();
			(sender as ToolStripButton).Checked = true;
		}

		private void browserTree_ItemDrag(object sender, ItemDragEventArgs e)
		{
			browserTree.DoDragDropSelectedNodes(DragDropEffects.Move);
		}

		private void browserTree_DragDrop(object sender, DragEventArgs e)
		{
			TreeNodeAdv[] nodes = (TreeNodeAdv[])e.Data.GetData(typeof(TreeNodeAdv[]));
			IGrObj dropNode = browserTree.DropPosition.Node.Tag as IGrObj;
			if (browserTree.DropPosition.Position == NodePosition.Inside
				&& !dropNode.IsPrimitive)
			{
				foreach (TreeNodeAdv n in nodes)
				{
					dropNode.Objects.Add(n.Tag as IGrObj);
				}

				browserTree.DropPosition.Node.IsExpanded = true;
			}
			else
			{
				IGrObj parent = dropNode.Parent;
				IGrObj nextItem = dropNode;
				if (browserTree.DropPosition.Position == NodePosition.After)
					nextItem = dropNode.NextObject;

				foreach (TreeNodeAdv node in nodes)
				{
					(node.Tag as IGrObj).Parent.Objects
						.Remove(node.Tag as IGrObj);
				}

				int index = -1;
				index = parent.Objects.IndexOf(nextItem);
				foreach (TreeNodeAdv node in nodes)
				{
					IGrObj item = node.Tag as IGrObj;
					if (index == -1)
						parent.Objects.Add(item);
					else
					{
						parent.Objects.Insert(index, item);
						index++;
					}
				}
			}

			drawPanel.Invalidate();
		}

		private void browserTree_DragOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TreeNodeAdv[])) && browserTree.DropPosition.Node != null)
			{
				TreeNodeAdv[] nodes = e.Data.GetData(typeof(TreeNodeAdv[])) as TreeNodeAdv[];
				TreeNodeAdv parent = browserTree.DropPosition.Node;
				if (browserTree.DropPosition.Position != NodePosition.Inside)
					parent = parent.Parent;

				foreach (TreeNodeAdv node in nodes)
					if (!CheckNodeParent(parent, node))
					{
						e.Effect = DragDropEffects.None;
						return;
					}

				e.Effect = e.AllowedEffect;
			}
		}

		private bool CheckNodeParent(TreeNodeAdv parent, TreeNodeAdv node)
		{
			while (parent != null)
			{
				if (node == parent)
					return false;
				else
					parent = parent.Parent;
			}
			return true;
		}

		private void browserTree_SelectionChanged(object sender, EventArgs e)
		{
			List<IGrObj> selObjs = new List<IGrObj>();
			drawPanel.ClearSelected();

			foreach(TreeNodeAdv node in browserTree.SelectedNodes)
			{
				selObjs.Add(node.Tag as IGrObj);
				drawPanel.AddToSelected(node.Tag as IGrObj);
			}

			propGrid.SelectedObjects = selObjs.ToArray();
		}

		private void groupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IGrObj parent = null;
			if (browserTree.SelectedNode != null)
			{
				parent = browserTree.SelectedNode.Tag as IGrObj;
			}
			else
			{
				parent = _page;
			}

			parent.Objects.Add(new GrGroup(null));
		}
		
		private void contourToolStripMenuItem_Click(object sender, EventArgs e)
		{
			IGrObj parent = null;
			GrContour contour = new GrContour(null);
			contour.Color = drawPanel.SpawnColor;

			if (browserTree.SelectedNodes.Count == 1
				&& (!(browserTree.SelectedNode.Tag as IGrObj).IsPrimitive))
			{
				parent = browserTree.SelectedNode.Tag as IGrObj;
			}
			else if(browserTree.SelectedNodes.Count == 0)
			{
				parent = _page;
			}
			else
			{
				parent = (browserTree.SelectedNode.Tag as IGrObj).Parent;

				List<TreeNodeAdv> nodes = new List<TreeNodeAdv>(browserTree.SelectedNodes);
				foreach (TreeNodeAdv node in nodes)
				{
					contour.Objects.Add(node.Tag as IGrObj);
				}
			}

			parent.Objects.Add(contour);
		}

        private void tsoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGrObj parent = null;
            if (browserTree.SelectedNode != null)
            {
                parent = browserTree.SelectedNode.Tag as IGrObj;
            }
            else
            {
                parent = _page;
            }

            parent.Objects.Add(new GrTso(null));
        }

		private void editCompoundToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(browserTree.SelectedNode != null
				&& !(browserTree.SelectedNode.Tag as IGrObj).IsPrimitive)
			{
				drawPanel.Edited = browserTree.SelectedNode.Tag as IGrObj;
				drawPanel.Invalidate();
			}
		}

		private void drawPanel_MouseMove(object sender, MouseEventArgs e)
		{
			coordLabel.Text = "X:" + e.X + " Y:" + e.Y;
		}

		private void drawPanel_MouseLeave(object sender, EventArgs e)
		{
			coordLabel.Text = "";
		}

		private void colorLabel_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				colorLabel.BackColor = colorDialog1.Color;
				drawPanel.SpawnColor = colorDialog1.Color;
			}
		}

		private void fillButton_Click(object sender, EventArgs e)
		{
			foreach (IGrObj grobj in drawPanel.SelectedObjects)
				grobj.Color = colorLabel.BackColor;
			drawPanel.Invalidate();
		}
	}
}