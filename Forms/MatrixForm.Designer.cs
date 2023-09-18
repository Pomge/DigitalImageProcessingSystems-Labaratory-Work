
namespace Paint.Forms {
	partial class MatrixForm {
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.buttonApply = new System.Windows.Forms.Button();
			this.labelColumnsText = new System.Windows.Forms.Label();
			this.labelRowsText = new System.Windows.Forms.Label();
			this.trackBarColumns = new System.Windows.Forms.TrackBar();
			this.trackBarRows = new System.Windows.Forms.TrackBar();
			this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
			this.labelColumns = new System.Windows.Forms.Label();
			this.labelRows = new System.Windows.Forms.Label();
			this.buttonMedian = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarColumns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRows)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToResizeColumns = false;
			this.dataGridView.AllowUserToResizeRows = false;
			this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView.ColumnHeadersHeight = 20;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView.ColumnHeadersVisible = false;
			this.dataGridView.Location = new System.Drawing.Point(12, 113);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.RowHeadersWidth = 20;
			this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridView.Size = new System.Drawing.Size(400, 200);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellEndEdit);
			// 
			// buttonApply
			// 
			this.buttonApply.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonApply.Location = new System.Drawing.Point(0, 343);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(424, 23);
			this.buttonApply.TabIndex = 1;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
			// 
			// labelColumnsText
			// 
			this.labelColumnsText.Location = new System.Drawing.Point(12, 9);
			this.labelColumnsText.Name = "labelColumnsText";
			this.labelColumnsText.Size = new System.Drawing.Size(98, 20);
			this.labelColumnsText.TabIndex = 5;
			this.labelColumnsText.Text = "Number of columns";
			this.labelColumnsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelRowsText
			// 
			this.labelRowsText.Location = new System.Drawing.Point(12, 35);
			this.labelRowsText.Name = "labelRowsText";
			this.labelRowsText.Size = new System.Drawing.Size(100, 20);
			this.labelRowsText.TabIndex = 6;
			this.labelRowsText.Text = "Number of rows";
			this.labelRowsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// trackBarColumns
			// 
			this.trackBarColumns.AutoSize = false;
			this.trackBarColumns.Location = new System.Drawing.Point(116, 9);
			this.trackBarColumns.Name = "trackBarColumns";
			this.trackBarColumns.Size = new System.Drawing.Size(230, 20);
			this.trackBarColumns.TabIndex = 7;
			this.trackBarColumns.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarColumns.Scroll += new System.EventHandler(this.TrackBarColumns_Scroll);
			// 
			// trackBarRows
			// 
			this.trackBarRows.AutoSize = false;
			this.trackBarRows.Location = new System.Drawing.Point(116, 35);
			this.trackBarRows.Name = "trackBarRows";
			this.trackBarRows.Size = new System.Drawing.Size(230, 20);
			this.trackBarRows.TabIndex = 8;
			this.trackBarRows.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBarRows.Scroll += new System.EventHandler(this.TrackBarRows_Scroll);
			// 
			// numericUpDownColumns
			// 
			this.numericUpDownColumns.Location = new System.Drawing.Point(352, 9);
			this.numericUpDownColumns.Name = "numericUpDownColumns";
			this.numericUpDownColumns.Size = new System.Drawing.Size(60, 20);
			this.numericUpDownColumns.TabIndex = 9;
			this.numericUpDownColumns.ValueChanged += new System.EventHandler(this.NumericUpDownColumns_ValueChanged);
			// 
			// numericUpDownRows
			// 
			this.numericUpDownRows.Location = new System.Drawing.Point(352, 35);
			this.numericUpDownRows.Name = "numericUpDownRows";
			this.numericUpDownRows.Size = new System.Drawing.Size(60, 20);
			this.numericUpDownRows.TabIndex = 10;
			this.numericUpDownRows.ValueChanged += new System.EventHandler(this.NumericUpDownRows_ValueChanged);
			// 
			// labelColumns
			// 
			this.labelColumns.Location = new System.Drawing.Point(12, 70);
			this.labelColumns.Name = "labelColumns";
			this.labelColumns.Size = new System.Drawing.Size(400, 20);
			this.labelColumns.TabIndex = 11;
			this.labelColumns.Text = "Columns";
			this.labelColumns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelRows
			// 
			this.labelRows.Location = new System.Drawing.Point(12, 90);
			this.labelRows.Name = "labelRows";
			this.labelRows.Size = new System.Drawing.Size(400, 20);
			this.labelRows.TabIndex = 12;
			this.labelRows.Text = "Rows";
			this.labelRows.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonMedian
			// 
			this.buttonMedian.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonMedian.Location = new System.Drawing.Point(0, 320);
			this.buttonMedian.Name = "buttonMedian";
			this.buttonMedian.Size = new System.Drawing.Size(424, 23);
			this.buttonMedian.TabIndex = 13;
			this.buttonMedian.Text = "Median filtering";
			this.buttonMedian.UseVisualStyleBackColor = true;
			this.buttonMedian.Click += new System.EventHandler(this.ButtonMedian_Click);
			// 
			// MatrixForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 366);
			this.Controls.Add(this.buttonMedian);
			this.Controls.Add(this.labelRows);
			this.Controls.Add(this.labelColumns);
			this.Controls.Add(this.numericUpDownRows);
			this.Controls.Add(this.numericUpDownColumns);
			this.Controls.Add(this.trackBarRows);
			this.Controls.Add(this.trackBarColumns);
			this.Controls.Add(this.labelRowsText);
			this.Controls.Add(this.labelColumnsText);
			this.Controls.Add(this.buttonApply);
			this.Controls.Add(this.dataGridView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MatrixForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Matrix";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarColumns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRows)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Label labelColumnsText;
		private System.Windows.Forms.Label labelRowsText;
		private System.Windows.Forms.TrackBar trackBarColumns;
		private System.Windows.Forms.TrackBar trackBarRows;
		private System.Windows.Forms.NumericUpDown numericUpDownColumns;
		private System.Windows.Forms.NumericUpDown numericUpDownRows;
		private System.Windows.Forms.Label labelColumns;
		private System.Windows.Forms.Label labelRows;
		private System.Windows.Forms.Button buttonMedian;
	}
}