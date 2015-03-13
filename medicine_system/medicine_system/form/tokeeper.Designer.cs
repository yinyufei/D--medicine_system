namespace medicine_system
{
    partial class tokeeper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tokeeper));
            this.btrukuguanli = new System.Windows.Forms.Button();
            this.btchukuguanli = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btrukuguanli
            // 
            this.btrukuguanli.Location = new System.Drawing.Point(24, 48);
            this.btrukuguanli.Name = "btrukuguanli";
            this.btrukuguanli.Size = new System.Drawing.Size(75, 23);
            this.btrukuguanli.TabIndex = 0;
            this.btrukuguanli.Text = "入库管理";
            this.btrukuguanli.UseVisualStyleBackColor = true;
            this.btrukuguanli.Click += new System.EventHandler(this.btrukuguanli_Click);
            // 
            // btchukuguanli
            // 
            this.btchukuguanli.Location = new System.Drawing.Point(142, 48);
            this.btchukuguanli.Name = "btchukuguanli";
            this.btchukuguanli.Size = new System.Drawing.Size(75, 23);
            this.btchukuguanli.TabIndex = 1;
            this.btchukuguanli.Text = "出库管理";
            this.btchukuguanli.UseVisualStyleBackColor = true;
            this.btchukuguanli.Click += new System.EventHandler(this.btchukuguanli_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tokeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImage = global::medicine_system.Properties.Resources.keeperpicture;
            this.ClientSize = new System.Drawing.Size(349, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btchukuguanli);
            this.Controls.Add(this.btrukuguanli);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "tokeeper";
            this.Text = "仓管界面";
            this.Load += new System.EventHandler(this.tokeeper_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btrukuguanli;
        private System.Windows.Forms.Button btchukuguanli;
        private System.Windows.Forms.Button button1;
    }
}