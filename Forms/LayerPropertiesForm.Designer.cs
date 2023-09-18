
namespace Paint.Forms {
	partial class LayerPropertiesForm {
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
			this.labelLayerName = new System.Windows.Forms.TextBox();
			this.checkBoxVisible = new System.Windows.Forms.CheckBox();
			this.labelName = new System.Windows.Forms.Label();
			this.labelBlendingMode = new System.Windows.Forms.Label();
			this.comboBoxLayerMode = new System.Windows.Forms.ComboBox();
			this.labelOpacity = new System.Windows.Forms.Label();
			this.numericUpDownOpacity = new System.Windows.Forms.NumericUpDown();
			this.checkBoxChannelR = new System.Windows.Forms.CheckBox();
			this.checkBoxChannelG = new System.Windows.Forms.CheckBox();
			this.checkBoxChannelB = new System.Windows.Forms.CheckBox();
			this.labelColorChannels = new System.Windows.Forms.Label();
			this.trackBarOpacity = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
			this.SuspendLayout();
			// 
			// labelLayerName
			// 
			this.labelLayerName.Location = new System.Drawing.Point(99, 6);
			this.labelLayerName.Name = "labelLayerName";
			this.labelLayerName.Size = new System.Drawing.Size(173, 20);
			this.labelLayerName.TabIndex = 0;
			// 
			// checkBoxVisible
			// 
			this.checkBoxVisible.AutoSize = true;
			this.checkBoxVisible.Location = new System.Drawing.Point(15, 32);
			this.checkBoxVisible.Name = "checkBoxVisible";
			this.checkBoxVisible.Size = new System.Drawing.Size(56, 17);
			this.checkBoxVisible.TabIndex = 1;
			this.checkBoxVisible.Text = "Visible";
			this.checkBoxVisible.UseVisualStyleBackColor = true;
			this.checkBoxVisible.CheckedChanged += new System.EventHandler(this.CheckBoxVisible_CheckedChanged);
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(12, 9);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 2;
			this.labelName.Text = "Name:";
			// 
			// labelBlendingMode
			// 
			this.labelBlendingMode.AutoSize = true;
			this.labelBlendingMode.Location = new System.Drawing.Point(12, 52);
			this.labelBlendingMode.Name = "labelBlendingMode";
			this.labelBlendingMode.Size = new System.Drawing.Size(81, 13);
			this.labelBlendingMode.TabIndex = 3;
			this.labelBlendingMode.Text = "Blending Mode:";
			// 
			// comboBoxLayerMode
			// 
			this.comboBoxLayerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLayerMode.FormattingEnabled = true;
			this.comboBoxLayerMode.Items.AddRange(new object[] {
            "Normal",
            "Multiply",
            "Additive",
            "Overlay",
            "Difference",
            "Negation",
            "Lighten",
            "Darken",
            "Screen"});
			this.comboBoxLayerMode.Location = new System.Drawing.Point(99, 49);
			this.comboBoxLayerMode.Name = "comboBoxLayerMode";
			this.comboBoxLayerMode.Size = new System.Drawing.Size(173, 21);
			this.comboBoxLayerMode.TabIndex = 4;
			this.comboBoxLayerMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLayerMode_SelectedIndexChanged);
			// 
			// labelOpacity
			// 
			this.labelOpacity.AutoSize = true;
			this.labelOpacity.Location = new System.Drawing.Point(12, 80);
			this.labelOpacity.Name = "labelOpacity";
			this.labelOpacity.Size = new System.Drawing.Size(46, 13);
			this.labelOpacity.TabIndex = 5;
			this.labelOpacity.Text = "Opacity:";
			// 
			// numericUpDownOpacity
			// 
			this.numericUpDownOpacity.Location = new System.Drawing.Point(222, 78);
			this.numericUpDownOpacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numericUpDownOpacity.Name = "numericUpDownOpacity";
			this.numericUpDownOpacity.Size = new System.Drawing.Size(50, 20);
			this.numericUpDownOpacity.TabIndex = 7;
			this.numericUpDownOpacity.ValueChanged += new System.EventHandler(this.NumericUpDownOpacity_ValueChanged);
			// 
			// checkBoxChannelR
			// 
			this.checkBoxChannelR.AutoSize = true;
			this.checkBoxChannelR.Location = new System.Drawing.Point(99, 108);
			this.checkBoxChannelR.Name = "checkBoxChannelR";
			this.checkBoxChannelR.Size = new System.Drawing.Size(34, 17);
			this.checkBoxChannelR.TabIndex = 8;
			this.checkBoxChannelR.Text = "R";
			this.checkBoxChannelR.UseVisualStyleBackColor = true;
			this.checkBoxChannelR.CheckedChanged += new System.EventHandler(this.CheckBoxChannelR_CheckedChanged);
			// 
			// checkBoxChannelG
			// 
			this.checkBoxChannelG.AutoSize = true;
			this.checkBoxChannelG.Location = new System.Drawing.Point(139, 108);
			this.checkBoxChannelG.Name = "checkBoxChannelG";
			this.checkBoxChannelG.Size = new System.Drawing.Size(34, 17);
			this.checkBoxChannelG.TabIndex = 9;
			this.checkBoxChannelG.Text = "G";
			this.checkBoxChannelG.UseVisualStyleBackColor = true;
			this.checkBoxChannelG.CheckedChanged += new System.EventHandler(this.CheckBoxChannelG_CheckedChanged);
			// 
			// checkBoxChannelB
			// 
			this.checkBoxChannelB.AutoSize = true;
			this.checkBoxChannelB.Location = new System.Drawing.Point(179, 108);
			this.checkBoxChannelB.Name = "checkBoxChannelB";
			this.checkBoxChannelB.Size = new System.Drawing.Size(33, 17);
			this.checkBoxChannelB.TabIndex = 10;
			this.checkBoxChannelB.Text = "B";
			this.checkBoxChannelB.UseVisualStyleBackColor = true;
			this.checkBoxChannelB.CheckedChanged += new System.EventHandler(this.CheckBoxChannelB_CheckedChanged);
			// 
			// labelColorChannels
			// 
			this.labelColorChannels.AutoSize = true;
			this.labelColorChannels.Location = new System.Drawing.Point(12, 108);
			this.labelColorChannels.Name = "labelColorChannels";
			this.labelColorChannels.Size = new System.Drawing.Size(81, 13);
			this.labelColorChannels.TabIndex = 11;
			this.labelColorChannels.Text = "Color Channels:";
			// 
			// trackBarOpacity
			// 
			this.trackBarOpacity.AutoSize = false;
			this.trackBarOpacity.Location = new System.Drawing.Point(99, 78);
			this.trackBarOpacity.Maximum = 255;
			this.trackBarOpacity.Name = "trackBarOpacity";
			this.trackBarOpacity.Size = new System.Drawing.Size(117, 20);
			this.trackBarOpacity.TabIndex = 12;
			this.trackBarOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarOpacity.Scroll += new System.EventHandler(this.TrackBarOpacity_Scroll);
			// 
			// LayerPropertiesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 131);
			this.Controls.Add(this.trackBarOpacity);
			this.Controls.Add(this.labelColorChannels);
			this.Controls.Add(this.checkBoxChannelB);
			this.Controls.Add(this.checkBoxChannelG);
			this.Controls.Add(this.checkBoxChannelR);
			this.Controls.Add(this.numericUpDownOpacity);
			this.Controls.Add(this.labelOpacity);
			this.Controls.Add(this.comboBoxLayerMode);
			this.Controls.Add(this.labelBlendingMode);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.checkBoxVisible);
			this.Controls.Add(this.labelLayerName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LayerPropertiesForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Layer Properties";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox labelLayerName;
		private System.Windows.Forms.CheckBox checkBoxVisible;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelBlendingMode;
		private System.Windows.Forms.ComboBox comboBoxLayerMode;
		private System.Windows.Forms.Label labelOpacity;
		private System.Windows.Forms.NumericUpDown numericUpDownOpacity;
		private System.Windows.Forms.CheckBox checkBoxChannelR;
		private System.Windows.Forms.CheckBox checkBoxChannelG;
		private System.Windows.Forms.CheckBox checkBoxChannelB;
		private System.Windows.Forms.Label labelColorChannels;
		private System.Windows.Forms.TrackBar trackBarOpacity;
	}
}