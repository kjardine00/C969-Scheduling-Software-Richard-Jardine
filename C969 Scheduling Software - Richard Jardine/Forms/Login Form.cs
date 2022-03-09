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
        string errorMsg = "";

        public LoginForm()
        {
            InitializeComponent();
            Show_Correct_Lang();
        }

        private void Show_Correct_Lang()
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            switch (currentCulture.TwoLetterISOLanguageName)
            {
                case "en":
                    DisplayEng();
                    break;

                case "nl":
                    DisplayDutch();
                    break;

                default:
                    DisplayEng();
                    break;
            }
        }

        private void DisplayEng()
        {
            this.Text = "Login";
            TitleLabel.Text = "Scheduler Assistant";
            UsernameLabel.Text = "Username";
            PasswordLabel.Text = "Password";
            LoginBtn.Text = "Login";
            CloseBtn.Text = "Close";
            errorMsg = "Incorrect username or password";
        }

        private void DisplayDutch()
        {
            this.Text = "Log In";
            TitleLabel.Text = "Planner Assistent";
            UsernameLabel.Text = "Gebruikersnaam";
            PasswordLabel.Text = "Wachtwoord";
            LoginBtn.Text = "Log in";
            CloseBtn.Text = "Afmeleden";
            errorMsg = "Onjuiste gebruikersnaam of wachtwoord";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Admin_DataProcedures data = new Admin_DataProcedures();

            User currentUser = new User(UsernameTextBox.Text, PasswordTextBox.Text);

            int currentUserID = data.GetCurrentUserID(currentUser);

            if (data.VerifyUser(currentUser) == true)
            {
                this.Hide();
                new Dashboard(currentUserID).ShowDialog();
                LoginLog.TrackUserLogins(currentUserID);
            }
            else
            {
                MessageBox.Show(errorMsg);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
