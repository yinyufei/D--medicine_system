namespace medicine_system
{
    partial class log
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(log));
            this.labUserID = new System.Windows.Forms.Label();
            this.labUserPwd = new System.Windows.Forms.Label();
            this.tBUserID = new System.Windows.Forms.TextBox();
            this.tBPwd = new System.Windows.Forms.TextBox();
            this.btLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labUserID
            // 
            this.labUserID.AutoSize = true;
            this.labUserID.Location = new System.Drawing.Point(145, 257);
            this.labUserID.Name = "labUserID";
            this.labUserID.Size = new System.Drawing.Size(41, 12);
            this.labUserID.TabIndex = 1;
            this.labUserID.Text = "用户ID";
            this.labUserID.Click += new System.EventHandler(this.labUserID_Click);
            // 
            // labUserPwd
            // 
            this.labUserPwd.AutoSize = true;
            this.labUserPwd.Location = new System.Drawing.Point(133, 291);
            this.labUserPwd.Name = "labUserPwd";
            this.labUserPwd.Size = new System.Drawing.Size(53, 12);
            this.labUserPwd.TabIndex = 2;
            this.labUserPwd.Text = "用户密码";
            this.labUserPwd.Click += new System.EventHandler(this.labUserPwd_Click);
            // 
            // tBUserID
            // 
            this.tBUserID.Location = new System.Drawing.Point(201, 254);
            this.tBUserID.Name = "tBUserID";
            this.tBUserID.Size = new System.Drawing.Size(100, 21);
            this.tBUserID.TabIndex = 4;
            this.tBUserID.TextChanged += new System.EventHandler(this.tBUserID_TextChanged);
            // 
            // tBPwd
            // 
            this.tBPwd.Location = new System.Drawing.Point(201, 291);
            this.tBPwd.Name = "tBPwd";
            this.tBPwd.PasswordChar = '*';
            this.tBPwd.Size = new System.Drawing.Size(100, 21);
            this.tBPwd.TabIndex = 5;
            this.tBPwd.TextChanged += new System.EventHandler(this.tBPwd_TextChanged);
            // 
            // btLog
            // 
            this.btLog.Location = new System.Drawing.Point(318, 291);
            this.btLog.Name = "btLog";
            this.btLog.Size = new System.Drawing.Size(75, 23);
            this.btLog.TabIndex = 6;
            this.btLog.Text = "登陆";
            this.btLog.UseVisualStyleBackColor = false;
            this.btLog.Click += new System.EventHandler(this.btLog_Click);
            // 
            // log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImage = global::medicine_system.Properties.Resources.logpicture;
            this.ClientSize = new System.Drawing.Size(426, 354);
            this.Controls.Add(this.btLog);
            this.Controls.Add(this.tBPwd);
            this.Controls.Add(this.tBUserID);
            this.Controls.Add(this.labUserPwd);
            this.Controls.Add(this.labUserID);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "log";
            this.Text = "登陆界面";
            this.Load += new System.EventHandler(this.log_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labUserID;
        private System.Windows.Forms.Label labUserPwd;
        private System.Windows.Forms.TextBox tBUserID;
        private System.Windows.Forms.TextBox tBPwd;
        private System.Windows.Forms.Button btLog;
    }
}

