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
    public partial class AddDeposit : Form
    {
        public Model.CheckIn CheckIn { get; set; } = new Model.CheckIn();
        public Model.Room Room { get; set; } = new Model.Room();

        public AddDeposit()
        {
            InitializeComponent();
        }

        private void AddDeposit_Load(object sender, EventArgs e)
        {
            BLL.CheckInBLL.LoadCheckInInfo(CheckIn);
            Room.ID = CheckIn.RoomID;
            BLL.RoomBLL.LoadRoomInfo(Room);

            textBox8.Text = Room.Number.ToString();
            textBox9.Text = CheckIn.Deposit.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckIn.Deposit += int.Parse(textBox1.Text.Trim());
            BLL.CheckInBLL.UpdateCheckIn(CheckIn);
            MessageBox.Show("成功！");
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == (char)8)
            { e.Handled = false; }
            else
            { e.Handled = true; }
        }
    }
}
