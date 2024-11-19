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
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class Employee : Form
    {
        //创建连接字符串
        private string ConnString = "server=.;database=xm;Integrated Security=True;";
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string title = comboBox1.Text.Trim();

            string query = "SELECT employee_id 职工编号, employee_name 职工姓名, employee_title 职工职级, employee_UID 职工账号, employee_Pwd 职工密码 FROM employee";

            // 如果输入了姓名，则按姓名筛选
            if (!string.IsNullOrEmpty(name))
            {
                query += " WHERE employee_name = '" + name + "'";
            }

            // 如果输入了职位，则按职位筛选
            if (!string.IsNullOrEmpty(title))//检查字符串是否为 null 或空字符串
            {
                if (!string.IsNullOrEmpty(name))
                {
                    query += " AND employee_title = '" + title + "'";
                }
                else
                {
                    query += " WHERE employee_title= '" + title + "'";
                }
            }

            ExecuteQuery(query);//执行底下的ExecuteQuery方法
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeDelete employeedelete = new EmployeeDelete();
            employeedelete.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewEmployee newemployee= new NewEmployee();
            newemployee.Show();
        }

        private void ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
