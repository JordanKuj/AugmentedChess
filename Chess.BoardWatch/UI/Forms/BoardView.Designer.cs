namespace Chess.BoardWatch.UI.Forms
{
    partial class BoardView
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
            this.betterPanel1 = new Chess.BoardWatch.BetterPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnAccept = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // betterPanel1
            // 
            this.betterPanel1.AutoSize = true;
            this.betterPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.betterPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.betterPanel1.Location = new System.Drawing.Point(3, 3);
            this.betterPanel1.Name = "betterPanel1";
            this.betterPanel1.Size = new System.Drawing.Size(846, 562);
            this.betterPanel1.TabIndex = 0;
            this.betterPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.betterPanel1_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.betterPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnAccept, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 597);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BtnAccept
            // 
            this.BtnAccept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAccept.Location = new System.Drawing.Point(3, 571);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(846, 23);
            this.BtnAccept.TabIndex = 1;
            this.BtnAccept.Text = "Accept State";
            this.BtnAccept.UseVisualStyleBackColor = true;
            // 
            // BoardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 597);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BoardView";
            this.Text = "BoardView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BetterPanel betterPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnAccept;
    }
}