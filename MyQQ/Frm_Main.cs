using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace MyQQ
{
    public partial class Frm_Main : Office2007Form
    {
        int fromUserID;
        int friendHeadID;
        int messageImageIndex = 0;
        public static string nickName = "";
        public static string strFlag = "[离线]";
        DataOperator dataOper = new DataOperator();
        public Frm_Main()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }

        /// <summary>
        /// 显示当前登录用户信息（头像、昵称、个性签名）
        /// </summary>
        public void ShowInfo()
        {
            int headID = 0;
            //获取当前用户的昵称、头像、个性签名
            string sql = "select NickName, HeadID, Sign from tb_User " +
                "where ID=" + PublicClass.loginID + "";
            SqlDataReader dataReader = dataOper.GetDataReader(sql);
            if(dataReader.Read())
            {
                if(!(dataReader["NickName"] is DBNull))     //判断昵称不为空
                {
                    nickName = dataReader["NickName"].ToString();
                }
                headID = Convert.ToInt32(dataReader["HeadID"]);
                txtSign.Text = dataReader["Sign"].ToString();
            }
            dataReader.Close();
            DataOperator.connection.Close();
            this.Text = PublicClass.loginID.ToString();
            pboxHead.Image = imglistHead.Images[headID];
            lblName.Text = nickName + "(" + PublicClass.loginID + ")";
        }

        /// <summary>
        /// 显示当前登录用户的好友列表
        /// </summary>
        public void ShowFriendList()
        {
            lvFriend.Items.Clear();
            string sql = "select F.FriendID, U.NickName,U.HeadID,U.Flag " +
                "from tb_Friend as F inner join tb_User as U on F.HostID=" + 
                PublicClass.loginID + "and U.ID = F.FriendID";
            SqlDataReader dataReader = dataOper.GetDataReader(sql);
            int i = lvFriend.Items.Count;   //记录添加到好友列表的项目索引
            while(dataReader.Read())
            {
                if (dataReader["Flag"].ToString() == "0")
                    strFlag = "[离线]";
                else
                    strFlag = "[在线]";
                string strTemp = dataReader["NickName"].ToString();
                string strFriendName = strTemp;
                if (strTemp.Length < 9)
                    strFriendName = strTemp.PadLeft(9, ' ');
                else
                    strFriendName = (strTemp.Substring(0, 2) + "...").PadLeft(9, ' ');
                //向好友列表添加项：好友ID、昵称、头像
                lvFriend.Items.Add(dataReader["FriendID"].ToString(), 
                    strFriendName + strFlag, 
                    (int)dataReader["HeadID"]);
                lvFriend.Items[i].Group = lvFriend.Groups[0];
                i++;
            }
            dataReader.Close();
            DataOperator.connection.Close();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            tsbtnMessageReading.Image = imglistMessage.Images[0];   //工具栏的消息图标
            ShowInfo();
            ShowFriendList();
        }

        private void tsbtnInfo_Click(object sender, EventArgs e)
        {
            Frm_EditInfo frmInfo = new Frm_EditInfo();
            frmInfo.Show();
        }

        private void tsbtnSearchFriend_Click(object sender, EventArgs e)
        {
            Frm_AddFriend frmAddFriend = new Frm_AddFriend();
            frmAddFriend.Show();
        }

        private void tsbtnUpdateFriendList_Click(object sender, EventArgs e)
        {
            ShowFriendList();
        }

        private void tsbtnMessageReading_Click(object sender, EventArgs e)
        {
            tmAddFriend.Stop();                         //停止消息提醒定时器
            messageImageIndex = 0;                      //正常的消息提醒图标
            tsbtnMessageReading.Image = imglistMessage.Images[messageImageIndex];
            Frm_Remind frmRemind = new Frm_Remind();
            frmRemind.Show();
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确实要退出吗？", "退出提醒",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
    }
}
