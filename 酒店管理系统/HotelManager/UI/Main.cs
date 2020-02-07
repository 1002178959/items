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
    public partial class Main : Form
    {
        private string[] PermissionName = { "超级管理员", "管理员", "员工" };
        private int[] RoomStatus;

        public Model.User NowUser { get; set; }
        public Model.Room Room { get; set; } = new Model.Room();
        public Model.Customer Customer { get; set; } = new Model.Customer();
        public Model.Book Book { get; set; } = new Model.Book();
        public Model.CheckIn CheckIn{ get; set; } = new Model.CheckIn();
        public Model.Cost Cost { get; set; } = new Model.Cost();
        public Model.Goods Goods { get; set; } = new Model.Goods();

        public Main()
        {
            InitializeComponent();
        }

        private void ClearTabPage()
        {
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            tabPage4.Parent = null;
            tabPage5.Parent = null;
            tabPage6.Parent = null;
        }

        private void LoadUser()
        {
            toolStripStatusLabel2.Text += NowUser.Name;
            toolStripStatusLabel3.Text += PermissionName[NowUser.Permission];
        }

        private void LoadRoomStatus()
        {
            RoomStatus = BLL.RoomBLL.LoadRoomStatus();
            label8.Text = "总房间：" + RoomStatus[0].ToString();
            label9.Text = "已预定：" + RoomStatus[1].ToString();
            label10.Text = "已入住：" + RoomStatus[2].ToString();
            label7.Text = "入住率：" + RoomStatus[3].ToString() + "%";
            progressBar1.Value = RoomStatus[3];
        }

        private void LoadRoomList()
        {
            dataGridView1.DataSource = BLL.RoomBLL.LoadRoomList();
            dataGridView1.Columns[0].Visible = false;

        }

        private void LoadBookList()
        {
            dataGridView2.DataSource = BLL.BookBLL.LoadBookList();
            dataGridView2.Columns[0].Visible = false;
        }

        private void LoadCheckInList()
        {
            dataGridView3.DataSource = BLL.CheckInBLL.LoadCheckInList();
            dataGridView3.Columns[0].Visible = false;

            dataGridView4.DataSource = BLL.CheckInBLL.LoadCheckInList();
            dataGridView4.Columns[0].Visible = false;
        }

        private void LoadCostList()
        {
            dataGridView6.DataSource = BLL.CostBLL.LoadCostList(Cost);
            dataGridView6.Columns[0].Visible = false;
        }

        private void LoadGoodsList()
        {
            dataGridView5.DataSource = BLL.GoodsBLL.LoadGoodsList();
            dataGridView5.Columns[0].Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
            LoadUser();
            LoadRoomStatus();
            LoadBookList();
            LoadCheckInList();
            LoadGoodsList();

            ClearTabPage();


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (NowUser.Permission == 2)
            {
                MessageBox.Show("当前用户身份 " + PermissionName[NowUser.Permission] + " 没有这个权限！", "权限不足", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                    ClearTabPage();
                    tabPage1.Parent = tabControl1;
                    tabControl1.SelectedIndex = 1;
                    LoadRoomList();
                    LoadRoomStatus();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (NowUser.Permission == 2)
            {
                MessageBox.Show("当前用户身份 " + PermissionName[NowUser.Permission] + " 没有这个权限！", "权限不足", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
               ClearTabPage();
               tabPage2.Parent = tabControl1;
               tabControl1.SelectedIndex = 1;
               LoadCheckInList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (NowUser.Permission == 2)
            {
                MessageBox.Show("当前用户身份 " + PermissionName[NowUser.Permission] + " 没有这个权限！", "权限不足", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                ClearTabPage();
                tabPage3.Parent = tabControl1;
                tabControl1.SelectedIndex = 1;

                LoadCheckInList();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (NowUser.Permission == 2)
            {
                MessageBox.Show("当前用户身份 " + PermissionName[NowUser.Permission] + " 没有这个权限！", "权限不足", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                ClearTabPage();
                tabPage4.Parent = tabControl1;
                tabControl1.SelectedIndex = 1;

                LoadCheckInList();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (NowUser.Permission == 2)
            {
                MessageBox.Show("当前用户身份 " + PermissionName[NowUser.Permission] + " 没有这个权限！", "权限不足", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                ClearTabPage();
                tabPage5.Parent = tabControl1;
                tabControl1.SelectedIndex = 1;

                LoadGoodsList();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (NowUser.Permission == 2)
            {
                MessageBox.Show("当前用户身份 " + PermissionName[NowUser.Permission] + " 没有这个权限！", "权限不足", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                ClearTabPage();
                tabPage6.Parent = tabControl1;
                tabControl1.SelectedIndex = 1;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RoomEdit form = new RoomEdit() { NewOrEdit = true };
            form.ShowDialog();
            LoadRoomStatus();
            LoadRoomList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            else
            {
                if (MessageBox.Show("确定删除这个房间吗？", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Room.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    BLL.RoomBLL.LoadRoomInfo(Room);

                    if(Room.Status.Equals("空闲"))
                    {
                        MessageBox.Show("删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = BLL.RoomBLL.LoadRoomList();
                    }

                    else
                    {
                        MessageBox.Show("被预订或入住的房间不允许删除！");
                        return;
                    }
                    
                }

                else
                {
                    return;
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }

            else
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            LoadRoomList();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Model.Room QueryRoom = new Model.Room();

            if (checkBox1.Checked)
            {
                if (textBox1.Text.Equals(""))
                {
                    MessageBox.Show("选择的查询项目不能为空！", "无法查询", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else
                {
                    QueryRoom.Number = int.Parse(textBox1.Text);
                }
            }

            if (checkBox2.Checked)
            {
                if (textBox2.Text.Equals(""))
                {
                    MessageBox.Show("选择的查询项目不能为空！", "无法查询", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    QueryRoom.Price = int.Parse(textBox2.Text);
                }
            }

            if (checkBox3.Checked)
            {
                if (textBox3.Text.Equals(""))
                {
                    MessageBox.Show("选择的查询项目不能为空！", "无法查询", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    QueryRoom.Type = textBox3.Text;
                }
            }

            if (checkBox4.Checked)
            {
                if (textBox4.Text.Equals(""))
                {
                    MessageBox.Show("选择的查询项目不能为空！", "无法查询", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else
                {
                    QueryRoom.Note = textBox4.Text;
                }

            }

            if (checkBox5.Checked)
            {
                if (comboBox1.Text.Equals(""))
                {
                    MessageBox.Show("选择的查询项目不能为空！", "无法查询", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                else
                {
                    QueryRoom.Status = comboBox1.Text;
                }
            }

            dataGridView1.DataSource = BLL.RoomBLL.QueryRoom(QueryRoom);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.Enabled = true;
            }

            else
            {
                textBox3.Text = "";
                textBox3.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
            }

            else
            {
                textBox2.Text = "";
                textBox2.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox4.Enabled = true;
            }

            else
            {
                textBox4.Text = "";
                textBox4.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                comboBox1.Enabled = true;
            }

            else
            {
                comboBox1.Text = "";
                comboBox1.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == (char)8)
            { e.Handled = false; }
            else
            { e.Handled = true; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }


            else

            {
                Room.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                RoomEdit form = new RoomEdit() { NewOrEdit = false, Room = Room };
                form.ShowDialog();
                LoadRoomList();
                LoadRoomStatus();
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            BookEdit form = new BookEdit() {BookNewOrEdit=true,CustomerNewOrEdit=true};
            form.ShowDialog();
            LoadBookList();
            LoadRoomStatus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0) 
            {
                return;
            }

            else
            {
                Book.ID = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                BookEdit form = new BookEdit() { BookNewOrEdit = false, CustomerNewOrEdit = false, Book = Book };
                form.ShowDialog();
                LoadBookList();
                LoadRoomStatus();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count <= 0)
            {
                return;
            }

            else
            {
                if (MessageBox.Show("确定取消这个预订吗？", "取消确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Book.ID = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    BLL.BookBLL.DeleteBook(Book);
                    MessageBox.Show("取消成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBookList();
                    LoadRoomStatus();
                }

                else
                {
                    return;
                }

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CheckInEdit form = new CheckInEdit() { BookOrNot=true };
            form.ShowDialog();
            LoadCheckInList();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            CheckInEdit form = new CheckInEdit() { BookOrNot = false };
            form.ShowDialog();
            LoadCheckInList();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                CheckIn.ID = int.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                AddDeposit form = new AddDeposit() { CheckIn = CheckIn };
                form.ShowDialog();

                LoadRoomStatus();
                LoadCheckInList();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            GoodsEdit form = new GoodsEdit();
            form.ShowDialog();
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                Cost.CheckInID = int.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                LoadCostList();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                CheckIn.ID = int.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());
                ExchangeRoom form = new ExchangeRoom() { CheckIn = CheckIn };
                form.ShowDialog();

                LoadRoomStatus();
                LoadCheckInList();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                Goods.ID = int.Parse(dataGridView5.SelectedRows[0].Cells[0].Value.ToString());
                GoodsEdit form = new GoodsEdit() { Goods = Goods };
                form.ShowDialog();

                LoadRoomStatus();
                LoadCheckInList();
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                CheckIn.ID = int.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                AddCost form = new AddCost() { CheckIn = CheckIn };
                form.ShowDialog();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count == 0)
            {
                return;
            }

            else
            {
                CheckIn.ID = int.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                PayEdit form = new PayEdit() { CheckIn = CheckIn };
                form.ShowDialog();
            }
            
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dataGridView7.DataSource = BLL.PayBLL.LoadPayList();
            dataGridView7.Columns[0].Visible = false;
        }
    }
}
