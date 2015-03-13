namespace medicine_system
{
    partial class toboss
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(toboss));
            this.btyaopinxinxiweihu = new System.Windows.Forms.Button();
            this.btxiaoshouxinxichaxun = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btyuangongxinxiguanli = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btyaopinxinxiweihu
            // 
            this.btyaopinxinxiweihu.Location = new System.Drawing.Point(12, 67);
            this.btyaopinxinxiweihu.Name = "btyaopinxinxiweihu";
            this.btyaopinxinxiweihu.Size = new System.Drawing.Size(103, 23);
            this.btyaopinxinxiweihu.TabIndex = 0;
            this.btyaopinxinxiweihu.Text = "药品信息维护";
            this.btyaopinxinxiweihu.UseVisualStyleBackColor = true;
            this.btyaopinxinxiweihu.Click += new System.EventHandler(this.button1_Click);
            // 
            // btxiaoshouxinxichaxun
            // 
            this.btxiaoshouxinxichaxun.Location = new System.Drawing.Point(12, 166);
            this.btxiaoshouxinxichaxun.Name = "btxiaoshouxinxichaxun";
            this.btxiaoshouxinxichaxun.Size = new System.Drawing.Size(103, 23);
            this.btxiaoshouxinxichaxun.TabIndex = 2;
            this.btxiaoshouxinxichaxun.Text = "销售信息查询";
            this.btxiaoshouxinxichaxun.UseVisualStyleBackColor = true;
            this.btxiaoshouxinxichaxun.Click += new System.EventHandler(this.btxiaoshouxinxichaxun_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btyuangongxinxiguanli
            // 
            this.btyuangongxinxiguanli.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btyuangongxinxiguanli.BackgroundImage")));
            this.btyuangongxinxiguanli.Location = new System.Drawing.Point(12, 116);
            this.btyuangongxinxiguanli.Name = "btyuangongxinxiguanli";
            this.btyuangongxinxiguanli.Size = new System.Drawing.Size(103, 23);
            this.btyuangongxinxiguanli.TabIndex = 1;
            this.btyuangongxinxiguanli.Text = "员工信息管理";
            this.btyuangongxinxiguanli.UseVisualStyleBackColor = true;
            this.btyuangongxinxiguanli.Click += new System.EventHandler(this.btyuangongxinxiguanli_Click);
            // 
            // toboss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImage = global::medicine_system.Properties.Resources.bosspicture;
            this.ClientSize = new System.Drawing.Size(399, 275);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btxiaoshouxinxichaxun);
            this.Controls.Add(this.btyuangongxinxiguanli);
            this.Controls.Add(this.btyaopinxinxiweihu);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "toboss";
            this.Text = "经理界面";
            this.Load += new System.EventHandler(this.toboss_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btyaopinxinxiweihu;
        private System.Windows.Forms.Button btyuangongxinxiguanli;
        private System.Windows.Forms.Button btxiaoshouxinxichaxun;
        private System.Windows.Forms.Button button1;

    }
}