using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyQQ
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }
        private bool ValidateInput()
        {
            if(txtID.Text.Trim()=="")
            {
                MessageBox.Show("请输入登录账号", "登录提示", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                txtID.Focus();
                return false;

            }
            else if (int.Parse(txtID.Text.Trim())>65535)
            {
                MessageBox.Show("请输入正确的登录账号", "登录提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtID.Focus();
                return false;

            }
            else if (txtID.Text.Length>5 && txtPwd.Text.Trim()=="")
            {
                MessageBox.Show("请输入密码", "登录提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPwd.Focus();
                return false;

            }
            return true;
        }
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || (e.KeyChar=='\r') || (e.KeyChar=='\b'))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
