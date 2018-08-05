using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace MyQQ
{
    public partial class Frm_Register : Office2007Form
    {
        DataOperator dataOper = new DataOperator();
        public Frm_Register()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        private void skinTextBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Frm_Register_Load(object sender, EventArgs e)
        {
            cboxBloodType.SelectedIndex = cboxStar.SelectedIndex = 0;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtNickName.Text.Trim() == "" || txtNickName.Text.Length > 20)//验证昵称
            {
                MessageBox.Show("昵称输入有误！", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtNickName.Focus();
                return;
            }
            if (!rbtnMale.Checked && !rbtnFemale.Checked)                   //验证性别
            {
                MessageBox.Show("请选择性别！", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lblSex.Focus();
                return;
            }
            if (txtPwd.Text.Trim() == "")                                   //验证密码
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPwd.Focus();
                return;
            }
            if (txtPwdAgain.Text.Trim() == "")                              //验证确认密码
            {
                MessageBox.Show("请输入确认密码！", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPwdAgain.Focus();
                return;
            }
            if (txtPwd.Text.Trim() != txtPwdAgain.Text.Trim())              //验证两次密码是否一致
            {
                MessageBox.Show("两次输入的密码不一样！", "提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPwdAgain.Focus();
                return;
            }
            int myQQNum = 0;                                                //QQ号码
            string message;                                             //弹出的消息
            string sex = rbtnMale.Checked ? rbtnMale.Text : rbtnFemale.Text;    //获得选中的性别
            string sql = string.Format("insert into tb_User (Pwd, NickName, Sex, Age, Name, Star, BloodType) values('{0}', '{1}', '{2}',{3},'{4}','{5}','{6}'); select @@Identity fromtb_User",
                txtPwd.Text.Trim(), txtNickName.Text.Trim(), sex, Convert.ToInt32(numAge.Value), txtName.Text.Trim(), cboxStar.Text, cboxBloodType.Text);

            int result = dataOper.ExecSQLResult(sql);                 //执行SQL语句
            if (result == 1)                                            //判断是否成功
            {
                sql = "select SCOPE_IDENTITY() from tb_User";               //查询新增加的记录的标识号
                myQQNum = dataOper.ExecSQL(sql);                    //获取最新增加的账号
                message = string.Format("注册成功！你的MyQQ号码是" + myQQNum);
            }
            else
            {
                message = "注册失败，请重试！";
            }
            DataOperator.connection.Close();                            //关闭数据库连接
            MessageBox.Show(message, "注册结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();												//关闭当前窗体
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
