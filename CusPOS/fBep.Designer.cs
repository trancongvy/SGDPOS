namespace CusPOS
{
    partial class fBep
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mypanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mypanel
            // 
            this.mypanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mypanel.Location = new System.Drawing.Point(0, 0);
            this.mypanel.Name = "mypanel";
            this.mypanel.Size = new System.Drawing.Size(831, 493);
            this.mypanel.TabIndex = 1;
            this.mypanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mypanel_Paint);
            // 
            // fBep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 493);
            this.Controls.Add(this.mypanel);
            this.Name = "fBep";
            this.Text = "fBep";
            this.Load += new System.EventHandler(this.fBep_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel mypanel;
    }
}