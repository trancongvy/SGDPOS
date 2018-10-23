namespace CusPOS
{
    partial class iBep
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ban = new DevExpress.XtraEditors.LabelControl();
            this.ttenmon = new DevExpress.XtraEditors.LabelControl();
            this.tSl = new DevExpress.XtraEditors.LabelControl();
            this.tBan = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên món";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(322, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Số lượng";
            // 
            // ban
            // 
            this.ban.Location = new System.Drawing.Point(487, 7);
            this.ban.Name = "ban";
            this.ban.Size = new System.Drawing.Size(18, 13);
            this.ban.TabIndex = 2;
            this.ban.Text = "Bàn";
            // 
            // ttenmon
            // 
            this.ttenmon.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.ttenmon.Appearance.ForeColor = System.Drawing.Color.Red;
            this.ttenmon.Location = new System.Drawing.Point(76, 4);
            this.ttenmon.Name = "ttenmon";
            this.ttenmon.Size = new System.Drawing.Size(83, 23);
            this.ttenmon.TabIndex = 3;
            this.ttenmon.Text = "Tên món";
            // 
            // tSl
            // 
            this.tSl.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.tSl.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.tSl.Location = new System.Drawing.Point(389, 0);
            this.tSl.Name = "tSl";
            this.tSl.Size = new System.Drawing.Size(83, 23);
            this.tSl.TabIndex = 4;
            this.tSl.Text = "Tên món";
            // 
            // tBan
            // 
            this.tBan.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.tBan.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tBan.Location = new System.Drawing.Point(511, 0);
            this.tBan.Name = "tBan";
            this.tBan.Size = new System.Drawing.Size(83, 23);
            this.tBan.TabIndex = 5;
            this.tBan.Text = "Tên món";
            // 
            // iBep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tBan);
            this.Controls.Add(this.tSl);
            this.Controls.Add(this.ttenmon);
            this.Controls.Add(this.ban);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "iBep";
            this.Size = new System.Drawing.Size(597, 30);
            this.Load += new System.EventHandler(this.iBep_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl ban;
        private DevExpress.XtraEditors.LabelControl ttenmon;
        private DevExpress.XtraEditors.LabelControl tSl;
        private DevExpress.XtraEditors.LabelControl tBan;
    }
}
