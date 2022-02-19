using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Scheduling_Software___Richard_Jardine
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Show_correct_lang();
        }

        private void Show_correct_lang()
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Data_Procedures data = new Data_Procedures();
            User currentUser = new User(UsernameTextBox.Text, PasswordTextBox.Text);

            if (data.verifyUser(currentUser) == true)
            {
                this.Close();
                new Dashboard().ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
