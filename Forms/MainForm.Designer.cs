using MyPaint;

namespace Paint.Forms {
	partial class MainForm {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.panel = new System.Windows.Forms.Panel();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel_pictureBoxImageSize = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_mousePosition = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_zoomRatio = new System.Windows.Forms.ToolStripStatusLabel();
			this.pictureBox = new MyPaint.MyPictureBox();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showLayersPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.addNewLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mergeLayerDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.goToTopLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToLayerAboveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToLayerBelowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToBottomLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.moveLayerToTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveLayerUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveLayerDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.moveLayerToBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.layerPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.calculateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.curvesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.binarizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.matrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gaussianBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fourierTransformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel.SuspendLayout();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.AutoScroll = true;
			this.panel.AutoSize = true;
			this.panel.BackColor = System.Drawing.Color.Gray;
			this.panel.Controls.Add(this.statusStrip);
			this.panel.Controls.Add(this.pictureBox);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 24);
			this.panel.Margin = new System.Windows.Forms.Padding(0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(800, 426);
			this.panel.TabIndex = 0;
			this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
			this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_pictureBoxImageSize,
            this.toolStripStatusLabel_mousePosition,
            this.toolStripStatusLabel_zoomRatio});
			this.statusStrip.Location = new System.Drawing.Point(0, 404);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(800, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabel_pictureBoxImageSize
			// 
			this.toolStripStatusLabel_pictureBoxImageSize.BackColor = System.Drawing.SystemColors.Control;
			this.toolStripStatusLabel_pictureBoxImageSize.Name = "toolStripStatusLabel_pictureBoxImageSize";
			this.toolStripStatusLabel_pictureBoxImageSize.Size = new System.Drawing.Size(117, 17);
			this.toolStripStatusLabel_pictureBoxImageSize.Text = "pictureBoxImageSize";
			// 
			// toolStripStatusLabel_mousePosition
			// 
			this.toolStripStatusLabel_mousePosition.BackColor = System.Drawing.SystemColors.Control;
			this.toolStripStatusLabel_mousePosition.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
			this.toolStripStatusLabel_mousePosition.Name = "toolStripStatusLabel_mousePosition";
			this.toolStripStatusLabel_mousePosition.Size = new System.Drawing.Size(86, 17);
			this.toolStripStatusLabel_mousePosition.Text = "mousePosition";
			// 
			// toolStripStatusLabel_zoomRatio
			// 
			this.toolStripStatusLabel_zoomRatio.BackColor = System.Drawing.SystemColors.Control;
			this.toolStripStatusLabel_zoomRatio.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
			this.toolStripStatusLabel_zoomRatio.Name = "toolStripStatusLabel_zoomRatio";
			this.toolStripStatusLabel_zoomRatio.Size = new System.Drawing.Size(64, 17);
			this.toolStripStatusLabel_zoomRatio.Text = "zoomRatio";
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.White;
			this.pictureBox.Location = new System.Drawing.Point(75, 30);
			this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(650, 351);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.layersToolStripMenuItem,
            this.calculateToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(800, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator5,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator6,
            this.closeToolStripMenuItem,
            this.toolStripSeparator7,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.newToolStripMenuItem.Text = "New...";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(120, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.saveToolStripMenuItem.Text = "Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.saveAsToolStripMenuItem.Text = "Save As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(120, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.closeToolStripMenuItem.Text = "Close";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(120, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// layersToolStripMenuItem
			// 
			this.layersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLayersPanelToolStripMenuItem,
            this.toolStripSeparator4,
            this.addNewLayerToolStripMenuItem,
            this.deleteLayerToolStripMenuItem,
            this.duplicateLayerToolStripMenuItem,
            this.mergeLayerDownToolStripMenuItem,
            this.toolStripSeparator1,
            this.goToTopLayerToolStripMenuItem,
            this.goToLayerAboveToolStripMenuItem,
            this.goToLayerBelowToolStripMenuItem,
            this.goToBottomLayerToolStripMenuItem,
            this.toolStripSeparator2,
            this.moveLayerToTopToolStripMenuItem,
            this.moveLayerUpToolStripMenuItem,
            this.moveLayerDownToolStripMenuItem,
            this.moveLayerToBottomToolStripMenuItem,
            this.toolStripSeparator3,
            this.layerPropertiesToolStripMenuItem});
			this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
			this.layersToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.layersToolStripMenuItem.Text = "Layers";
			this.layersToolStripMenuItem.CheckedChanged += new System.EventHandler(this.LayersToolStripMenuItem_CheckedChanged);
			// 
			// showLayersPanelToolStripMenuItem
			// 
			this.showLayersPanelToolStripMenuItem.CheckOnClick = true;
			this.showLayersPanelToolStripMenuItem.Name = "showLayersPanelToolStripMenuItem";
			this.showLayersPanelToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.showLayersPanelToolStripMenuItem.Text = "Show Layers Panel";
			this.showLayersPanelToolStripMenuItem.CheckedChanged += new System.EventHandler(this.LayersToolStripMenuItem_CheckedChanged);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(189, 6);
			// 
			// addNewLayerToolStripMenuItem
			// 
			this.addNewLayerToolStripMenuItem.Name = "addNewLayerToolStripMenuItem";
			this.addNewLayerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.addNewLayerToolStripMenuItem.Text = "Add New Layer";
			this.addNewLayerToolStripMenuItem.Click += new System.EventHandler(this.AddNewLayerToolStripMenuItem_Click);
			// 
			// deleteLayerToolStripMenuItem
			// 
			this.deleteLayerToolStripMenuItem.Name = "deleteLayerToolStripMenuItem";
			this.deleteLayerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.deleteLayerToolStripMenuItem.Text = "Delete Layer";
			this.deleteLayerToolStripMenuItem.Click += new System.EventHandler(this.DeleteLayerToolStripMenuItem_Click);
			// 
			// duplicateLayerToolStripMenuItem
			// 
			this.duplicateLayerToolStripMenuItem.Name = "duplicateLayerToolStripMenuItem";
			this.duplicateLayerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.duplicateLayerToolStripMenuItem.Text = "Duplicate Layer";
			this.duplicateLayerToolStripMenuItem.Click += new System.EventHandler(this.DuplicateLayerToolStripMenuItem_Click);
			// 
			// mergeLayerDownToolStripMenuItem
			// 
			this.mergeLayerDownToolStripMenuItem.Enabled = false;
			this.mergeLayerDownToolStripMenuItem.Name = "mergeLayerDownToolStripMenuItem";
			this.mergeLayerDownToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.mergeLayerDownToolStripMenuItem.Text = "Merge Layer Down";
			this.mergeLayerDownToolStripMenuItem.Click += new System.EventHandler(this.MergeLayerDownToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
			// 
			// goToTopLayerToolStripMenuItem
			// 
			this.goToTopLayerToolStripMenuItem.Enabled = false;
			this.goToTopLayerToolStripMenuItem.Name = "goToTopLayerToolStripMenuItem";
			this.goToTopLayerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.goToTopLayerToolStripMenuItem.Text = "Go to Top Layer";
			this.goToTopLayerToolStripMenuItem.Click += new System.EventHandler(this.GoToTopLayerToolStripMenuItem_Click);
			// 
			// goToLayerAboveToolStripMenuItem
			// 
			this.goToLayerAboveToolStripMenuItem.Enabled = false;
			this.goToLayerAboveToolStripMenuItem.Name = "goToLayerAboveToolStripMenuItem";
			this.goToLayerAboveToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.goToLayerAboveToolStripMenuItem.Text = "Go to Layer Above";
			this.goToLayerAboveToolStripMenuItem.Click += new System.EventHandler(this.GoToLayerAboveToolStripMenuItem_Click);
			// 
			// goToLayerBelowToolStripMenuItem
			// 
			this.goToLayerBelowToolStripMenuItem.Enabled = false;
			this.goToLayerBelowToolStripMenuItem.Name = "goToLayerBelowToolStripMenuItem";
			this.goToLayerBelowToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.goToLayerBelowToolStripMenuItem.Text = "Go to Layer Below";
			this.goToLayerBelowToolStripMenuItem.Click += new System.EventHandler(this.GoToLayerBelowToolStripMenuItem_Click);
			// 
			// goToBottomLayerToolStripMenuItem
			// 
			this.goToBottomLayerToolStripMenuItem.Enabled = false;
			this.goToBottomLayerToolStripMenuItem.Name = "goToBottomLayerToolStripMenuItem";
			this.goToBottomLayerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.goToBottomLayerToolStripMenuItem.Text = "Go to Bottom Layer";
			this.goToBottomLayerToolStripMenuItem.Click += new System.EventHandler(this.GoToBottomLayerToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
			// 
			// moveLayerToTopToolStripMenuItem
			// 
			this.moveLayerToTopToolStripMenuItem.Enabled = false;
			this.moveLayerToTopToolStripMenuItem.Name = "moveLayerToTopToolStripMenuItem";
			this.moveLayerToTopToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.moveLayerToTopToolStripMenuItem.Text = "Move Layer to Top";
			this.moveLayerToTopToolStripMenuItem.Click += new System.EventHandler(this.MoveLayerToTopToolStripMenuItem_Click);
			// 
			// moveLayerUpToolStripMenuItem
			// 
			this.moveLayerUpToolStripMenuItem.Enabled = false;
			this.moveLayerUpToolStripMenuItem.Name = "moveLayerUpToolStripMenuItem";
			this.moveLayerUpToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.moveLayerUpToolStripMenuItem.Text = "Move Layer Up";
			this.moveLayerUpToolStripMenuItem.Click += new System.EventHandler(this.MoveLayerUpToolStripMenuItem_Click);
			// 
			// moveLayerDownToolStripMenuItem
			// 
			this.moveLayerDownToolStripMenuItem.Enabled = false;
			this.moveLayerDownToolStripMenuItem.Name = "moveLayerDownToolStripMenuItem";
			this.moveLayerDownToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.moveLayerDownToolStripMenuItem.Text = "Move Layer Down";
			this.moveLayerDownToolStripMenuItem.Click += new System.EventHandler(this.MoveLayerDownToolStripMenuItem_Click);
			// 
			// moveLayerToBottomToolStripMenuItem
			// 
			this.moveLayerToBottomToolStripMenuItem.Enabled = false;
			this.moveLayerToBottomToolStripMenuItem.Name = "moveLayerToBottomToolStripMenuItem";
			this.moveLayerToBottomToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.moveLayerToBottomToolStripMenuItem.Text = "Move Layer to Bottom";
			this.moveLayerToBottomToolStripMenuItem.Click += new System.EventHandler(this.MoveLayerToBottomToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
			// 
			// layerPropertiesToolStripMenuItem
			// 
			this.layerPropertiesToolStripMenuItem.Name = "layerPropertiesToolStripMenuItem";
			this.layerPropertiesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.layerPropertiesToolStripMenuItem.Text = "Layer Properties...";
			this.layerPropertiesToolStripMenuItem.Click += new System.EventHandler(this.LayerPropertiesToolStripMenuItem_Click);
			// 
			// calculateToolStripMenuItem
			// 
			this.calculateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.curvesToolStripMenuItem,
            this.binarizationToolStripMenuItem,
            this.matrixToolStripMenuItem,
            this.gaussianBlurToolStripMenuItem,
            this.fourierTransformToolStripMenuItem});
			this.calculateToolStripMenuItem.Name = "calculateToolStripMenuItem";
			this.calculateToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.calculateToolStripMenuItem.Text = "Correction";
			// 
			// curvesToolStripMenuItem
			// 
			this.curvesToolStripMenuItem.Name = "curvesToolStripMenuItem";
			this.curvesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.curvesToolStripMenuItem.Text = "Curves";
			this.curvesToolStripMenuItem.Click += new System.EventHandler(this.CurvesToolStripMenuItem_Click);
			// 
			// binarizationToolStripMenuItem
			// 
			this.binarizationToolStripMenuItem.Name = "binarizationToolStripMenuItem";
			this.binarizationToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.binarizationToolStripMenuItem.Text = "Binarization";
			this.binarizationToolStripMenuItem.Click += new System.EventHandler(this.BinarizationToolStripMenuItem_Click);
			// 
			// matrixToolStripMenuItem
			// 
			this.matrixToolStripMenuItem.Name = "matrixToolStripMenuItem";
			this.matrixToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.matrixToolStripMenuItem.Text = "Matrix";
			this.matrixToolStripMenuItem.Click += new System.EventHandler(this.MatrixToolStripMenuItem_Click);
			// 
			// gaussianBlurToolStripMenuItem
			// 
			this.gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
			this.gaussianBlurToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.gaussianBlurToolStripMenuItem.Text = "Gaussian Blur";
			this.gaussianBlurToolStripMenuItem.Click += new System.EventHandler(this.GaussianBlurToolStripMenuItem_Click);
			// 
			// fourierTransformToolStripMenuItem
			// 
			this.fourierTransformToolStripMenuItem.Name = "fourierTransformToolStripMenuItem";
			this.fourierTransformToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.fourierTransformToolStripMenuItem.Text = "Fourier Transform";
			this.fourierTransformToolStripMenuItem.Click += new System.EventHandler(this.FourierTransformToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "Painter";
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel;
		private MyPictureBox pictureBox;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_pictureBoxImageSize;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_mousePosition;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_zoomRatio;
		private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showLayersPanelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addNewLayerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteLayerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem duplicateLayerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mergeLayerDownToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToTopLayerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToLayerAboveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToLayerBelowToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem goToBottomLayerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveLayerToTopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveLayerUpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveLayerDownToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem moveLayerToBottomToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem layerPropertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem calculateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem curvesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem binarizationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem matrixToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gaussianBlurToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fourierTransformToolStripMenuItem;
	}
}

