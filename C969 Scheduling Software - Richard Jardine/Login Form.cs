using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

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
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            switch (currentCulture.TwoLetterISOLanguageName)
            {
                case "en":
                    displayEng();
                    break;

                case "nl":
                    displayDutch();
                    break;

                default:
                    displayEng();
                    break;
            }
        }

        private void displayEng()
        {
            this.Text = "Login";
            TitleLabel.Text = "Scheduler Assistant";
            UsernameLabel.Text = "Username";
            PasswordLabel.Text = "Password";
            LoginBtn.Text = "Login";
            CloseBtn.Text = "Close";
        }

        private void displayDutch()
        {
            this.Text = "Log In";
            TitleLabel.Text = "Planner Assistent";
            UsernameLabel.Text = "Gebruikersnaam";
            PasswordLabel.Text = "Wachtwoord";
            LoginBtn.Text = "Log in";
            CloseBtn.Text = "Afmeleden";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Login_DataProcedures data = new Login_DataProcedures();
            User currentUser = new User(UsernameTextBox.Text, PasswordTextBox.Text);

            if (data.VerifyUser(currentUser) == true)
            {
                this.Hide();
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
