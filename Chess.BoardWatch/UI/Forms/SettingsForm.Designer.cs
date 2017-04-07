namespace Chess.BoardWatch
{
    partial class SettingsForm
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
            this.nudThresh = new System.Windows.Forms.NumericUpDown();
            this.nudMinSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.LblVal = new System.Windows.Forms.Label();
            this.LblFullnessVal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TrackFullness = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.NudGlyphDivs = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.FilterCtrlRed = new Chess.BoardWatch.ColorUserControl();
            this.FilterCtrlBlue = new Chess.BoardWatch.ColorUserControl();
            this.FilterCtrlGreen = new Chess.BoardWatch.ColorUserControl();
            ((System.ComponentModel.ISupportInitialize)(this.nudThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackFullness)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudGlyphDivs)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudThresh
            // 
            this.nudThresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudThresh.Location = new System.Drawing.Point(91, 39);
            this.nudThresh.Name = "nudThresh";
            this.nudThresh.Size = new System.Drawing.Size(316, 20);
            this.nudThresh.TabIndex = 0;
            this.nudThresh.ValueChanged += new System.EventHandler(this.nudThresh_ValueChanged);
            // 
            // nudMinSize
            // 
            this.nudMinSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinSize.Location = new System.Drawing.Point(91, 72);
            this.nudMinSize.Name = "nudMinSize";
            this.nudMinSize.Size = new System.Drawing.Size(316, 20);
            this.nudMinSize.TabIndex = 1;
            this.nudMinSize.ValueChanged += new System.EventHandler(this.nudMinSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "thresh filter:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "min Size:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(91, 102);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(316, 27);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Shape Ratio:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblVal
            // 
            this.LblVal.AutoSize = true;
            this.LblVal.Location = new System.Drawing.Point(413, 99);
            this.LblVal.Name = "LblVal";
            this.LblVal.Size = new System.Drawing.Size(23, 13);
            this.LblVal.TabIndex = 6;
            this.LblVal.Text = "VAl";
            // 
            // LblFullnessVal
            // 
            this.LblFullnessVal.AutoSize = true;
            this.LblFullnessVal.Location = new System.Drawing.Point(413, 132);
            this.LblFullnessVal.Name = "LblFullnessVal";
            this.LblFullnessVal.Size = new System.Drawing.Size(23, 13);
            this.LblFullnessVal.TabIndex = 9;
            this.LblFullnessVal.Text = "VAl";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fullness:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrackFullness
            // 
            this.TrackFullness.Location = new System.Drawing.Point(91, 135);
            this.TrackFullness.Maximum = 100;
            this.TrackFullness.Name = "TrackFullness";
            this.TrackFullness.Size = new System.Drawing.Size(316, 27);
            this.TrackFullness.TabIndex = 7;
            this.TrackFullness.ValueChanged += new System.EventHandler(this.TrackFullness_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TrackFullness, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudThresh, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudMinSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblFullnessVal, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.LblVal, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NudGlyphDivs, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 165);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Glyph Divisions:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudGlyphDivs
            // 
            this.NudGlyphDivs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudGlyphDivs.Location = new System.Drawing.Point(91, 6);
            this.NudGlyphDivs.Name = "NudGlyphDivs";
            this.NudGlyphDivs.Size = new System.Drawing.Size(316, 20);
            this.NudGlyphDivs.TabIndex = 11;
            this.NudGlyphDivs.ValueChanged += new System.EventHandler(this.NudGlyphDivs_ValueChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.FilterCtrlRed, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.FilterCtrlBlue, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.FilterCtrlGreen, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 225);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(561, 418);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(90, 649);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(184, 32);
            this.BtnSave.TabIndex = 13;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(280, 649);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(184, 32);
            this.BtnLoad.TabIndex = 14;
            this.BtnLoad.Text = "Load";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // FilterCtrlRed
            // 
            this.FilterCtrlRed.AutoSize = true;
            this.FilterCtrlRed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterCtrlRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterCtrlRed.Location = new System.Drawing.Point(3, 3);
            this.FilterCtrlRed.Name = "FilterCtrlRed";
            this.FilterCtrlRed.Size = new System.Drawing.Size(555, 133);
            this.FilterCtrlRed.TabIndex = 10;
            this.FilterCtrlRed.Title = "Red Filter";
            this.FilterCtrlRed.ValueChanged += new System.Action<Chess.BoardWatch.ColorFilterSettings>(this.FilterCtrlRed_ValueChanged);
            // 
            // FilterCtrlBlue
            // 
            this.FilterCtrlBlue.AutoSize = true;
            this.FilterCtrlBlue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterCtrlBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterCtrlBlue.Location = new System.Drawing.Point(3, 142);
            this.FilterCtrlBlue.Name = "FilterCtrlBlue";
            this.FilterCtrlBlue.Size = new System.Drawing.Size(555, 133);
            this.FilterCtrlBlue.TabIndex = 11;
            this.FilterCtrlBlue.Title = "Blue Filter";
            this.FilterCtrlBlue.ValueChanged += new System.Action<Chess.BoardWatch.ColorFilterSettings>(this.FilterCtrlBlue_ValueChanged);
            // 
            // FilterCtrlGreen
            // 
            this.FilterCtrlGreen.AutoSize = true;
            this.FilterCtrlGreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterCtrlGreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterCtrlGreen.Location = new System.Drawing.Point(3, 281);
            this.FilterCtrlGreen.Name = "FilterCtrlGreen";
            this.FilterCtrlGreen.Size = new System.Drawing.Size(555, 134);
            this.FilterCtrlGreen.TabIndex = 12;
            this.FilterCtrlGreen.Title = "Green Filter";
            this.FilterCtrlGreen.ValueChanged += new System.Action<Chess.BoardWatch.ColorFilterSettings>(this.FilterCtrlGreen_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 693);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Activated += new System.EventHandler(this.SettingsForm_Activated);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackFullness)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudGlyphDivs)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudThresh;
        private System.Windows.Forms.NumericUpDown nudMinSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblVal;
        private System.Windows.Forms.Label LblFullnessVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar TrackFullness;
        private ColorUserControl FilterCtrlRed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ColorUserControl FilterCtrlBlue;
        private ColorUserControl FilterCtrlGreen;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudGlyphDivs;
    }
}