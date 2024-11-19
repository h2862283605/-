using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //创建数据集对象
        DataSet ds = new DataSet();
        //创建连接字符串
        private string ConnString = "server=.;database=xm;Integrated Security=True;";
        private void ConnDatabase()
        {
            //创建连接对象
            SqlConnection Conn = new SqlConnection(ConnString);
            //定义查询数据库的SQL语句
            string sql_employee = "select * from employee";
            //定义DataAdapter对象
            SqlDataAdapter dap = new SqlDataAdapter(sql_employee, Conn);
            //填充数据
            dap.Fill(ds);
            //关闭并释放连接对象
            Conn.Close();
            Conn.Dispose();
        }


        //窗体加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnDatabase();
        }

        //按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            //获取文本框信息
            string username = UID.Text;
            string password = Pwd.Text;
            //定义sql查询
            string query = "select * from employee where employee_UID=@Username and employee_Pwd = @Password";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 添加参数
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // 打开连接
                        connection.Open();

                        // 执行查询并将结果返回第一行第一列
                        int count = (int)command.ExecuteScalar();


                        //如果count有数据
                        if (count > 0)
                        {
                            //弹出消息框
                            MessageBox.Show("登录成功！");
                            // 登录成功后的操作
                            Home home = new Home();
                            home.Show();
                            this.Hide(); // 隐藏登录窗体
                        }
                    }
                }
            }

            catch//它会在用户操作时弹出一个消息框，用于显示指定的消息内容。在这个例子中，如果发生了异常，就会弹出一个消息框
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }

        private void Pwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
