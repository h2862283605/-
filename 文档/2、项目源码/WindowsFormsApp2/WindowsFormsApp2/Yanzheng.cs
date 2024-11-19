using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Yanzheng : Form
    {
        public Yanzheng()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //连接字符串
            string ConnString = "server=.;database=xm;Integrated Security=True;";
            string username = textBox1.Text;
            string password = textBox2.Text;
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                string query = "select employee_title from employee where employee_UID=@Username and employee_Pwd = @Password";
                SqlCommand command= new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                try
                {
                    //打开数据库连接
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if(result != null)
                    {
                        string userType = result.ToString();
                        //判断用户类型
                        if (userType == "老板" || userType == "管理")
                        {
                            Employee employee = new Employee();
                            employee.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("该功能只对老板和管理层开放");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入正确的账号密码");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据库连接错误"+ex.Message);
                }
            }
        }
    }
}
