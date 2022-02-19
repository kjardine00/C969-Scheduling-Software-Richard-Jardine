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
    public partial class CustomerForm : Form
    {
        public CustomerForm(bool NewCustomer)
        {
            InitializeComponent();

            if (NewCustomer == true)
            {
                CustomerTitle.Text = "New Customer";

                
            }
            else
            {
                CustomerTitle.Text = "Update Customer";

                //CustNameText.Text =
                //CustAddress1Text.Text =
                //CustAddress1Text.Text = 
                //CustCityText.Text =
                //CustCountryText.Text =
                //CustPostalCodeText.Text =
                //CustPhoneText.Text =


            }
        }

        private void CustSaveBtn_Click(object sender, EventArgs e)
        {

        }

        private void CustCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
