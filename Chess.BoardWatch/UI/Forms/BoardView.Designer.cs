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
            this.SuspendLayout();
            // 
            // betterPanel1
            // 
            this.betterPanel1.AutoSize = true;
            this.betterPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.betterPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.betterPanel1.Location = new System.Drawing.Point(0, 0);
            this.betterPanel1.Name = "betterPanel1";
            this.betterPanel1.Size = new System.Drawing.Size(746, 512);
            this.betterPanel1.TabIndex = 0;
            // 
            // BoardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 512);
            this.Controls.Add(this.betterPanel1);
            this.Name = "BoardView";
            this.Text = "BoardView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BetterPanel betterPanel1;
    }
}