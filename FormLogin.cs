﻿using System;
using System.Windows.Forms;
using System.Data;
using Model;
using BusinessLayer;

namespace GUILayer
{
    public partial class FormLogin : Form
    {
        //----------------------------------------------------------------------------------
        private ManageList<Account> listAccount = new ManageList<Account>();
        public static string Type;
        public static string Cashier;
        //----------------------------------------------------------------------------------
        public FormLogin()
        {
            InitializeComponent();
            btnHidePass.Hide();
        }
        private bool CheckLogin(string username, string password)
        {
            BUS_Account.Instance.GetList(listAccount);
            for (int i = 0; i < listAccount.Count; i++)
            {
                if (username == listAccount[i].UserName && password == listAccount[0].PassWord)
                {
                    Type = listAccount[i].Type;
                    Cashier = listAccount[0].DisplayName;
                    return true;
                }
            }
            return false;
        }
        //Thiết Lập Các Click Nút
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (CheckLogin(userName, passWord))
            {
                txbUserName.Text = String.Empty;
                txbPassWord.Text = String.Empty;
                //Show Form MainMenu
                FormMainMenu mainMenu = new FormMainMenu();
                this.Hide();
                mainMenu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
            }
        }

        //Tạo một Button Có Muốn Thoát Hay Là Không
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ?", "Thoát", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            txbPassWord.UseSystemPasswordChar = false;
            btnShowPass.Hide();
            btnHidePass.Show();
        }

        private void btnHidePass_Click(object sender, EventArgs e)
        {
            txbPassWord.UseSystemPasswordChar = true;
            btnHidePass.Hide();
            btnShowPass.Show();
        }
    }
}
