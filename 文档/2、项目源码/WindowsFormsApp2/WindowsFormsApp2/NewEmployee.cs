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
    public partial class NewEmployee : Form
    {
        //创建连接字符串
        private string ConnString = "server=.;database=xm;Integrated Security=True;";
        public NewEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeName = textBox1.Text.Trim();
            string employeeTitle = comboBox1.Text.Trim();
            string employeeUID = textBox3.Text.Trim();
            string employeePwd = textBox4.Text.Trim();

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                //打开连接
                connection.Open();

                // 检查账号是否已存在
                string checkQuery = "SELECT COUNT(*) FROM Employee WHERE employee_UID = @EmployeeUID";
                SqlCommand checkCommand = new SqlCommand(checkQuery, connection);//连接数据库，执行sql语句
                checkCommand.Parameters.AddWithValue("@EmployeeUID", employeeUID);
                int existingCount = (int)checkCommand.ExecuteScalar();

                if (existingCount > 0)
                {
                    MessageBox.Show("账号已存在。");
                    return;
                }

                string query = "INSERT INTO Employee (employee_name, employee_title, employee_UID, employee_Pwd) VALUES (@EmployeeName, @EmployeeTitle, @EmployeeUID, @EmployeePwd)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeName", employeeName);
                command.Parameters.AddWithValue("@EmployeeTitle", employeeTitle);
                command.Parameters.AddWithValue("@EmployeeUID", employeeUID);
                command.Parameters.AddWithValue("@EmployeePwd", employeePwd);
                int pd = command.ExecuteNonQuery();
                if (pd > 0)
                {
                    MessageBox.Show("员工信息添加成功。");
                }
                else
                {
                    MessageBox.Show("员工信息添加失败。");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
