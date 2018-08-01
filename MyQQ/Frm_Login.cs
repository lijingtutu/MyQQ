using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace MyQQ
{
    public partial class Frm_Login : Form
    {
        DataOperator dataOper = new DataOperator();
        public Frm_Login()
        {
            InitializeComponent();
        }
        private bool ValidateInput()
        {
            if (txtID.Text.Trim() == "")
            {
                MessageBox.Show("请输入登录账号", "登录提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtID.Focus();
                return false;

            }
            else if (int.Parse(txtID.Text.Trim()) > 65535)
            {
                MessageBox.Show("请输入正确的登录账号", "登录提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtID.Focus();
                return false;

            }
            else if (txtID.Text.Length > 5 && txtPwd.Text.Trim() == "")
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
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == '\r') || (e.KeyChar == '\b'))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void pboxLogin_Click(object sender, EventArgs e)
        {
            if (ValidateInput())                                        //调用自定义方法验证用户输入
            {
                string sql = "select count(*) from tb_User where ID=" + int.Parse(txtID.Text.Trim())
                    + " and Pwd = '" + txtPwd.Text.Trim() + "'";                    //定义查询SQL语句
                int num = dataOper.ExecSQL(sql);
                if (num == 1)                                           //验证通过
                {
                    PublicClass.loginID = int.Parse(txtID.Text.Trim()); //设置登录的用户号码
                    if (cboxRemember.Checked)
                    {
                        dataOper.ExecSQLResult("update tb_User set Remember=1 where ID=" +
                            int.Parse(txtID.Text.Trim()));                             //记住密码
                        if (cboxAutoLogin.Checked)
                            dataOper.ExecSQLResult("update tb_User set AutoLogin=1 where ID=" +
                                int.Parse(txtID.Text.Trim()));                             //自动登录
                    }
                    else
                    {
                        dataOper.ExecSQLResult("update tb_User set Remember=0 where ID=" +
                            int.Parse(txtID.Text.Trim()));
                        dataOper.ExecSQLResult("update tb_User set AutoLogin=0 where ID=" +
                            int.Parse(txtID.Text.Trim()));
                    }
                    dataOper.ExecSQLResult("update tb_User set Flag=1 where ID=" +
                        int.Parse(txtID.Text.Trim()));                             //设置在线状态
                    Frm_Main frmMain = new Frm_Main();                  //创建主窗体对象
                    frmMain.Show();                                     //显示主窗体
                    this.Visible = false;                               //隐藏登录主窗体
                }
                else
                {
                    MessageBox.Show("输入的用户名或密码有误！", "登录提示", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                DataOperator.connection.Close();
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                pboxLogin_Click(sender, e);
        }

        private void cboxRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (!cboxRemember.Checked)                          //判断忘记密码文本框为未选中状态
                cboxAutoLogin.Checked = false;					//自动登录设置为未选中
        }

        private void cboxAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxAutoLogin.Checked)
                cboxRemember.Checked = true;
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
            //根据号码查询其密码、记住密码和自动登录字段的值
            string sql = "select Pwd,Remember,AutoLogin from tb_User where ID=" +
                int.Parse(txtID.Text.Trim()) + "";
            DataSet ds = dataOper.GetDataSet(sql);                      //查询结果存储到数据集中
            if (ds.Tables[0].Rows.Count > 0)                            //判断是否存在该用户
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0][1]) == 1)      //判断是否记住密码
                {
                    cboxRemember.Checked = true;                        //记录密码复选框选中
                    txtPwd.Text = ds.Tables[0].Rows[0][0].ToString();   //自动输入密码
                    if (Convert.ToInt32(ds.Tables[0].Rows[0][2]) == 1)  //判断是否自动登录
                    {
                        cboxAutoLogin.Checked = true;                   //自动登录复选框选中
                        pboxLogin_Click(sender, e);                     //自动登录
                    }
                }
            }
        }

        private void linklblReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_Register frmRegister = new Frm_Register();
            frmRegister.Show();
        }

        private void pboxMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pboxClose_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
