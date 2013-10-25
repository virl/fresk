namespace Virl.Fresk
{
	partial class GrForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrForm));
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.coordLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.drawPanel = new Virl.Fresk.GrPanel();
			this.propGrid = new System.Windows.Forms.PropertyGrid();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.browserTree = new Aga.Controls.Tree.TreeViewAdv();
			this.browserMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editCompoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nodeStateIcon1 = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
			this.nodeTextBox1 = new Aga.Controls.Tree.NodeControls.NodeTextBox();
			this.fillButton = new System.Windows.Forms.Button();
			this.colorLabel = new System.Windows.Forms.Label();
			this.instrumentStrip = new System.Windows.Forms.ToolStrip();
			this.pointerButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.createPointBtn = new System.Windows.Forms.ToolStripButton();
			this.createLineBtn = new System.Windows.Forms.ToolStripButton();
			this.createHermiteBtn = new System.Windows.Forms.ToolStripButton();
			this.createBesieBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.clearPanelBtn = new System.Windows.Forms.ToolStripButton();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.browserMenuStrip.SuspendLayout();
			this.instrumentStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(657, 526);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(657, 573);
			this.toolStripContainer1.TabIndex = 0;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.instrumentStrip);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 0);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(657, 22);
			this.statusStrip1.TabIndex = 2;
			// 
			// coordLabel
			// 
			this.coordLabel.Name = "coordLabel";
			this.coordLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.drawPanel);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(657, 526);
			this.splitContainer1.SplitterDistance = 447;
			this.splitContainer1.TabIndex = 0;
			// 
			// drawPanel
			// 
			this.drawPanel.BackColor = System.Drawing.Color.White;
			this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.drawPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.drawPanel.Edited = null;
			this.drawPanel.Grid = this.propGrid;
			this.drawPanel.Location = new System.Drawing.Point(0, 0);
			this.drawPanel.Name = "drawPanel";
			this.drawPanel.Root = null;
			this.drawPanel.Size = new System.Drawing.Size(447, 526);
			this.drawPanel.SpawnColor = System.Drawing.Color.Black;
			this.drawPanel.TabIndex = 0;
			this.drawPanel.Tool = null;
			this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
			this.drawPanel.MouseLeave += new System.EventHandler(this.drawPanel_MouseLeave);
			// 
			// propGrid
			// 
			this.propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.propGrid.Location = new System.Drawing.Point(0, 0);
			this.propGrid.Name = "propGrid";
			this.propGrid.Size = new System.Drawing.Size(206, 238);
			this.propGrid.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.browserTree);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.fillButton);
			this.splitContainer2.Panel2.Controls.Add(this.colorLabel);
			this.splitContainer2.Panel2.Controls.Add(this.propGrid);
			this.splitContainer2.Size = new System.Drawing.Size(206, 526);
			this.splitContainer2.SplitterDistance = 260;
			this.splitContainer2.TabIndex = 2;
			// 
			// browserTree
			// 
			this.browserTree.AllowDrop = true;
			this.browserTree.BackColor = System.Drawing.SystemColors.Window;
			this.browserTree.ContextMenuStrip = this.browserMenuStrip;
			this.browserTree.Cursor = System.Windows.Forms.Cursors.Default;
			this.browserTree.DefaultToolTipProvider = null;
			this.browserTree.DisplayDraggingNodes = true;
			this.browserTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.browserTree.DragDropMarkColor = System.Drawing.Color.Black;
			this.browserTree.LineColor = System.Drawing.SystemColors.ControlDark;
			this.browserTree.Location = new System.Drawing.Point(0, 0);
			this.browserTree.Model = null;
			this.browserTree.Name = "browserTree";
			this.browserTree.NodeControls.Add(this.nodeStateIcon1);
			this.browserTree.NodeControls.Add(this.nodeTextBox1);
			this.browserTree.Search.BackColor = System.Drawing.Color.Pink;
			this.browserTree.Search.FontColor = System.Drawing.Color.Black;
			this.browserTree.SelectedNode = null;
			this.browserTree.SelectionMode = Aga.Controls.Tree.TreeSelectionMode.MultiSameParent;
			this.browserTree.Size = new System.Drawing.Size(206, 260);
			this.browserTree.TabIndex = 1;
			this.browserTree.Text = "objectTree";
			this.browserTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.browserTree_ItemDrag);
			this.browserTree.SelectionChanged += new System.EventHandler(this.browserTree_SelectionChanged);
			this.browserTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.browserTree_DragDrop);
			this.browserTree.DragOver += new System.Windows.Forms.DragEventHandler(this.browserTree_DragOver);
			// 
			// browserMenuStrip
			// 
			this.browserMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.editCompoundToolStripMenuItem,
            this.toolStripSeparator2,
            this.deleteToolStripMenuItem});
			this.browserMenuStrip.Name = "browserMenuStrip";
			this.browserMenuStrip.Size = new System.Drawing.Size(165, 76);
			// 
			// createToolStripMenuItem
			// 
			this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupToolStripMenuItem,
            this.contourToolStripMenuItem,
            this.tsoToolStripMenuItem});
			this.createToolStripMenuItem.Name = "createToolStripMenuItem";
			this.createToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.createToolStripMenuItem.Text = "Создать";
			// 
			// groupToolStripMenuItem
			// 
			this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
			this.groupToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.groupToolStripMenuItem.Text = "Группу";
			this.groupToolStripMenuItem.Click += new System.EventHandler(this.groupToolStripMenuItem_Click);
			// 
			// contourToolStripMenuItem
			// 
			this.contourToolStripMenuItem.Name = "contourToolStripMenuItem";
			this.contourToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.contourToolStripMenuItem.Text = "Контур";
			this.contourToolStripMenuItem.Click += new System.EventHandler(this.contourToolStripMenuItem_Click);
			// 
			// tsoToolStripMenuItem
			// 
			this.tsoToolStripMenuItem.Name = "tsoToolStripMenuItem";
			this.tsoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.tsoToolStripMenuItem.Text = "ТМО";
			this.tsoToolStripMenuItem.Click += new System.EventHandler(this.tsoToolStripMenuItem_Click);
			// 
			// editCompoundToolStripMenuItem
			// 
			this.editCompoundToolStripMenuItem.Name = "editCompoundToolStripMenuItem";
			this.editCompoundToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.editCompoundToolStripMenuItem.Text = "Редактировать";
			this.editCompoundToolStripMenuItem.Click += new System.EventHandler(this.editCompoundToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(161, 6);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.deleteToolStripMenuItem.Text = "Удалить";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// nodeStateIcon1
			// 
			this.nodeStateIcon1.IncrementalSearchEnabled = false;
			// 
			// nodeTextBox1
			// 
			this.nodeTextBox1.DataPropertyName = "Name";
			// 
			// fillButton
			// 
			this.fillButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.fillButton.Location = new System.Drawing.Point(115, 241);
			this.fillButton.Name = "fillButton";
			this.fillButton.Size = new System.Drawing.Size(88, 21);
			this.fillButton.TabIndex = 2;
			this.fillButton.Text = "Закрасить";
			this.fillButton.UseVisualStyleBackColor = true;
			this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
			// 
			// colorLabel
			// 
			this.colorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.colorLabel.BackColor = System.Drawing.Color.Black;
			this.colorLabel.Location = new System.Drawing.Point(3, 241);
			this.colorLabel.Name = "colorLabel";
			this.colorLabel.Size = new System.Drawing.Size(106, 21);
			this.colorLabel.TabIndex = 1;
			this.colorLabel.Click += new System.EventHandler(this.colorLabel_Click);
			// 
			// instrumentStrip
			// 
			this.instrumentStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.instrumentStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerButton,
            this.toolStripSeparator1,
            this.createPointBtn,
            this.createLineBtn,
            this.createHermiteBtn,
            this.createBesieBtn,
            this.toolStripSeparator3,
            this.clearPanelBtn});
			this.instrumentStrip.Location = new System.Drawing.Point(3, 0);
			this.instrumentStrip.Name = "instrumentStrip";
			this.instrumentStrip.Size = new System.Drawing.Size(314, 25);
			this.instrumentStrip.TabIndex = 0;
			// 
			// pointerButton
			// 
			this.pointerButton.Checked = true;
			this.pointerButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
			this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pointerButton.Name = "pointerButton";
			this.pointerButton.Size = new System.Drawing.Size(65, 22);
			this.pointerButton.Text = "Указатель";
			this.pointerButton.Click += new System.EventHandler(this.toolButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// createPointBtn
			// 
			this.createPointBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.createPointBtn.Image = ((System.Drawing.Image)(resources.GetObject("createPointBtn.Image")));
			this.createPointBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createPointBtn.Name = "createPointBtn";
			this.createPointBtn.Size = new System.Drawing.Size(41, 22);
			this.createPointBtn.Text = "Точка";
			this.createPointBtn.Click += new System.EventHandler(this.toolButton_Click);
			// 
			// createLineBtn
			// 
			this.createLineBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.createLineBtn.Image = ((System.Drawing.Image)(resources.GetObject("createLineBtn.Image")));
			this.createLineBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createLineBtn.Name = "createLineBtn";
			this.createLineBtn.Size = new System.Drawing.Size(42, 22);
			this.createLineBtn.Text = "Линия";
			this.createLineBtn.Click += new System.EventHandler(this.toolButton_Click);
			// 
			// createHermiteBtn
			// 
			this.createHermiteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.createHermiteBtn.Image = ((System.Drawing.Image)(resources.GetObject("createHermiteBtn.Image")));
			this.createHermiteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createHermiteBtn.Name = "createHermiteBtn";
			this.createHermiteBtn.Size = new System.Drawing.Size(42, 22);
			this.createHermiteBtn.Text = "Эрмит";
			this.createHermiteBtn.Click += new System.EventHandler(this.toolButton_Click);
			// 
			// createBesieBtn
			// 
			this.createBesieBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.createBesieBtn.Image = ((System.Drawing.Image)(resources.GetObject("createBesieBtn.Image")));
			this.createBesieBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createBesieBtn.Name = "createBesieBtn";
			this.createBesieBtn.Size = new System.Drawing.Size(40, 22);
			this.createBesieBtn.Text = "Безье";
			this.createBesieBtn.Click += new System.EventHandler(this.toolButton_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// clearPanelBtn
			// 
			this.clearPanelBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.clearPanelBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearPanelBtn.Image")));
			this.clearPanelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearPanelBtn.Name = "clearPanelBtn";
			this.clearPanelBtn.Size = new System.Drawing.Size(60, 22);
			this.clearPanelBtn.Text = "Очистить";
			// 
			// GrForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 573);
			this.Controls.Add(this.toolStripContainer1);
			this.Name = "GrForm";
			this.Text = "Компьютерная графика";
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			this.browserMenuStrip.ResumeLayout(false);
			this.instrumentStrip.ResumeLayout(false);
			this.instrumentStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PropertyGrid propGrid;
		private System.Windows.Forms.ToolStrip instrumentStrip;
		private System.Windows.Forms.ToolStripButton createLineBtn;
		private System.Windows.Forms.ToolStripButton createPointBtn;
		private GrPanel drawPanel;
		private System.Windows.Forms.ToolStripButton pointerButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton createBesieBtn;
		private System.Windows.Forms.ToolStripButton createHermiteBtn;
		private Aga.Controls.Tree.TreeViewAdv browserTree;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ContextMenuStrip browserMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contourToolStripMenuItem;
		private Aga.Controls.Tree.NodeControls.NodeTextBox nodeTextBox1;
		private Aga.Controls.Tree.NodeControls.NodeStateIcon nodeStateIcon1;
        private System.Windows.Forms.ToolStripMenuItem tsoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editCompoundToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton clearPanelBtn;
		private System.Windows.Forms.ToolStripStatusLabel coordLabel;
		private System.Windows.Forms.Label colorLabel;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Button fillButton;

	}
}

