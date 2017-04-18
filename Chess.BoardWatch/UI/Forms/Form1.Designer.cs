namespace Chess.BoardWatch
{
    partial class Form1
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
            this.PanelRawVideo = new Chess.BoardWatch.BetterPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.PanelBBW = new Chess.BoardWatch.BetterPanel();
            this.PanelBlue = new Chess.BoardWatch.BetterPanel();
            this.PanelFinalB = new Chess.BoardWatch.BetterPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowBlu = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.PanelFinalR = new Chess.BoardWatch.BetterPanel();
            this.PanelRBW = new Chess.BoardWatch.BetterPanel();
            this.PanelRed = new Chess.BoardWatch.BetterPanel();
            this.FlowRed = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelRawVideo
            // 
            this.PanelRawVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRawVideo.Location = new System.Drawing.Point(3, 3);
            this.PanelRawVideo.Name = "PanelRawVideo";
            this.PanelRawVideo.Size = new System.Drawing.Size(178, 237);
            this.PanelRawVideo.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PanelRawVideo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1106, 516);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(908, 484);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Blue";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.flowLayoutPanel4, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(902, 478);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Controls.Add(this.PanelFinalB, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.PanelBlue, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.PanelBBW, 1, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(445, 472);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // PanelBBW
            // 
            this.PanelBBW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelBBW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBBW.Location = new System.Drawing.Point(225, 3);
            this.PanelBBW.Name = "PanelBBW";
            this.PanelBBW.Size = new System.Drawing.Size(217, 230);
            this.PanelBBW.TabIndex = 7;
            // 
            // PanelBlue
            // 
            this.PanelBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelBlue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBlue.Location = new System.Drawing.Point(3, 3);
            this.PanelBlue.Name = "PanelBlue";
            this.PanelBlue.Size = new System.Drawing.Size(216, 230);
            this.PanelBlue.TabIndex = 9;
            // 
            // PanelFinalB
            // 
            this.PanelFinalB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFinalB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelFinalB.Location = new System.Drawing.Point(3, 239);
            this.PanelFinalB.Name = "PanelFinalB";
            this.PanelFinalB.Size = new System.Drawing.Size(216, 230);
            this.PanelFinalB.TabIndex = 4;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel4.Controls.Add(this.FlowBlu);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(454, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(445, 472);
            this.flowLayoutPanel4.TabIndex = 2;
            // 
            // FlowBlu
            // 
            this.FlowBlu.AutoSize = true;
            this.FlowBlu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlowBlu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowBlu.Location = new System.Drawing.Point(3, 3);
            this.FlowBlu.Name = "FlowBlu";
            this.FlowBlu.Size = new System.Drawing.Size(0, 0);
            this.FlowBlu.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(908, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Red";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.FlowRed, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(902, 478);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.PanelRed, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.PanelRBW, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.PanelFinalR, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(445, 472);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // PanelFinalR
            // 
            this.PanelFinalR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelFinalR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelFinalR.Location = new System.Drawing.Point(3, 239);
            this.PanelFinalR.Name = "PanelFinalR";
            this.PanelFinalR.Size = new System.Drawing.Size(216, 230);
            this.PanelFinalR.TabIndex = 10;
            // 
            // PanelRBW
            // 
            this.PanelRBW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRBW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRBW.Location = new System.Drawing.Point(225, 3);
            this.PanelRBW.Name = "PanelRBW";
            this.PanelRBW.Size = new System.Drawing.Size(217, 230);
            this.PanelRBW.TabIndex = 8;
            // 
            // PanelRed
            // 
            this.PanelRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRed.Location = new System.Drawing.Point(3, 3);
            this.PanelRed.Name = "PanelRed";
            this.PanelRed.Size = new System.Drawing.Size(216, 230);
            this.PanelRed.TabIndex = 5;
            // 
            // FlowRed
            // 
            this.FlowRed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowRed.Location = new System.Drawing.Point(454, 3);
            this.FlowRed.Name = "FlowRed";
            this.FlowRed.Size = new System.Drawing.Size(445, 472);
            this.FlowRed.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(187, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 510);
            this.tabControl1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 516);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private BetterPanel PanelRawVideo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel FlowRed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private BetterPanel PanelRed;
        private BetterPanel PanelRBW;
        private BetterPanel PanelFinalR;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel FlowBlu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private BetterPanel PanelFinalB;
        private BetterPanel PanelBlue;
        private BetterPanel PanelBBW;
    }
}