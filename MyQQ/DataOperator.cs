using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyQQ
{
    /// <summary>
    /// 对数据库进行的操作
    /// </summary>
    class DataOperator
    {
        ///数据库连接字符串
        private static string connString = @"Data Source=李晶;Database=db_MyQQ;User ID=sa;Pwd=888888;";
        ///数据库连接对象
        public static SqlConnection connection = new SqlConnection(connString);

        /// <summary>
        /// 执行SQL语句，并返回结果中的第一行第一列
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>结果中的第一行第一列</returns>
        public int ExecSQL(string sql)
        {
            int num = 0;
            try
            {
                SqlCommand command = new SqlCommand(sql, connection);   //指定要执行的SQL语句
                if (connection.State == ConnectionState.Closed)         //如果当前数据库连接处于关闭状态
                    connection.Open();                                  //打开数据库连接
                num = Convert.ToInt32(command.ExecuteScalar());     //执行查询
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //connection.Close();                                 //关闭数据库连接
            }
            return num;                                         //返回结果中的第一行第一列
        }

        /// <summary>
        /// 执行SQL语句，返回受影响的行数
        /// </summary>
        /// <param name="sql">要执行的SQL语句</param>
        /// <returns>受影响的行数</returns>
        public int ExecSQLResult(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);   //指定要执行的SQL语句
            if (connection.State == ConnectionState.Closed)         //如果当前数据库连接处于关闭状态
                connection.Open();                                  //打开数据库连接
            int result = command.ExecuteNonQuery();             //执行SQL语句
            //connection.Close();                                 //关闭数据库连接
            return result;                                      //返回受影响的行数
        }

        public DataSet GetDataSet(string sql)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

        /// <summary>
        /// 执行SQL语句，并返回SqlDataReader对象
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>SqlDataReader对象</returns>
        public SqlDataReader GetDataReader(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Closed)
                connection.Open();            
            SqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }
    }
}
