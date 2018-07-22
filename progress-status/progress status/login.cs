using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progress_status
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_userName.Text == "123")
            {
                Form1 frmUi = new Form1();
                this.Visible = false;
                frmUi.ShowDialog();
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("密码 or 用户名错误");
            }
        }
    }
}
