
namespace Paint.Forms {
	partial class GaussianBlurForm {
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
			this.numericUpDownWindowSize = new System.Windows.Forms.NumericUpDown();
			this.trackBarWindowSize = new System.Windows.Forms.TrackBar();
			this.labelWinowSizeText = new System.Windows.Forms.Label();
			this.labelWindowSize = new System.Windows.Forms.Label();
			this.labelSum = new System.Windows.Forms.Label();
			this.buttonApply = new System.Windows.Forms.Button();
			this.numericUpDownSigma = new System.Windows.Forms.NumericUpDown();
			this.trackBarSigma = new System.Windows.Forms.TrackBar();
			this.labelSigmaText = new System.Windows.Forms.Label();
			this.labelSigma = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarWindowSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSigma)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSigma)).BeginInit();
			this.SuspendLayout();
			// 
			// numericUpDownWindowSize
			// 
			this.numericUpDownWindowSize.Location = new System.Drawing.Point(352, 9);
			this.numericUpDownWindowSize.Name = "numericUpDownWindowSize";
			this.numericUpDownWindowSize.Size = new System.Drawing.Size(60, 20);
			this.numericUpDownWindowSize.TabIndex = 12;
			this.numericUpDownWindowSize.ValueChanged += new System.EventHandler(this.NumericUpDownWindowSize_ValueChanged);
			// 
			// trackBarWindowSize
			// 
			this.trackBarWindowSize.AutoSize = false;
			this.trackBarWindowSize.Location = new System.Drawing.Point(116, 9);
			this.trackBarWindowSize.Name = "trackBarWindowSize";
			this.trackBarWindowSize.Size = new System.Drawing.Size(230, 20);
			this.trackBarWindowSize.TabIndex = 11;
			this.trackBarWindowSize.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarWindowSize.Scroll += new System.EventHandler(this.TrackBarWindowSize_Scroll);
			// 
			// labelWinowSizeText
			// 
			this.labelWinowSizeText.Location = new System.Drawing.Point(12, 9);
			this.labelWinowSizeText.Name = "labelWinowSizeText";
			this.labelWinowSizeText.Size = new System.Drawing.Size(98, 20);
			this.labelWinowSizeText.TabIndex = 10;
			this.labelWinowSizeText.Text = "Window size";
			this.labelWinowSizeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelWindowSize
			// 
			this.labelWindowSize.Location = new System.Drawing.Point(12, 58);
			this.labelWindowSize.Name = "labelWindowSize";
			this.labelWindowSize.Size = new System.Drawing.Size(400, 20);
			this.labelWindowSize.TabIndex = 13;
			this.labelWindowSize.Text = "Window size";
			this.labelWindowSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSum
			// 
			this.labelSum.Location = new System.Drawing.Point(12, 98);
			this.labelSum.Name = "labelSum";
			this.labelSum.Size = new System.Drawing.Size(400, 20);
			this.labelSum.TabIndex = 14;
			this.labelSum.Text = "Sum";
			this.labelSum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonApply
			// 
			this.buttonApply.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonApply.Location = new System.Drawing.Point(0, 128);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(424, 23);
			this.buttonApply.TabIndex = 15;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// numericUpDownSigma
			// 
			this.numericUpDownSigma.Location = new System.Drawing.Point(352, 35);
			this.numericUpDownSigma.Name = "numericUpDownSigma";
			this.numericUpDownSigma.Size = new System.Drawing.Size(60, 20);
			this.numericUpDownSigma.TabIndex = 18;
			this.numericUpDownSigma.ValueChanged += new System.EventHandler(this.NumericUpDownSigma_ValueChanged);
			// 
			// trackBarSigma
			// 
			this.trackBarSigma.AutoSize = false;
			this.trackBarSigma.Location = new System.Drawing.Point(116, 35);
			this.trackBarSigma.Name = "trackBarSigma";
			this.trackBarSigma.Size = new System.Drawing.Size(230, 20);
			this.trackBarSigma.TabIndex = 17;
			this.trackBarSigma.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarSigma.Scroll += new System.EventHandler(this.TrackBarSigma_Scroll);
			// 
			// labelSigmaText
			// 
			this.labelSigmaText.Location = new System.Drawing.Point(12, 35);
			this.labelSigmaText.Name = "labelSigmaText";
			this.labelSigmaText.Size = new System.Drawing.Size(98, 20);
			this.labelSigmaText.TabIndex = 16;
			this.labelSigmaText.Text = "Sigma";
			this.labelSigmaText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelSigma
			// 
			this.labelSigma.Location = new System.Drawing.Point(12, 78);
			this.labelSigma.Name = "labelSigma";
			this.labelSigma.Size = new System.Drawing.Size(400, 20);
			this.labelSigma.TabIndex = 19;
			this.labelSigma.Text = "Sigma";
			this.labelSigma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GaussianBlurForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 151);
			this.Controls.Add(this.labelSigma);
			this.Controls.Add(this.numericUpDownSigma);
			this.Controls.Add(this.trackBarSigma);
			this.Controls.Add(this.labelSigmaText);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.labelSum);
			this.Controls.Add(this.labelWindowSize);
			this.Controls.Add(this.numericUpDownWindowSize);
			this.Controls.Add(this.trackBarWindowSize);
			this.Controls.Add(this.labelWinowSizeText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GaussianBlurForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Gaussian Blur";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarWindowSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSigma)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSigma)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numericUpDownWindowSize;
		private System.Windows.Forms.TrackBar trackBarWindowSize;
		private System.Windows.Forms.Label labelWinowSizeText;
		private System.Windows.Forms.Label labelWindowSize;
		private System.Windows.Forms.Label labelSum;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.NumericUpDown numericUpDownSigma;
		private System.Windows.Forms.TrackBar trackBarSigma;
		private System.Windows.Forms.Label labelSigmaText;
		private System.Windows.Forms.Label labelSigma;
	}
}