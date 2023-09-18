
namespace Paint.Forms {
	partial class BinarizationForm {
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
			this.comboBoxCriteria = new System.Windows.Forms.ComboBox();
			this.buttonApply = new System.Windows.Forms.Button();
			this.trackBar_a = new System.Windows.Forms.TrackBar();
			this.numericUpDown_a = new System.Windows.Forms.NumericUpDown();
			this.label_a = new System.Windows.Forms.Label();
			this.label_k = new System.Windows.Forms.Label();
			this.numericUpDown_k = new System.Windows.Forms.NumericUpDown();
			this.trackBar_k = new System.Windows.Forms.TrackBar();
			this.label_a_value = new System.Windows.Forms.Label();
			this.label_k_value = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_a)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_a)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_k)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_k)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBoxCriteria
			// 
			this.comboBoxCriteria.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBoxCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCriteria.FormattingEnabled = true;
			this.comboBoxCriteria.Items.AddRange(new object[] {
            "The Gavrilov criterion",
            "The Otsu criterion",
            "The Nibleck criterion",
            "The Sauvola Criterion",
            "The Christian Wulff Criterion",
            "The Bradley-Roth criterion"});
			this.comboBoxCriteria.Location = new System.Drawing.Point(0, 0);
			this.comboBoxCriteria.Name = "comboBoxCriteria";
			this.comboBoxCriteria.Size = new System.Drawing.Size(234, 21);
			this.comboBoxCriteria.TabIndex = 0;
			this.comboBoxCriteria.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCriteria_SelectedIndexChanged);
			// 
			// buttonApply
			// 
			this.buttonApply.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonApply.Location = new System.Drawing.Point(0, 118);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(234, 23);
			this.buttonApply.TabIndex = 1;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// trackBar_a
			// 
			this.trackBar_a.AutoSize = false;
			this.trackBar_a.Location = new System.Drawing.Point(38, 27);
			this.trackBar_a.Name = "trackBar_a";
			this.trackBar_a.Size = new System.Drawing.Size(120, 20);
			this.trackBar_a.TabIndex = 2;
			this.trackBar_a.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar_a.Scroll += new System.EventHandler(this.TrackBar_a_Scroll);
			// 
			// numericUpDown_a
			// 
			this.numericUpDown_a.Location = new System.Drawing.Point(164, 27);
			this.numericUpDown_a.Name = "numericUpDown_a";
			this.numericUpDown_a.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown_a.TabIndex = 3;
			this.numericUpDown_a.ValueChanged += new System.EventHandler(this.NumericUpDown_a_ValueChanged);
			// 
			// label_a
			// 
			this.label_a.Location = new System.Drawing.Point(12, 27);
			this.label_a.Name = "label_a";
			this.label_a.Size = new System.Drawing.Size(20, 20);
			this.label_a.TabIndex = 4;
			this.label_a.Text = "a";
			this.label_a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label_k
			// 
			this.label_k.Location = new System.Drawing.Point(12, 53);
			this.label_k.Name = "label_k";
			this.label_k.Size = new System.Drawing.Size(20, 20);
			this.label_k.TabIndex = 7;
			this.label_k.Text = "k";
			this.label_k.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// numericUpDown_k
			// 
			this.numericUpDown_k.Location = new System.Drawing.Point(164, 53);
			this.numericUpDown_k.Name = "numericUpDown_k";
			this.numericUpDown_k.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown_k.TabIndex = 6;
			this.numericUpDown_k.ValueChanged += new System.EventHandler(this.NumericUpDown_k_ValueChanged);
			// 
			// trackBar_k
			// 
			this.trackBar_k.AutoSize = false;
			this.trackBar_k.Location = new System.Drawing.Point(38, 53);
			this.trackBar_k.Name = "trackBar_k";
			this.trackBar_k.Size = new System.Drawing.Size(120, 20);
			this.trackBar_k.TabIndex = 5;
			this.trackBar_k.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar_k.Scroll += new System.EventHandler(this.TrackBar_k_Scroll);
			// 
			// label_a_value
			// 
			this.label_a_value.Location = new System.Drawing.Point(12, 73);
			this.label_a_value.Name = "label_a_value";
			this.label_a_value.Size = new System.Drawing.Size(210, 20);
			this.label_a_value.TabIndex = 8;
			this.label_a_value.Text = "label_a_value";
			this.label_a_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label_k_value
			// 
			this.label_k_value.Location = new System.Drawing.Point(12, 93);
			this.label_k_value.Name = "label_k_value";
			this.label_k_value.Size = new System.Drawing.Size(210, 20);
			this.label_k_value.TabIndex = 9;
			this.label_k_value.Text = "label_k_value";
			this.label_k_value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BinarizationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(234, 141);
			this.Controls.Add(this.label_k_value);
			this.Controls.Add(this.label_a_value);
			this.Controls.Add(this.label_k);
			this.Controls.Add(this.numericUpDown_k);
			this.Controls.Add(this.trackBar_k);
			this.Controls.Add(this.label_a);
			this.Controls.Add(this.numericUpDown_a);
			this.Controls.Add(this.trackBar_a);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.comboBoxCriteria);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BinarizationForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Binarization";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.trackBar_a)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_a)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_k)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_k)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxCriteria;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.TrackBar trackBar_a;
		private System.Windows.Forms.NumericUpDown numericUpDown_a;
		private System.Windows.Forms.Label label_a;
		private System.Windows.Forms.Label label_k;
		private System.Windows.Forms.NumericUpDown numericUpDown_k;
		private System.Windows.Forms.TrackBar trackBar_k;
		private System.Windows.Forms.Label label_a_value;
		private System.Windows.Forms.Label label_k_value;
	}
}