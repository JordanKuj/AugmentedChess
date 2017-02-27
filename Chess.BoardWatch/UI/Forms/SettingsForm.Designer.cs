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
            ((System.ComponentModel.ISupportInitialize)(this.nudThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackFullness)).BeginInit();
            this.SuspendLayout();
            // 
            // nudThresh
            // 
            this.nudThresh.Location = new System.Drawing.Point(120, 63);
            this.nudThresh.Name = "nudThresh";
            this.nudThresh.Size = new System.Drawing.Size(120, 20);
            this.nudThresh.TabIndex = 0;
            this.nudThresh.ValueChanged += new System.EventHandler(this.nudThresh_ValueChanged);
            // 
            // nudMinSize
            // 
            this.nudMinSize.Location = new System.Drawing.Point(120, 89);
            this.nudMinSize.Name = "nudMinSize";
            this.nudMinSize.Size = new System.Drawing.Size(120, 20);
            this.nudMinSize.TabIndex = 1;
            this.nudMinSize.ValueChanged += new System.EventHandler(this.nudMinSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "thresh filter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "min Size:";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(120, 180);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(366, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Shape Ratio:";
            // 
            // LblVal
            // 
            this.LblVal.AutoSize = true;
            this.LblVal.Location = new System.Drawing.Point(492, 189);
            this.LblVal.Name = "LblVal";
            this.LblVal.Size = new System.Drawing.Size(23, 13);
            this.LblVal.TabIndex = 6;
            this.LblVal.Text = "VAl";
            // 
            // LblFullnessVal
            // 
            this.LblFullnessVal.AutoSize = true;
            this.LblFullnessVal.Location = new System.Drawing.Point(492, 240);
            this.LblFullnessVal.Name = "LblFullnessVal";
            this.LblFullnessVal.Size = new System.Drawing.Size(23, 13);
            this.LblFullnessVal.TabIndex = 9;
            this.LblFullnessVal.Text = "VAl";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fullness:";
            // 
            // TrackFullness
            // 
            this.TrackFullness.Location = new System.Drawing.Point(120, 231);
            this.TrackFullness.Maximum = 100;
            this.TrackFullness.Name = "TrackFullness";
            this.TrackFullness.Size = new System.Drawing.Size(366, 45);
            this.TrackFullness.TabIndex = 7;
            this.TrackFullness.ValueChanged += new System.EventHandler(this.TrackFullness_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 490);
            this.Controls.Add(this.LblFullnessVal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TrackFullness);
            this.Controls.Add(this.LblVal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMinSize);
            this.Controls.Add(this.nudThresh);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackFullness)).EndInit();
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
    }
}