﻿namespace GUILayer
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txbLogin = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowPass = new System.Windows.Forms.Button();
            this.btnHidePass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(1, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name : ";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.Color.OrangeRed;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnExit.Location = new System.Drawing.Point(365, 322);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(195, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnLogin.Location = new System.Drawing.Point(174, 322);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(168, 42);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txbLogin
            // 
            this.txbLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbLogin.AutoSize = true;
            this.txbLogin.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txbLogin.Location = new System.Drawing.Point(205, 105);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(263, 57);
            this.txbLogin.TabIndex = 9;
            this.txbLogin.Text = "Đăng nhập";
            // 
            // txbUserName
            // 
            this.txbUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbUserName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.Location = new System.Drawing.Point(155, 179);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(440, 29);
            this.txbUserName.TabIndex = 0;
            // 
            // txbPassWord
            // 
            this.txbPassWord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbPassWord.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txbPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassWord.Location = new System.Drawing.Point(155, 244);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(440, 29);
            this.txbPassWord.TabIndex = 1;
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password : ";
            // 
            // btnShowPass
            // 
            this.btnShowPass.BackColor = System.Drawing.Color.Transparent;
            this.btnShowPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPass.ForeColor = System.Drawing.Color.Transparent;
            this.btnShowPass.Image = global::GUILayer.Properties.Resources.eye_open2;
            this.btnShowPass.Location = new System.Drawing.Point(557, 246);
            this.btnShowPass.Name = "btnShowPass";
            this.btnShowPass.Size = new System.Drawing.Size(37, 26);
            this.btnShowPass.TabIndex = 14;
            this.btnShowPass.UseVisualStyleBackColor = false;
            this.btnShowPass.Click += new System.EventHandler(this.btnShowPass_Click);
            // 
            // btnHidePass
            // 
            this.btnHidePass.BackColor = System.Drawing.Color.Transparent;
            this.btnHidePass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHidePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidePass.ForeColor = System.Drawing.Color.Transparent;
            this.btnHidePass.Image = global::GUILayer.Properties.Resources.eye_close;
            this.btnHidePass.Location = new System.Drawing.Point(557, 246);
            this.btnHidePass.Name = "btnHidePass";
            this.btnHidePass.Size = new System.Drawing.Size(37, 26);
            this.btnHidePass.TabIndex = 13;
            this.btnHidePass.UseVisualStyleBackColor = false;
            this.btnHidePass.Click += new System.EventHandler(this.btnHidePass_Click);
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(674, 438);
            this.Controls.Add(this.btnShowPass);
            this.Controls.Add(this.btnHidePass);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txbLogin);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.txbPassWord);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label txbLogin;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHidePass;
        private System.Windows.Forms.Button btnShowPass;
    }
}

