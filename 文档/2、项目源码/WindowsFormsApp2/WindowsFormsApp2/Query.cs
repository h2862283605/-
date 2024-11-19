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
    public partial class Query : Form
    {
        //创建连接字符串
        private string ConnString = "server=.;database=xm;Integrated Security=True;";
        public Query()
        {
            InitializeComponent();
        }


        private void Query_Load(object sender, EventArgs e)
        {
            cx("", "", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string goodsName = textBox1.Text.Trim();
            string goodsType = comboBox1.Text.Trim();
            string storageTime = textBox3.Text.Trim();
            cx(goodsName, goodsType, storageTime);
        }
        private void cx(string goodsName, string goodsType, string storageTime)
        {
            string query = "SELECT g.goods_id 商品编号 , g.goods_name 商品名称 , g.goods_price 商品单价 , g.goodtype 商品类型 , g.goods_num 商品数量 , s.storage_time  进货时间 " +
                            //多表连接查询
                           "FROM goods g INNER JOIN storage s ON g.goods_id = s.goods_id " +
                           "WHERE (@goodsName = '' OR g.goods_name LIKE '%' + @goodsName + '%') " +
                           "AND (@goodsType = '' OR g.goodtype LIKE '%' + @goodsType + '%') " +
                           "AND (@storageTime = '' OR s.storage_time LIKE '%' + @storageTime + '%') " +
                           "AND s.storage_time = (SELECT MAX(storage_time) FROM storage WHERE goods_id = g.goods_id)";

            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@goodsName", goodsName);
                    command.Parameters.AddWithValue("@goodsType", goodsType);
                    command.Parameters.AddWithValue("@storageTime", storageTime);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    try
                    {
                        connection.Open();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("没有找到符合条件的商品信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
