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
    public partial class Selling : Form
    {
        //创建连接字符串
        private string ConnString = "server=.;database=xm;Integrated Security=True;";

        public Selling()
        {
            InitializeComponent();
        }

        private void Selling_Load(object sender, EventArgs e)
        {
            // 初始加载时，显示所有销售记录
            A("", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string goodsName = textBox2.Text.Trim();
            string deliveryTime = textBox1.Text.Trim();
            A(goodsName, deliveryTime);
        }
        private void A(string goodsName, string deliveryTime)
        {
            string query = "SELECT g.goods_name 商品名称, d.delivery_time 销售时间, d.delivery_num 销售数量 " +
                           "FROM delivery d " +
                           "INNER JOIN goods g ON d.goods_id = g.goods_id " +
                           "WHERE (@goodsName = '' OR g.goods_name LIKE '%' + @goodsName + '%') " +//模糊查询
                           "AND (@deliveryTime = '' OR d.delivery_time LIKE '%' + @deliveryTime + '%')";

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //插入用户输入
                    command.Parameters.AddWithValue("@goodsName", goodsName);
                    command.Parameters.AddWithValue("@deliveryTime", deliveryTime);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        //打开连接
                        connection.Open();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("没有找到符合条件的销售记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("数据库查询出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
