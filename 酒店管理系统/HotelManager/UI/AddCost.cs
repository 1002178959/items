using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager.UI
{
    public partial class AddCost : Form
    {
        public Model.CheckIn CheckIn { get; set; } = new Model.CheckIn();
        public Model.Goods Goods { get; set; } = new Model.Goods();
        public Model.Cost Cost { get; set; } = new Model.Cost();

        public AddCost()
        {
            InitializeComponent();
        }

        private void AddCost_Load(object sender, EventArgs e)
        {
            BLL.CheckInBLL.LoadCheckInInfo(CheckIn);

            dataGridView1.DataSource = BLL.GoodsBLL.LoadGoodsList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Goods.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            BLL.GoodsBLL.LoadGoodsInfo(Goods);

            textBox2.Text = (Goods.Price * int.Parse(textBox1.Text)).ToString();

            dataGridView3.DataSource = BLL.GoodsBLL.LoadSelectedGoods(Goods);
            dataGridView3.Columns[0].Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cost.CheckInID = CheckIn.ID;
            Cost.GoodsID = Goods.ID;
            Cost.Number = int.Parse(textBox1.Text);
            Cost.Time = dateTimePicker1.Value.ToString();
            Cost.Note = textBox3.Text.Trim();

            BLL.CostBLL.InsertCost(Cost);
            MessageBox.Show("添加消费成功！");
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == (char)8)
            { e.Handled = false; }
            else
            { e.Handled = true; }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox2.Text = (Goods.Price * int.Parse(textBox1.Text)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
