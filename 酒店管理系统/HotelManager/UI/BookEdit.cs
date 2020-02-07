using System;
using System.Windows.Forms;

namespace HotelManager.UI
{
    public partial class BookEdit : Form
    {
        public Model.Room Room { get; set; } = new Model.Room();
        public Model.Customer Customer { get; set; } = new Model.Customer();
        public Model.Book Book { get; set; }=new Model.Book();

        public bool BookNewOrEdit { get; set; }
        public bool CustomerNewOrEdit { get; set; }

        public BookEdit()
        {
            InitializeComponent();
        }

        private void BookEdit_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLL.RoomBLL.LoadFreeRoomList();
            dataGridView1.Columns[0].Visible = false;

            if (BookNewOrEdit)
            {
                
            }

            else
            {

                dataGridView1.DataSource = null;

                BLL.BookBLL.LoadBookInfo(Book);

                Room.ID = Book.RoomID;
                Customer.ID = Book.CustomerID;

                BLL.RoomBLL.LoadRoomInfo(Room);
                BLL.CustomerBLL.LoadCustomerInfo(Customer);

                textBox8.Text = Room.ID.ToString();
                textBox9.Text = Customer.ID.ToString();

                button1.Enabled = false;
                button2.Enabled = true;

                dataGridView1.Enabled = false;

                dataGridView2.DataSource = BLL.RoomBLL.LoadSelectedRoom(Room);
                dataGridView2.Columns[0].Visible = false;

                textBox1.Text = Customer.Name;
                textBox3.Text = Customer.PhoneNumber;
                textBox10.Text = Customer.Note;

                dateTimePicker1.Value = DateTime.Parse(Book.Time);
                textBox2.Text = Book.Days.ToString();

                textBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox10.Enabled = false;


                CustomerNewOrEdit = false;
                button5.Enabled = false;
                button6.Enabled = true;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            dataGridView1.Enabled = false;
            button2.Enabled = true;

            Room.ID = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            BLL.RoomBLL.LoadRoomInfo(Room);

            Room.Status = "预订";

            BLL.RoomBLL.UpdateRoom(Room);

            BLL.RoomBLL.LoadRoomInfo(Room);

            textBox8.Text = Room.ID.ToString();

            dataGridView2.DataSource = BLL.RoomBLL.LoadSelectedRoom(Room);
            dataGridView2.Columns[0].Visible = false;

            dataGridView1.DataSource = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Room.Status = "空闲";
            BLL.RoomBLL.UpdateRoom(Room);

            button1.Enabled = true;
            button2.Enabled = false;
            dataGridView2.DataSource = null;
            dataGridView1.DataSource= BLL.RoomBLL.LoadFreeRoomList();
            textBox8.Text = "";
            dataGridView1.Enabled = true;

            dataGridView1.DataSource = BLL.RoomBLL.LoadFreeRoomList();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox8.Text=="" || textBox9.Text=="")
            {
                MessageBox.Show("房间和客户都必须选择！");
                return;
            }

            else
            {

                if(BookNewOrEdit)
                {
                    Book.RoomID = Room.ID;
                    Book.CustomerID = Customer.ID;
                    Book.Time = dateTimePicker1.Value.ToString();
                    Book.Days = int.Parse(textBox2.Text.Trim());
                    Book.Note = textBox11.Text.Trim();
                    BLL.BookBLL.InsertBook(Book);

                    MessageBox.Show("预订成功！");
                    Close();
                }

                else
                {
                    Book.RoomID = Room.ID;
                    Book.CustomerID = Customer.ID;
                    Book.Time = dateTimePicker1.Value.ToString();
                    Book.Days = int.Parse(textBox2.Text.Trim());
                    Book.Note = textBox11.Text.Trim();

                    BLL.BookBLL.UpdateBook(Book);

                    MessageBox.Show("修改成功！");
                    Close();

                }
                

                
            }
           
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(CustomerNewOrEdit)
            {
                if(textBox1.Text.Equals(""))
                {
                    MessageBox.Show("客户姓名必填！");
                    return;

                }

                else
                {

                    Customer.Name = textBox1.Text.Trim();
                    Customer.Sex = "";
                    Customer.IDType = "";
                    Customer.IDNumber = "";
                    Customer.PhoneNumber = textBox3.Text.Trim();
                    Customer.Note = textBox10.Text.Trim();
                    Customer.Note = textBox10.Text.Trim();

                    
                    
                    BLL.CustomerBLL.InsertCustomer(Customer);
                    BLL.CustomerBLL.LoadInsertCustomer(Customer);

                    textBox9.Text = Customer.ID.ToString();

                    textBox1.Enabled = false;
                    textBox3.Enabled = false;
                    textBox10.Enabled = false;

                    CustomerNewOrEdit = false;
                    button5.Enabled = false;
                    button6.Enabled = true;
                    
                }
            }

            else
            {
                Customer.Name = textBox1.Text.Trim();
                Customer.Sex = "";
                Customer.IDType = "";
                Customer.IDNumber = "";
                Customer.PhoneNumber = textBox3.Text.Trim();
                Customer.Note = textBox10.Text.Trim();

                BLL.CustomerBLL.UpdateCustomer(Customer);

                textBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox10.Enabled = false;


                CustomerNewOrEdit = false;
                button5.Enabled = false;
                button6.Enabled = true;

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox3.Enabled = true;
            textBox10.Enabled = true;

            button5.Enabled = true;
            button6.Enabled = false;

            
        }
    }
}
