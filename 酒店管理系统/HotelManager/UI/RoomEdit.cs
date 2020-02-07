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
    public partial class RoomEdit : Form
    {
        public bool NewOrEdit { get; set; }
        public Model.Room Room { get; set; } = new Model.Room();

        public RoomEdit()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="" || textBox3.Text=="" || textBox4.Text=="")
            {
                MessageBox.Show("必填信息不能为空！","有信息为空",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }

            else
            {
                if(NewOrEdit)
                {
                    Room.Number = int.Parse(textBox2.Text.Trim());
                    Room.Price = int.Parse(textBox3.Text.Trim());
                    Room.Type = textBox4.Text.Trim();
                    Room.Status = textBox5.Text.Trim();
                    Room.Note = textBox6.Text.Trim();

                    BLL.RoomBLL.InsertRoom(Room);
                    MessageBox.Show("房间 " + textBox2.Text + " 添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }

                else
                {
                    Room.ID = int.Parse(textBox1.Text.Trim());
                    Room.Number = int.Parse(textBox2.Text.Trim());
                    Room.Price = int.Parse(textBox3.Text.Trim());
                    Room.Type = textBox4.Text.Trim();
                    Room.Status = textBox5.Text.Trim();
                    Room.Note = textBox6.Text.Trim();

                    BLL.RoomBLL.UpdateRoom(Room);
                    MessageBox.Show("房间 " + textBox2.Text + " 修改成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                }
                
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == (char)8)
                { e.Handled = false; }
            else
                { e.Handled = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoomEdit_Load(object sender, EventArgs e)
        {
            if(!NewOrEdit)
            {
                BLL.RoomBLL.LoadRoomInfo(Room);
                textBox1.Text = Room.ID.ToString();
                textBox2.Text = Room.Number.ToString();
                textBox3.Text = Room.Price.ToString();
                textBox4.Text = Room.Type.ToString();
                textBox5.Text = Room.Status.ToString();
                textBox6.Text = Room.Note.ToString();

                if(Room.Status.Equals("预订")||Room.Status.Equals("入住"))
                {
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                }
            }
        }
    }
}
