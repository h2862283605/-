namespace WindowsFormsApp2
{
    partial class AddGoods
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGoods));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.goodsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xmDataSet = new WindowsFormsApp2.xmDataSet();
            this.goodsTableAdapter = new WindowsFormsApp2.xmDataSetTableAdapters.goodsTableAdapter();
            this.goodsidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodspriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodsnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(223, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "添加商品名称:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(410, 44);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 28);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(410, 92);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(236, 28);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(223, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "添加商品单价:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(223, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "添加商品类型:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(410, 214);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(236, 28);
            this.textBox4.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(223, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "添加商品数量:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1408, 338);
            this.panel1.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "饮料",
            "零食",
            "生活用品",
            "玩具",
            "数码",
            "文具",
            "图书",
            "家电",
            "家具",
            "服装",
            "果蔬",
            "生鲜",
            "运动",
            "化妆品",
            "宠物食品",
            "母婴"});
            this.comboBox1.Location = new System.Drawing.Point(410, 158);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(236, 26);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(970, 88);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 96);
            this.button1.TabIndex = 10;
            this.button1.Text = "确认入库";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goodsidDataGridViewTextBoxColumn,
            this.goodsnameDataGridViewTextBoxColumn,
            this.goodspriceDataGridViewTextBoxColumn,
            this.goodtypeDataGridViewTextBoxColumn,
            this.goodsnumDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.goodsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 342);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1408, 510);
            this.dataGridView1.TabIndex = 11;
            // 
            // goodsBindingSource
            // 
            this.goodsBindingSource.DataMember = "goods";
            this.goodsBindingSource.DataSource = this.xmDataSet;
            // 
            // xmDataSet
            // 
            this.xmDataSet.DataSetName = "xmDataSet";
            this.xmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // goodsTableAdapter
            // 
            this.goodsTableAdapter.ClearBeforeFill = true;
            // 
            // goodsidDataGridViewTextBoxColumn
            // 
            this.goodsidDataGridViewTextBoxColumn.DataPropertyName = "goods_id";
            this.goodsidDataGridViewTextBoxColumn.HeaderText = "商品编号";
            this.goodsidDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.goodsidDataGridViewTextBoxColumn.Name = "goodsidDataGridViewTextBoxColumn";
            this.goodsidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // goodsnameDataGridViewTextBoxColumn
            // 
            this.goodsnameDataGridViewTextBoxColumn.DataPropertyName = "goods_name";
            this.goodsnameDataGridViewTextBoxColumn.HeaderText = "商品名称";
            this.goodsnameDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.goodsnameDataGridViewTextBoxColumn.Name = "goodsnameDataGridViewTextBoxColumn";
            // 
            // goodspriceDataGridViewTextBoxColumn
            // 
            this.goodspriceDataGridViewTextBoxColumn.DataPropertyName = "goods_price";
            this.goodspriceDataGridViewTextBoxColumn.HeaderText = "商品单价";
            this.goodspriceDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.goodspriceDataGridViewTextBoxColumn.Name = "goodspriceDataGridViewTextBoxColumn";
            // 
            // goodtypeDataGridViewTextBoxColumn
            // 
            this.goodtypeDataGridViewTextBoxColumn.DataPropertyName = "goodtype";
            this.goodtypeDataGridViewTextBoxColumn.HeaderText = "商品类型";
            this.goodtypeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.goodtypeDataGridViewTextBoxColumn.Name = "goodtypeDataGridViewTextBoxColumn";
            // 
            // goodsnumDataGridViewTextBoxColumn
            // 
            this.goodsnumDataGridViewTextBoxColumn.DataPropertyName = "goods_num";
            this.goodsnumDataGridViewTextBoxColumn.HeaderText = "商品数量";
            this.goodsnumDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.goodsnumDataGridViewTextBoxColumn.Name = "goodsnumDataGridViewTextBoxColumn";
            // 
            // AddGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 851);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "AddGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加商品入库";
            this.Load += new System.EventHandler(this.AddGoods_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private xmDataSet xmDataSet;
        private System.Windows.Forms.BindingSource goodsBindingSource;
        private xmDataSetTableAdapters.goodsTableAdapter goodsTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodspriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodsnumDataGridViewTextBoxColumn;
    }
}