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
    public partial class AddGoods : Form
    {
        public AddGoods()
        {
            InitializeComponent();
        }

        //创建连接字符串
        private string ConnString = "server=.;database=xm;Integrated Security=True;";

        private void AddGoods_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“xmDataSet.goods”中。您可以根据需要移动或移除它。
            this.goodsTableAdapter.Fill(this.xmDataSet.goods);
            // TODO: 这行代码将数据加载到表“xmDataSet.goods”中。您可以根据需要移动或移除它。
            this.goodsTableAdapter.Fill(this.xmDataSet.goods);
            // TODO: 这行代码将数据加载到表“xmDataSet.goods”中。您可以根据需要移动或移除它。
            this.goodsTableAdapter.Fill(this.xmDataSet.goods);
            chaxun();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();

                // 查询商品信息
                string query = "SELECT goods_id, goods_name, goods_price, goodtype, goods_num FROM goods";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                // 添加或更新商品信息
                string goodsName = textBox1.Text;
                decimal goodsPrice = Convert.ToDecimal(textBox2.Text);
                string goodType = comboBox1.Text;
                int goodsNum = Convert.ToInt32(textBox4.Text);

                SqlCommand command;
                int count = 0;

                // 检查商品是否已存在
                query = "SELECT COUNT(*) FROM goods WHERE goods_name = @goodsName";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@goodsName", goodsName);
                count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    // 商品已存在，更新商品信息
                    query = "UPDATE goods SET goods_price = @goodsPrice, goodtype = @goodType, goods_num = goods_num + @goodsNum WHERE goods_name = @goodsName";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@goodsPrice", goodsPrice);
                    command.Parameters.AddWithValue("@goodType", goodType);
                    command.Parameters.AddWithValue("@goodsNum", goodsNum);
                    command.Parameters.AddWithValue("@goodsName", goodsName);
                    command.ExecuteNonQuery();
                }
                else
                {
                    // 商品不存在，新增商品信息
                    query = "INSERT INTO goods (goods_name, goods_price, goodtype, goods_num) VALUES (@goodsName, @goodsPrice, @goodType, @goodsNum)";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@goodsName", goodsName);
                    command.Parameters.AddWithValue("@goodsPrice", goodsPrice);
                    command.Parameters.AddWithValue("@goodType", goodType);
                    command.Parameters.AddWithValue("@goodsNum", goodsNum);
                    command.ExecuteNonQuery();
                }

                // 向 storage 表中添加进货信息
                query = "INSERT INTO storage (storage_time, storage_num, goods_id) VALUES (@storageTime, @storageNum, (SELECT MAX(goods_id) FROM goods))";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@storageTime", DateTime.Now);
                command.Parameters.AddWithValue("@storageNum", goodsNum);
                command.ExecuteNonQuery();
            }
            chaxun();
        }

        private void chaxun()
        {
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();

                // 查询商品信息
                string query = "SELECT goods_id, goods_name, goods_price, goodtype, goods_num FROM goods";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
