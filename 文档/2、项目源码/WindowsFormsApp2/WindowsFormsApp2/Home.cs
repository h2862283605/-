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
    public partial class Home : Form
    {
        //创建连接字符串
        private string ConnString = "server=.;database=xm;Integrated Security=True;";
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 关闭所有已打开的窗体
            foreach (Form form in Application.OpenForms)
            {
                if (form != this) // 不关闭当前窗体（即Home窗体）
                {
                    form.Close();
                }
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//添加商品入库按钮
        {
            AddGoods addgoods = new AddGoods();
            addgoods.Show();
        }

        private void button2_Click(object sender, EventArgs e)//库存查询按钮
        {
            Query query = new Query();
            query.Show();
        }

        private void button4_Click(object sender, EventArgs e)//销售查询按钮
        {
            Selling selling = new Selling();
            selling.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yanzheng yanzheng = new Yanzheng();
            yanzheng.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string goodsName = textBox1.Text.Trim();
            string num1 = textBox2.Text.Trim();
            if (goodsName == "")
            {
                MessageBox.Show("请输入正确的商品名称");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入正确的商品数量");
                return;
            }

            int num = int.Parse(num1);
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnString))
                {
                    connection.Open();

                    string selectGNum = "SELECT goods_num FROM goods WHERE goods_name LIKE '%' + @goodsName + '%'";
                    SqlCommand selectGNumCommand = new SqlCommand(selectGNum, connection);
                    selectGNumCommand.Parameters.AddWithValue("@goodsName", goodsName);
                    int goodsNum = int.Parse((string)selectGNumCommand.ExecuteScalar());

                    //判断销售数量是否小于库存数量
                    if (num > goodsNum)
                    {
                        MessageBox.Show("销售数量不能大于库存数量。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (goodsNum<0)
                    {
                        MessageBox.Show("销售数量不能为负数。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //更新goods表库存
                    string updateG = "UPDATE goods SET goods_num=goods_num-@num WHERE goods_name LIKE '%' + @goodsName + '%'";
                    SqlCommand updateCommand = new SqlCommand(updateG, connection);
                    updateCommand.Parameters.AddWithValue("@num", num);
                    updateCommand.Parameters.AddWithValue("@goodsName", goodsName);

                    updateCommand.ExecuteNonQuery();

                    //查询对应的goods_id
                    string selectG = "SELECT goods_id FROM goods WHERE goods_name LIKE '%' + @goodsName + '%'";
                    SqlCommand selectCommand = new SqlCommand(selectG, connection);
                    selectCommand.Parameters.AddWithValue("@goodsName", goodsName);
                    int goodsId=(int)selectCommand.ExecuteScalar();

                    //将销售信息插入delivery表
                    string insertD = "INSERT INTO delivery (delivery_time,delivery_num,goods_id) " +
                        "VALUES(GETDATE(),@Num,@GoodsId)";
                    SqlCommand insertCommand = new SqlCommand(insertD, connection);
                    insertCommand.Parameters.AddWithValue("@Num", num);
                    insertCommand.Parameters.AddWithValue("@GoodsId", goodsId);
                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("销售成功。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("销售失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string goodsName = textBox1.Text.Trim();
            string num1 = textBox2.Text.Trim();
            if (goodsName == "")
            {
                MessageBox.Show("请输入正确的商品名称");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入正确的商品数量");
                return;
            }

            int num = int.Parse(num1);

            decimal goodsPrice;


            //LIKE '%' + @goodsName + '%'

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                    connection.Open();
                    string query = "SELECT goods_price FROM goods WHERE goods_name LIKE '%' + @GoodsName + '%'";//查询商品名称
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@GoodsName", goodsName);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())//如果有记录
                    {
                        goodsPrice = reader.GetDecimal(0);//获取第1列的值
                        decimal zj = goodsPrice * num;
                        textBox3.Text = zj.ToString();
                    }
                    else
                    {
                        MessageBox.Show("找不到对应商品名称的商品信息。");
                    }

                    reader.Close();
            }
        }
    }
}
