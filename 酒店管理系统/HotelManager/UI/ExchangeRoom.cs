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
    public partial class ExchangeRoom : Form
    {
        public Model.CheckIn CheckIn { get; set; } = new Model.CheckIn();
        public Model.Room Room { get; set; } = new Model.Room();
        public Model.Room ToRoom { get; set; } = new Model.Room();

        public ExchangeRoom()
        {
            InitializeComponent();
        }

        private void ExchangeRoom_Load(object sender, EventArgs e)
        {
            BLL.CheckInBLL.LoadCheckInInfo(CheckIn);

            dateTimePicker1.Text = CheckIn.Time;
            textBox1.Text = CheckIn.Deposit.ToString();

            Room.ID = CheckIn.RoomID; ;

            BLL.RoomBLL.LoadRoomInfo(Room);

            textBox2.Text = Room.Price.ToString();

            dataGridView2.DataSource = BLL.RoomBLL.LoadSelectedRoom(Room);
            dataGridView2.Columns[0].Visible = false;

            dataGridView1.DataSource = BLL.RoomBLL.LoadFreeRoomList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                ToRoom.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                dataGridView3.DataSource = BLL.RoomBLL.LoadSelectedRoom(ToRoom);
                dataGridView3.Columns[0].Visible = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Room.Status = "空闲";
            BLL.RoomBLL.UpdateRoom(Room);

            BLL.RoomBLL.LoadRoomInfo(ToRoom);
            ToRoom.Status = "入住";
            BLL.RoomBLL.UpdateRoom(ToRoom);

            CheckIn.RoomID = ToRoom.ID;
            CheckIn.Time = dateTimePicker2.Value.ToString();
            CheckIn.Deposit -= int.Parse(textBox2.Text.Trim());
            BLL.CheckInBLL.UpdateCheckIn(CheckIn);

            MessageBox.Show("换房成功！");
            Close();
        }
    }
}
