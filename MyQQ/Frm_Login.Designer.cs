﻿namespace MyQQ
{
    partial class Frm_Login
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.linklblReg = new System.Windows.Forms.LinkLabel();
            this.cboxRemember = new System.Windows.Forms.CheckBox();
            this.cboxAutoLogin = new System.Windows.Forms.CheckBox();
            this.pboxMin = new System.Windows.Forms.PictureBox();
            this.pboxClose = new System.Windows.Forms.PictureBox();
            this.pboxLogin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtID.Location = new System.Drawing.Point(135, 200);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(191, 19);
            this.txtID.TabIndex = 0;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(135, 229);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(191, 19);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPwd_KeyPress);
            // 
            // linklblReg
            // 
            this.linklblReg.ActiveLinkColor = System.Drawing.SystemColors.Highlight;
            this.linklblReg.AutoSize = true;
            this.linklblReg.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linklblReg.Location = new System.Drawing.Point(343, 218);
            this.linklblReg.Name = "linklblReg";
            this.linklblReg.Size = new System.Drawing.Size(53, 12);
            this.linklblReg.TabIndex = 2;
            this.linklblReg.TabStop = true;
            this.linklblReg.Text = "申请账号";
            this.linklblReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblReg_LinkClicked);
            // 
            // cboxRemember
            // 
            this.cboxRemember.AutoSize = true;
            this.cboxRemember.Location = new System.Drawing.Point(135, 260);
            this.cboxRemember.Name = "cboxRemember";
            this.cboxRemember.Size = new System.Drawing.Size(72, 16);
            this.cboxRemember.TabIndex = 3;
            this.cboxRemember.Text = "记住密码";
            this.cboxRemember.UseVisualStyleBackColor = true;
            this.cboxRemember.CheckedChanged += new System.EventHandler(this.cboxRemember_CheckedChanged);
            // 
            // cboxAutoLogin
            // 
            this.cboxAutoLogin.AutoSize = true;
            this.cboxAutoLogin.Location = new System.Drawing.Point(254, 260);
            this.cboxAutoLogin.Name = "cboxAutoLogin";
            this.cboxAutoLogin.Size = new System.Drawing.Size(72, 16);
            this.cboxAutoLogin.TabIndex = 4;
            this.cboxAutoLogin.Text = "自动登录";
            this.cboxAutoLogin.UseVisualStyleBackColor = true;
            this.cboxAutoLogin.CheckedChanged += new System.EventHandler(this.cboxAutoLogin_CheckedChanged);
            // 
            // pboxMin
            // 
            this.pboxMin.BackColor = System.Drawing.Color.Transparent;
            this.pboxMin.Location = new System.Drawing.Point(371, 1);
            this.pboxMin.Name = "pboxMin";
            this.pboxMin.Size = new System.Drawing.Size(27, 28);
            this.pboxMin.TabIndex = 5;
            this.pboxMin.TabStop = false;
            this.pboxMin.Click += new System.EventHandler(this.pboxMin_Click);
            // 
            // pboxClose
            // 
            this.pboxClose.BackColor = System.Drawing.Color.Transparent;
            this.pboxClose.Location = new System.Drawing.Point(402, 1);
            this.pboxClose.Name = "pboxClose";
            this.pboxClose.Size = new System.Drawing.Size(27, 28);
            this.pboxClose.TabIndex = 6;
            this.pboxClose.TabStop = false;
            this.pboxClose.Click += new System.EventHandler(this.pboxClose_Click);
            // 
            // pboxLogin
            // 
            this.pboxLogin.BackColor = System.Drawing.Color.Transparent;
            this.pboxLogin.Location = new System.Drawing.Point(135, 286);
            this.pboxLogin.Name = "pboxLogin";
            this.pboxLogin.Size = new System.Drawing.Size(191, 33);
            this.pboxLogin.TabIndex = 7;
            this.pboxLogin.TabStop = false;
            this.pboxLogin.Click += new System.EventHandler(this.pboxLogin_Click);
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MyQQ.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(432, 331);
            this.Controls.Add(this.pboxLogin);
            this.Controls.Add(this.pboxClose);
            this.Controls.Add(this.pboxMin);
            this.Controls.Add(this.cboxAutoLogin);
            this.Controls.Add(this.cboxRemember);
            this.Controls.Add(this.linklblReg);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyQQ登录";
            ((System.ComponentModel.ISupportInitialize)(this.pboxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.LinkLabel linklblReg;
        private System.Windows.Forms.CheckBox cboxRemember;
        private System.Windows.Forms.CheckBox cboxAutoLogin;
        private System.Windows.Forms.PictureBox pboxMin;
        private System.Windows.Forms.PictureBox pboxClose;
        private System.Windows.Forms.PictureBox pboxLogin;
    }
}

