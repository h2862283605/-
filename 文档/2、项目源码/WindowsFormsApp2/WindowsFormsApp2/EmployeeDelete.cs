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

namespace WindowsFormsApp2
{
    public partial class EmployeeDelete : Form
    {
        //创建连接字符串
        private string ConnString = "server=.;database=xm;Integrated Security=True;";
        public EmployeeDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int employeeId=int.Parse(textBox1.Text);
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();//打开连接

                    // 获取员工职位信息
                    string titleQuery = "SELECT employee_title FROM Employee WHERE employee_id = @EmployeeId";
                    SqlCommand titleCommand = new SqlCommand(titleQuery, connection);
                    titleCommand.Parameters.AddWithValue("@EmployeeId", employeeId);
                    string title = (string)titleCommand.ExecuteScalar();

                    if (title == "老板")
                    {
                        MessageBox.Show("不能删除担任老板职位的员工。");
                        return;
                    }

                    string query = "DELETE FROM Employee WHERE employee_id = @EmployeeId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    int pd = command.ExecuteNonQuery();
                    if (pd > 0)
                    {
                        MessageBox.Show("员工信息删除成功。");
                    }
                    else
                    {
                        MessageBox.Show("找不到对应职级编号的员工信息。");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入有效的职级编号。");
            }
        }
    }
}
