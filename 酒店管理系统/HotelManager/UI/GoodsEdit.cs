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
    public partial class GoodsEdit : Form
    {
        public Model.Goods Goods { get; set; } = new Model.Goods();

        public GoodsEdit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Goods.ID!=0)
            {
                Goods.Name = textBox1.Text.Trim();
                Goods.Price = int.Parse(textBox2.Text.Trim());
                Goods.Note = textBox3.Text.Trim();

                BLL.GoodsBLL.UpdateGoods(Goods);
                MessageBox.Show("添加成功！");
                Close();
            }

            else
            {

                Goods.Name = textBox1.Text.Trim();
                Goods.Price = int.Parse(textBox2.Text.Trim());
                Goods.Note = textBox3.Text.Trim();

                BLL.GoodsBLL.InsertGoods(Goods);
                MessageBox.Show("添加成功！");
                Close();

            }
        }

        private void GoodsEdit_Load(object sender, EventArgs e)
        {
            if(Goods.ID!=0)
            {
                BLL.GoodsBLL.LoadGoodsInfo(Goods);

                textBox8.Text = Goods.ID.ToString();
                textBox1.Text = Goods.Name;
                textBox2.Text = Goods.Price.ToString();
                textBox3.Text = Goods.Note;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
