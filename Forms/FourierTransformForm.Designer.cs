
namespace Paint.Forms {
	partial class FourierTransformForm {
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
			this.buttonApply = new System.Windows.Forms.Button();
			this.checkBoxFilter = new System.Windows.Forms.CheckBox();
			this.trackBarOuterRadius = new System.Windows.Forms.TrackBar();
			this.numericUpDownOuterRadius = new System.Windows.Forms.NumericUpDown();
			this.labelOuterRadius = new System.Windows.Forms.Label();
			this.trackBarInnerRadius = new System.Windows.Forms.TrackBar();
			this.numericUpDownInnerRadius = new System.Windows.Forms.NumericUpDown();
			this.labelInnerRadius = new System.Windows.Forms.Label();
			this.comboBoxFilterMode = new System.Windows.Forms.ComboBox();
			this.pictureBoxVisualisation = new MyPaint.MyPictureBox();
			this.pictureBoxFourier = new MyPaint.MyPictureBox();
			this.pictureBoxResized = new MyPaint.MyPictureBox();
			((System.ComponentModel.ISupportInitialize)(this.trackBarOuterRadius)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOuterRadius)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarInnerRadius)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInnerRadius)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisualisation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFourier)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResized)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonApply
			// 
			this.buttonApply.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonApply.Location = new System.Drawing.Point(0, 496);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(996, 32);
			this.buttonApply.TabIndex = 3;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// checkBoxFilter
			// 
			this.checkBoxFilter.BackColor = System.Drawing.SystemColors.Control;
			this.checkBoxFilter.Checked = true;
			this.checkBoxFilter.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxFilter.Location = new System.Drawing.Point(12, 338);
			this.checkBoxFilter.Name = "checkBoxFilter";
			this.checkBoxFilter.Size = new System.Drawing.Size(82, 21);
			this.checkBoxFilter.TabIndex = 5;
			this.checkBoxFilter.Text = "Filter";
			this.checkBoxFilter.UseVisualStyleBackColor = false;
			this.checkBoxFilter.CheckedChanged += new System.EventHandler(this.CheckBoxFilter_CheckedChanged);
			// 
			// trackBarOuterRadius
			// 
			this.trackBarOuterRadius.AutoSize = false;
			this.trackBarOuterRadius.Location = new System.Drawing.Point(98, 365);
			this.trackBarOuterRadius.Maximum = 255;
			this.trackBarOuterRadius.Minimum = 1;
			this.trackBarOuterRadius.Name = "trackBarOuterRadius";
			this.trackBarOuterRadius.Size = new System.Drawing.Size(830, 20);
			this.trackBarOuterRadius.TabIndex = 15;
			this.trackBarOuterRadius.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarOuterRadius.Value = 1;
			this.trackBarOuterRadius.Scroll += new System.EventHandler(this.TrackBarOuterRadius_Scroll);
			// 
			// numericUpDownOuterRadius
			// 
			this.numericUpDownOuterRadius.Location = new System.Drawing.Point(934, 365);
			this.numericUpDownOuterRadius.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownOuterRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownOuterRadius.Name = "numericUpDownOuterRadius";
			this.numericUpDownOuterRadius.Size = new System.Drawing.Size(50, 20);
			this.numericUpDownOuterRadius.TabIndex = 14;
			this.numericUpDownOuterRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownOuterRadius.ValueChanged += new System.EventHandler(this.NumericUpDownOuterRadius_ValueChanged);
			// 
			// labelOuterRadius
			// 
			this.labelOuterRadius.Location = new System.Drawing.Point(12, 365);
			this.labelOuterRadius.Name = "labelOuterRadius";
			this.labelOuterRadius.Size = new System.Drawing.Size(80, 20);
			this.labelOuterRadius.TabIndex = 13;
			this.labelOuterRadius.Text = "Outer radius:";
			this.labelOuterRadius.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// trackBarInnerRadius
			// 
			this.trackBarInnerRadius.AutoSize = false;
			this.trackBarInnerRadius.Location = new System.Drawing.Point(98, 391);
			this.trackBarInnerRadius.Maximum = 255;
			this.trackBarInnerRadius.Minimum = 1;
			this.trackBarInnerRadius.Name = "trackBarInnerRadius";
			this.trackBarInnerRadius.Size = new System.Drawing.Size(830, 20);
			this.trackBarInnerRadius.TabIndex = 18;
			this.trackBarInnerRadius.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarInnerRadius.Value = 1;
			this.trackBarInnerRadius.Scroll += new System.EventHandler(this.TrackBarInnerRadius_Scroll);
			// 
			// numericUpDownInnerRadius
			// 
			this.numericUpDownInnerRadius.Location = new System.Drawing.Point(934, 391);
			this.numericUpDownInnerRadius.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownInnerRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownInnerRadius.Name = "numericUpDownInnerRadius";
			this.numericUpDownInnerRadius.Size = new System.Drawing.Size(50, 20);
			this.numericUpDownInnerRadius.TabIndex = 17;
			this.numericUpDownInnerRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownInnerRadius.ValueChanged += new System.EventHandler(this.NumericUpDownInnerRadius_ValueChanged);
			// 
			// labelInnerRadius
			// 
			this.labelInnerRadius.Location = new System.Drawing.Point(12, 391);
			this.labelInnerRadius.Name = "labelInnerRadius";
			this.labelInnerRadius.Size = new System.Drawing.Size(80, 20);
			this.labelInnerRadius.TabIndex = 16;
			this.labelInnerRadius.Text = "Inner radius:";
			this.labelInnerRadius.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxFilterMode
			// 
			this.comboBoxFilterMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFilterMode.Enabled = false;
			this.comboBoxFilterMode.FormattingEnabled = true;
			this.comboBoxFilterMode.Items.AddRange(new object[] {
            "Low-pass",
            "High-pass",
            "Notch",
            "Bandpass"});
			this.comboBoxFilterMode.Location = new System.Drawing.Point(100, 338);
			this.comboBoxFilterMode.Name = "comboBoxFilterMode";
			this.comboBoxFilterMode.Size = new System.Drawing.Size(232, 21);
			this.comboBoxFilterMode.TabIndex = 19;
			this.comboBoxFilterMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFilterMode_SelectedIndexChanged);
			// 
			// pictureBoxVisualisation
			// 
			this.pictureBoxVisualisation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxVisualisation.Location = new System.Drawing.Point(664, 12);
			this.pictureBoxVisualisation.Name = "pictureBoxVisualisation";
			this.pictureBoxVisualisation.Size = new System.Drawing.Size(320, 320);
			this.pictureBoxVisualisation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxVisualisation.TabIndex = 4;
			this.pictureBoxVisualisation.TabStop = false;
			// 
			// pictureBoxFourier
			// 
			this.pictureBoxFourier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxFourier.Location = new System.Drawing.Point(338, 12);
			this.pictureBoxFourier.Name = "pictureBoxFourier";
			this.pictureBoxFourier.Size = new System.Drawing.Size(320, 320);
			this.pictureBoxFourier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxFourier.TabIndex = 2;
			this.pictureBoxFourier.TabStop = false;
			// 
			// pictureBoxResized
			// 
			this.pictureBoxResized.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxResized.Name = "pictureBoxResized";
			this.pictureBoxResized.Size = new System.Drawing.Size(320, 320);
			this.pictureBoxResized.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxResized.TabIndex = 1;
			this.pictureBoxResized.TabStop = false;
			// 
			// FourierTransformForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(996, 528);
			this.Controls.Add(this.comboBoxFilterMode);
			this.Controls.Add(this.trackBarInnerRadius);
			this.Controls.Add(this.numericUpDownInnerRadius);
			this.Controls.Add(this.labelInnerRadius);
			this.Controls.Add(this.trackBarOuterRadius);
			this.Controls.Add(this.numericUpDownOuterRadius);
			this.Controls.Add(this.labelOuterRadius);
			this.Controls.Add(this.checkBoxFilter);
			this.Controls.Add(this.pictureBoxVisualisation);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.pictureBoxFourier);
			this.Controls.Add(this.pictureBoxResized);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FourierTransformForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Fourier Transform";
			((System.ComponentModel.ISupportInitialize)(this.trackBarOuterRadius)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOuterRadius)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarInnerRadius)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownInnerRadius)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisualisation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFourier)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxResized)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private MyPaint.MyPictureBox pictureBoxResized;
		private MyPaint.MyPictureBox pictureBoxFourier;
		private System.Windows.Forms.Button buttonApply;
		private MyPaint.MyPictureBox pictureBoxVisualisation;
		private System.Windows.Forms.CheckBox checkBoxFilter;
		private System.Windows.Forms.TrackBar trackBarOuterRadius;
		private System.Windows.Forms.NumericUpDown numericUpDownOuterRadius;
		private System.Windows.Forms.Label labelOuterRadius;
		private System.Windows.Forms.TrackBar trackBarInnerRadius;
		private System.Windows.Forms.NumericUpDown numericUpDownInnerRadius;
		private System.Windows.Forms.Label labelInnerRadius;
		private System.Windows.Forms.ComboBox comboBoxFilterMode;
	}
}