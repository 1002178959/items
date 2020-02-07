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
    public partial class PayEdit : Form
    {
        public Model.CheckIn CheckIn { get; set; } = new Model.CheckIn();
        public Model.Room Room { get; set; } = new Model.Room();
        public Model.Cost Cost { get; set; } = new Model.Cost();
        public Model.Goods Goods { get; set; } = new Model.Goods();
        public Model.Customer Customer { get; set; } = new Model.Customer();
        public Model.Pay Pay { get; set; } = new Model.Pay();

        public PayEdit()
        {
            InitializeComponent();
        }

        private void PayEditcs_Load(object sender, EventArgs e)
        {
            BLL.CheckInBLL.LoadCheckInInfo(CheckIn);

            dataGridView1.DataSource = BLL.CheckInBLL.LoadSelectedCheckIn(CheckIn);

            dataGridView1.Columns[0].Visible = false;

            dateTimePicker1.Text = CheckIn.Time;

            Room.ID = CheckIn.RoomID;

            BLL.RoomBLL.LoadRoomInfo(Room);

            dataGridView2.DataSource = BLL.RoomBLL.LoadSelectedRoom(Room);

            dataGridView2.Columns[0].Visible = false;

            Cost.CheckInID = CheckIn.ID;

            dataGridView6.DataSource = BLL.CostBLL.LoadCostList(Cost);

            dataGridView6.Columns[0].Visible = false;

            int Total=0;


            for (int i = 0; i < dataGridView6.Rows.Count; i++)
            {
                Total += int.Parse(dataGridView6.Rows[i].Cells[2].Value.ToString()) * int.Parse(dataGridView6.Rows[i].Cells[3].Value.ToString());
            }

            textBox2.Text = Total.ToString();

            textBox6.Text = CheckIn.Days.ToString();

            textBox1.Text = (int.Parse(textBox6.Text) * Room.Price).ToString();

            textBox3.Text = CheckIn.Deposit.ToString();

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == (char)8)
            { e.Handled = false; }
            else
            { e.Handled = true; }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(!textBox4.Text.Equals(""))
            {
                textBox5.Text = (CheckIn.Deposit - int.Parse(textBox4.Text)).ToString();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(!textBox6.Text.Equals(""))
            {
                textBox1.Text = (int.Parse(textBox6.Text) * Room.Price).ToString();
                textBox4.Text = (int.Parse(textBox1.Text) + int.Parse(textBox2.Text)).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer.ID = CheckIn.Customer1ID;
            BLL.CustomerBLL.LoadCustomerInfo(Customer);

            Pay.Name = Customer.Name;
            Pay.StartTime = CheckIn.Time;
            Pay.EndTime = dateTimePicker2.Value.ToString();
            Pay.Total = int.Parse(textBox4.Text);
            Pay.Note = "";

            BLL.PayBLL.InsertPay(Pay);

            Room.Status = "空闲";

            BLL.RoomBLL.UpdateRoom(Room);

            BLL.CheckInBLL.DeleteCheckIn(CheckIn);

            MessageBox.Show("退房成功！");

            Close();
        }
    }
}
