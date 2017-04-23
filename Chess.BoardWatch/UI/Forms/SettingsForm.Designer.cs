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
            this.NudMaxSize = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.FilterCtrlRed = new Chess.BoardWatch.ColorUserControl();
            this.FilterCtrlBlue = new Chess.BoardWatch.ColorUserControl();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.betterPanel1 = new Chess.BoardWatch.BetterPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.RedPanel = new Chess.BoardWatch.BetterPanel();
            this.BluePanel = new Chess.BoardWatch.BetterPanel();
            this.RadEyeOff = new System.Windows.Forms.RadioButton();
            this.RadBlueEye = new System.Windows.Forms.RadioButton();
            this.RadRedEye = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackFullness)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudGlyphDivs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudMaxSize)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudThresh
            // 
            this.nudThresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudThresh.Location = new System.Drawing.Point(91, 38);
            this.nudThresh.Name = "nudThresh";
            this.nudThresh.Size = new System.Drawing.Size(316, 20);
            this.nudThresh.TabIndex = 0;
            this.nudThresh.ValueChanged += new System.EventHandler(this.nudThresh_ValueChanged);
            // 
            // nudMinSize
            // 
            this.nudMinSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinSize.Location = new System.Drawing.Point(91, 70);
            this.nudMinSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinSize.Name = "nudMinSize";
            this.nudMinSize.Size = new System.Drawing.Size(316, 20);
            this.nudMinSize.TabIndex = 1;
            this.nudMinSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMinSize.ValueChanged += new System.EventHandler(this.nudMinSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 41);
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
            this.label2.Location = new System.Drawing.Point(3, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "min Size:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(91, 131);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(316, 26);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Shape Ratio:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblVal
            // 
            this.LblVal.AutoSize = true;
            this.LblVal.Location = new System.Drawing.Point(413, 128);
            this.LblVal.Name = "LblVal";
            this.LblVal.Size = new System.Drawing.Size(23, 13);
            this.LblVal.TabIndex = 6;
            this.LblVal.Text = "VAl";
            // 
            // LblFullnessVal
            // 
            this.LblFullnessVal.AutoSize = true;
            this.LblFullnessVal.Location = new System.Drawing.Point(413, 160);
            this.LblFullnessVal.Name = "LblFullnessVal";
            this.LblFullnessVal.Size = new System.Drawing.Size(23, 13);
            this.LblFullnessVal.TabIndex = 9;
            this.LblFullnessVal.Text = "VAl";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fullness:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrackFullness
            // 
            this.TrackFullness.Location = new System.Drawing.Point(91, 163);
            this.TrackFullness.Maximum = 100;
            this.TrackFullness.Name = "TrackFullness";
            this.TrackFullness.Size = new System.Drawing.Size(316, 28);
            this.TrackFullness.TabIndex = 7;
            this.TrackFullness.ValueChanged += new System.EventHandler(this.TrackFullness_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.trackBar1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TrackFullness, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.nudThresh, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudMinSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblFullnessVal, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.LblVal, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NudGlyphDivs, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.NudMaxSize, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 194);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
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
            // NudMaxSize
            // 
            this.NudMaxSize.Location = new System.Drawing.Point(91, 99);
            this.NudMaxSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NudMaxSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudMaxSize.Name = "NudMaxSize";
            this.NudMaxSize.Size = new System.Drawing.Size(120, 20);
            this.NudMaxSize.TabIndex = 12;
            this.NudMaxSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudMaxSize.ValueChanged += new System.EventHandler(this.NudMaxSize_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Max size";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.FilterCtrlRed, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.FilterCtrlBlue, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(304, 320);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // FilterCtrlRed
            // 
            this.FilterCtrlRed.AutoSize = true;
            this.FilterCtrlRed.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterCtrlRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterCtrlRed.Location = new System.Drawing.Point(3, 3);
            this.FilterCtrlRed.Name = "FilterCtrlRed";
            this.FilterCtrlRed.Size = new System.Drawing.Size(298, 154);
            this.FilterCtrlRed.TabIndex = 10;
            this.FilterCtrlRed.Title = "Red Filter";
            this.FilterCtrlRed.ValueChanged += new System.Action<Chess.BoardWatch.ColorFilterSettings>(this.FilterCtrlRed_ValueChanged);
            // 
            // FilterCtrlBlue
            // 
            this.FilterCtrlBlue.AutoSize = true;
            this.FilterCtrlBlue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FilterCtrlBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterCtrlBlue.Location = new System.Drawing.Point(3, 163);
            this.FilterCtrlBlue.Name = "FilterCtrlBlue";
            this.FilterCtrlBlue.Size = new System.Drawing.Size(298, 154);
            this.FilterCtrlBlue.TabIndex = 11;
            this.FilterCtrlBlue.Title = "Blue Filter";
            this.FilterCtrlBlue.ValueChanged += new System.Action<Chess.BoardWatch.ColorFilterSettings>(this.FilterCtrlBlue_ValueChanged);
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
            // betterPanel1
            // 
            this.betterPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.betterPanel1.Location = new System.Drawing.Point(313, 3);
            this.betterPanel1.Name = "betterPanel1";
            this.betterPanel1.Size = new System.Drawing.Size(201, 320);
            this.betterPanel1.TabIndex = 15;
            this.betterPanel1.Click += new System.EventHandler(this.betterPanel1_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.betterPanel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 212);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(725, 326);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.RedPanel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BluePanel, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(520, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(202, 320);
            this.tableLayoutPanel4.TabIndex = 16;
            // 
            // RedPanel
            // 
            this.RedPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.RedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RedPanel.Location = new System.Drawing.Point(3, 3);
            this.RedPanel.Name = "RedPanel";
            this.RedPanel.Size = new System.Drawing.Size(196, 154);
            this.RedPanel.TabIndex = 0;
            // 
            // BluePanel
            // 
            this.BluePanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BluePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BluePanel.Location = new System.Drawing.Point(3, 163);
            this.BluePanel.Name = "BluePanel";
            this.BluePanel.Size = new System.Drawing.Size(196, 154);
            this.BluePanel.TabIndex = 1;
            // 
            // RadEyeOff
            // 
            this.RadEyeOff.AutoSize = true;
            this.RadEyeOff.Location = new System.Drawing.Point(520, 140);
            this.RadEyeOff.Name = "RadEyeOff";
            this.RadEyeOff.Size = new System.Drawing.Size(95, 17);
            this.RadEyeOff.TabIndex = 17;
            this.RadEyeOff.TabStop = true;
            this.RadEyeOff.Text = "EyeDropperOff";
            this.RadEyeOff.UseVisualStyleBackColor = true;
            this.RadEyeOff.CheckedChanged += new System.EventHandler(this.RadEyeOff_CheckedChanged);
            // 
            // RadBlueEye
            // 
            this.RadBlueEye.AutoSize = true;
            this.RadBlueEye.Location = new System.Drawing.Point(520, 186);
            this.RadBlueEye.Name = "RadBlueEye";
            this.RadBlueEye.Size = new System.Drawing.Size(108, 17);
            this.RadBlueEye.TabIndex = 18;
            this.RadBlueEye.TabStop = true;
            this.RadBlueEye.Text = "Eye Dropper Blue";
            this.RadBlueEye.UseVisualStyleBackColor = true;
            this.RadBlueEye.CheckedChanged += new System.EventHandler(this.RadEyeOff_CheckedChanged);
            // 
            // RadRedEye
            // 
            this.RadRedEye.AutoSize = true;
            this.RadRedEye.Location = new System.Drawing.Point(520, 163);
            this.RadRedEye.Name = "RadRedEye";
            this.RadRedEye.Size = new System.Drawing.Size(107, 17);
            this.RadRedEye.TabIndex = 19;
            this.RadRedEye.TabStop = true;
            this.RadRedEye.Text = "Eye Dropper Red";
            this.RadRedEye.UseVisualStyleBackColor = true;
            this.RadRedEye.CheckedChanged += new System.EventHandler(this.RadEyeOff_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 693);
            this.Controls.Add(this.RadRedEye);
            this.Controls.Add(this.RadBlueEye);
            this.Controls.Add(this.RadEyeOff);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackFullness)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudGlyphDivs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudMaxSize)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudGlyphDivs;
        private System.Windows.Forms.NumericUpDown NudMaxSize;
        private System.Windows.Forms.Label label6;
        private BetterPanel betterPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private BetterPanel RedPanel;
        private BetterPanel BluePanel;
        private System.Windows.Forms.RadioButton RadEyeOff;
        private System.Windows.Forms.RadioButton RadBlueEye;
        private System.Windows.Forms.RadioButton RadRedEye;
    }
}