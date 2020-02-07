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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("用户名不能为空！", "无法登陆", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else if(textBox2.Text.Equals(""))
            {
                MessageBox.Show("密码不能为空！", "无法登陆", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {

                Model.User User = new Model.User() { Username = textBox1.Text, Password = textBox2.Text };

                int LoginVerifyStatus = BLL.UserBLL.LoginVerify(User);

                if (LoginVerifyStatus == 0)
                {
                    MessageBox.Show("该用户不存在！", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox1.Text = "";
                }

                else if (LoginVerifyStatus == 1)
                {
                    MessageBox.Show("密码错误！", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox2.Text = "";
                }

                else //登陆成功
                {
                    this.Hide();
                    Main form = new Main() { NowUser = User };
                    form.Show();
                    
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = System.DateTime.Now.ToString();
        }
    }
}
