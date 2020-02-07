using System;
using System.Windows.Forms;

namespace HotelManager.UI
{
    public partial class CheckInEdit : Form
    {
        public Model.Book Book { get; set; } = new Model.Book();
        public Model.Room Room { get; set; } = new Model.Room();
        public Model.Customer Customer1 { get; set; } = new Model.Customer();
        public Model.Customer Customer2 { get; set; } = new Model.Customer();
        public Model.CheckIn CheckIn { get; set; } = new Model.CheckIn();
        public bool BookOrNot { get; set; }

        public CheckInEdit()
        {
            InitializeComponent();
        }

        private void CheckInEdit_Load(object sender, EventArgs e)
        {
            if(BookOrNot)
            {
                groupBox2.Enabled = true;
                dataGridView3.DataSource = BLL.BookBLL.LoadBookList();
                dataGridView3.Columns[0].Visible = false;
            }

            else
            {
                dataGridView1.DataSource = BLL.RoomBLL.LoadFreeRoomList();
                groupBox2.Enabled = false;
            }

            dateTimePicker1.Text = "";

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                groupBox5.Enabled = true;
            }

            else
            {
                groupBox5.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count <= 0)
            {
                return;
            }

            else
            {
                Book.ID = int.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());

                BLL.BookBLL.LoadBookInfo(Book);

                Room.ID = Book.RoomID;

                Customer1.ID = Book.CustomerID;

                BLL.RoomBLL.LoadRoomInfo(Room);

                BLL.CustomerBLL.LoadCustomerInfo(Customer1);


                textBox1.Text = Customer1.Name;
                comboBox2.Text = Customer1.Sex;
                comboBox1.Text = Customer1.IDType;
                textBox3.Text = Customer1.IDNumber;
                textBox4.Text = Customer1.PhoneNumber;
                textBox2.Text = Customer1.Note;
                textBox13.Text = Customer1.ID.ToString();
                textBox16.Text = Book.ID.ToString();

                dataGridView2.DataSource = BLL.RoomBLL.LoadSelectedRoom(Room);

                textBox15.Text = Room.ID.ToString();

                dateTimePicker1.Text = Book.Time;

                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
                button4.Enabled = true;
                button5.Enabled = false;

                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox2.Enabled = false;
                textBox13.Enabled = false;
                textBox16.Enabled = false;

                textBox10.Text = (int.Parse(textBox17.Text.Trim()) * Room.Price + Room.Price).ToString();
                textBox11.Text = (int.Parse(textBox17.Text.Trim()) * Room.Price + Room.Price).ToString();

            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = ""; ;
            textBox2.Text = "";
            textBox13.Text = "";

            dataGridView2.DataSource = null;
            textBox15.Text = "";


            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;

            if(BookOrNot)
            {
                BLL.RoomBLL.LoadRoomInfo(Room);
                Room.Status = "空闲";
                BLL.RoomBLL.UpdateRoom(Room);

            }

            dataGridView1.DataSource = BLL.RoomBLL.LoadFreeRoomList();

            button3.Enabled = true;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;
            }

            else
            {
                Room.ID=int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                if (BookOrNot)
                {
                    Book.RoomID = Room.ID;
                    BLL.BookBLL.UpdateBook(Book);

                    BLL.RoomBLL.LoadRoomInfo(Room);
                    Room.Status = "预订";
                    BLL.RoomBLL.UpdateRoom(Room);
                    
                }

                BLL.RoomBLL.LoadRoomInfo(Room);

                dataGridView2.DataSource = BLL.RoomBLL.LoadSelectedRoom(Room);
                dataGridView2.Columns[0].Visible = false;

                textBox15.Text = Room.ID.ToString();

                

                dataGridView1.DataSource = null;

                button4.Enabled = true;

                textBox11.Text = ((Room.Price)*2).ToString();

                textBox10.Text = (int.Parse(textBox17.Text.Trim()) * Room.Price + Room.Price).ToString();
                textBox11.Text = (int.Parse(textBox17.Text.Trim()) * Room.Price + Room.Price).ToString();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox2.Enabled = true;

            button5.Enabled = true;
            button6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(BookOrNot)
            {
                Customer1.Name = textBox1.Text.Trim();
                Customer1.Sex = comboBox2.Text.Trim();
                Customer1.IDType = comboBox1.Text.Trim();
                Customer1.IDNumber = textBox3.Text.Trim();
                Customer1.PhoneNumber = textBox4.Text.Trim();
                Customer1.Note = textBox2.Text;

                BLL.CustomerBLL.UpdateCustomer(Customer1);

                button5.Enabled = false;
                button6.Enabled = true;

                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox2.Enabled = false;

                button5.Enabled = true;
                button6.Enabled = false;
            }

            else
            {
                if(Customer1.ID==0)
                {
                    Customer1.Name = textBox1.Text.Trim();
                    Customer1.Sex = comboBox2.Text.Trim();
                    Customer1.IDType = comboBox1.Text.Trim();
                    Customer1.IDNumber = textBox3.Text.Trim();
                    Customer1.PhoneNumber = textBox4.Text.Trim();
                    Customer1.Note = textBox2.Text;

                    BLL.CustomerBLL.InsertCustomer(Customer1);

                    BLL.CustomerBLL.LoadInsertCustomer(Customer1);

                    BLL.CustomerBLL.LoadCustomerInfo(Customer1);

                    button5.Enabled = false;
                    button6.Enabled = true;

                    textBox1.Enabled = false;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox2.Enabled = false;

                    button5.Enabled = true;
                    button6.Enabled = false;

                    textBox13.Text = Customer1.ID.ToString();
                }

                else
                {
                    Customer1.Name = textBox1.Text.Trim();
                    Customer1.Sex = comboBox2.Text.Trim();
                    Customer1.IDType = comboBox1.Text.Trim();
                    Customer1.IDNumber = textBox3.Text.Trim();
                    Customer1.PhoneNumber = textBox4.Text.Trim();
                    Customer1.Note = textBox2.Text;

                    BLL.CustomerBLL.UpdateCustomer(Customer1);

                    button5.Enabled = false;
                    button6.Enabled = true;

                    textBox1.Enabled = false;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox2.Enabled = false;

                    button5.Enabled = true;
                    button6.Enabled = false;

                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(checkBox1.Enabled)
            {
                Customer2.Name = textBox8.Text.Trim();
                Customer2.Sex = comboBox3.Text.Trim();
                Customer2.IDType = comboBox4.Text.Trim();
                Customer2.IDNumber = textBox7.Text.Trim();
                Customer2.PhoneNumber = textBox5.Text.Trim();
                Customer2.Note = textBox6.Text.Trim();

                BLL.CustomerBLL.InsertCustomer(Customer2);
                BLL.CustomerBLL.LoadInsertCustomer(Customer2);
                BLL.CustomerBLL.LoadCustomerInfo(Customer2);

                textBox14.Text = Customer2.ID.ToString();
                checkBox1.Enabled = false;

                
                button8.Enabled = false;
                button7.Enabled = true;

                textBox8.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                textBox7.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;

            }

            else
            {
                Customer2.Name = textBox8.Text.Trim();
                Customer2.Sex = comboBox3.Text.Trim();
                Customer2.IDType = comboBox4.Text.Trim();
                Customer2.IDNumber = textBox7.Text.Trim();
                Customer2.PhoneNumber = textBox5.Text.Trim();
                Customer2.Note = textBox6.Text.Trim();

                BLL.CustomerBLL.UpdateCustomer(Customer2);

                button8.Enabled = false;
                button7.Enabled = true;

                textBox8.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                textBox7.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button8.Enabled = true;
            button7.Enabled = false;

            textBox8.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            textBox7.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(Room.ID==0 ||Customer1.ID==0)
            {
                MessageBox.Show("房间和用户信息必填！");
            }

            else
            {
                CheckIn.RoomID = Room.ID;

                CheckIn.Customer1ID = Customer1.ID;

                if (!checkBox1.Enabled)
                {
                    CheckIn.Customer2ID = Customer2.ID;
                }



                CheckIn.Time = dateTimePicker2.Value.ToString();

                CheckIn.Days = int.Parse(textBox17.Text.Trim());

                CheckIn.Deposit = int.Parse(textBox11.Text.ToString());

                CheckIn.Note = textBox12.Text;

                Room.Status = "入住";

                BLL.RoomBLL.UpdateRoom(Room);
                BLL.CheckInBLL.InsertCheckIn(CheckIn);

                MessageBox.Show("入住成功！");

                Close();
            }

        }


        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == ' ' || e.KeyChar == ',' || e.KeyChar == (char)8)
            { e.Handled = false; }
            else
            { e.Handled = true; }

        }


        private void textBox17_Leave(object sender, EventArgs e)
        {
            textBox10.Text = (int.Parse(textBox17.Text.Trim()) * Room.Price + Room.Price).ToString();
            textBox11.Text = (int.Parse(textBox17.Text.Trim()) * Room.Price + Room.Price).ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
