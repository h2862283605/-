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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Income_Load(object sender, EventArgs e)
        {
            // 计算总收入
            decimal zsr = js();

            // 将总收入显示在 textBox1 中
            textBox1.Text = zsr.ToString();
        }

        private decimal js()
        {
            decimal zsr = 0;

            //创建连接字符串
            string ConnString = "server=.;database=xm;Integrated Security=True;";
            //定义sql语句
            string query = "SELECT delivery.delivery_num, goods.goods_price " +
                           "FROM delivery " +
                           "INNER JOIN goods ON delivery.goods_id = goods.goods_id";

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //打开数据库连接
                    conn.Open();
                    //返回查询到的结果到reader里
                    SqlDataReader reader = cmd.ExecuteReader();

                    // 检查数据读取器是否有行
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int deliveryNum = Convert.ToInt32(reader["delivery_num"]);
                            decimal goodsPrice = Convert.ToDecimal(reader["goods_price"]);

                            // 计算每个商品的收入并累加到总收入
                            decimal income = deliveryNum * goodsPrice;
                            zsr += income;
                        }
                    }
                    else
                    {
                        // 没有数据，总收入设为0
                        zsr = 0;
                    }

                    //关闭与reader的连接
                    reader.Close();
                    //关闭连接字符串
                    conn.Close();
                }
            }
            //返回zsr的值给js
            return zsr;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
