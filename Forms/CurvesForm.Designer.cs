
namespace Paint.Forms {
	partial class CurvesForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelCoords = new System.Windows.Forms.ToolStripStatusLabel();
			this.checkBoxRed = new System.Windows.Forms.CheckBox();
			this.checkBoxGreen = new System.Windows.Forms.CheckBox();
			this.checkBoxBlue = new System.Windows.Forms.CheckBox();
			this.pictureBoxHistogram = new MyPaint.MyPictureBox();
			this.checkBoxOriginal = new System.Windows.Forms.CheckBox();
			this.toolStripStatusLabelReset = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
			this.statusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxGraph
			// 
			this.pictureBoxGraph.Location = new System.Drawing.Point(2, 35);
			this.pictureBoxGraph.Name = "pictureBoxGraph";
			this.pictureBoxGraph.Size = new System.Drawing.Size(256, 256);
			this.pictureBoxGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxGraph.TabIndex = 3;
			this.pictureBoxGraph.TabStop = false;
			this.pictureBoxGraph.Click += new System.EventHandler(this.PictureBoxGraph_Click);
			this.pictureBoxGraph.MouseLeave += new System.EventHandler(this.PictureBoxGraph_MouseLeave);
			this.pictureBoxGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxGraph_MouseMove);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCoords,
            this.toolStripStatusLabelReset});
			this.statusStrip.Location = new System.Drawing.Point(0, 551);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(260, 22);
			this.statusStrip.SizingGrip = false;
			this.statusStrip.TabIndex = 4;
			this.statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabelCoords
			// 
			this.toolStripStatusLabelCoords.Name = "toolStripStatusLabelCoords";
			this.toolStripStatusLabelCoords.Size = new System.Drawing.Size(45, 17);
			this.toolStripStatusLabelCoords.Text = "Coords";
			// 
			// checkBoxRed
			// 
			this.checkBoxRed.AutoSize = true;
			this.checkBoxRed.Checked = true;
			this.checkBoxRed.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxRed.Location = new System.Drawing.Point(12, 12);
			this.checkBoxRed.Name = "checkBoxRed";
			this.checkBoxRed.Size = new System.Drawing.Size(46, 17);
			this.checkBoxRed.TabIndex = 5;
			this.checkBoxRed.Text = "Red";
			this.checkBoxRed.UseVisualStyleBackColor = true;
			this.checkBoxRed.CheckedChanged += new System.EventHandler(this.CheckBoxRed_CheckedChanged);
			// 
			// checkBoxGreen
			// 
			this.checkBoxGreen.AutoSize = true;
			this.checkBoxGreen.Checked = true;
			this.checkBoxGreen.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxGreen.Location = new System.Drawing.Point(64, 12);
			this.checkBoxGreen.Name = "checkBoxGreen";
			this.checkBoxGreen.Size = new System.Drawing.Size(55, 17);
			this.checkBoxGreen.TabIndex = 6;
			this.checkBoxGreen.Text = "Green";
			this.checkBoxGreen.UseVisualStyleBackColor = true;
			this.checkBoxGreen.CheckedChanged += new System.EventHandler(this.CheckBoxGreen_CheckedChanged);
			// 
			// checkBoxBlue
			// 
			this.checkBoxBlue.AutoSize = true;
			this.checkBoxBlue.Checked = true;
			this.checkBoxBlue.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxBlue.Location = new System.Drawing.Point(125, 12);
			this.checkBoxBlue.Name = "checkBoxBlue";
			this.checkBoxBlue.Size = new System.Drawing.Size(47, 17);
			this.checkBoxBlue.TabIndex = 7;
			this.checkBoxBlue.Text = "Blue";
			this.checkBoxBlue.UseVisualStyleBackColor = true;
			this.checkBoxBlue.CheckedChanged += new System.EventHandler(this.CheckBoxBlue_CheckedChanged);
			// 
			// pictureBoxHistogram
			// 
			this.pictureBoxHistogram.Location = new System.Drawing.Point(2, 293);
			this.pictureBoxHistogram.Name = "pictureBoxHistogram";
			this.pictureBoxHistogram.Size = new System.Drawing.Size(256, 255);
			this.pictureBoxHistogram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxHistogram.TabIndex = 2;
			this.pictureBoxHistogram.TabStop = false;
			// 
			// checkBoxOriginal
			// 
			this.checkBoxOriginal.AutoSize = true;
			this.checkBoxOriginal.Location = new System.Drawing.Point(178, 12);
			this.checkBoxOriginal.Name = "checkBoxOriginal";
			this.checkBoxOriginal.Size = new System.Drawing.Size(61, 17);
			this.checkBoxOriginal.TabIndex = 8;
			this.checkBoxOriginal.Text = "Original";
			this.checkBoxOriginal.UseVisualStyleBackColor = true;
			this.checkBoxOriginal.CheckedChanged += new System.EventHandler(this.CheckBoxOriginal_CheckedChanged);
			// 
			// toolStripStatusLabelReset
			// 
			this.toolStripStatusLabelReset.Name = "toolStripStatusLabelReset";
			this.toolStripStatusLabelReset.Size = new System.Drawing.Size(35, 17);
			this.toolStripStatusLabelReset.Text = "Reset";
			this.toolStripStatusLabelReset.Click += new System.EventHandler(this.ToolStripStatusLabelReset_Click);
			// 
			// CurvesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 573);
			this.Controls.Add(this.checkBoxOriginal);
			this.Controls.Add(this.checkBoxBlue);
			this.Controls.Add(this.checkBoxGreen);
			this.Controls.Add(this.checkBoxRed);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.pictureBoxGraph);
			this.Controls.Add(this.pictureBoxHistogram);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CurvesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Curves";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private MyPaint.MyPictureBox pictureBoxHistogram;
		private System.Windows.Forms.PictureBox pictureBoxGraph;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCoords;
		private System.Windows.Forms.CheckBox checkBoxRed;
		private System.Windows.Forms.CheckBox checkBoxGreen;
		private System.Windows.Forms.CheckBox checkBoxBlue;
		private System.Windows.Forms.CheckBox checkBoxOriginal;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelReset;
	}
}