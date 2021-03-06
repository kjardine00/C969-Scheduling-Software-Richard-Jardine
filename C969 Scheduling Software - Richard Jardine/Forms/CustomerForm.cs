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
        private bool NewCust = false;

        public CustomerForm(bool NewCustomer, int CustID)
        {
            InitializeComponent();
            Admin_DataProcedures Adata = new Admin_DataProcedures();
            Customer_DataProcedures Cdata = new Customer_DataProcedures();

            NewCust = NewCustomer;

            if (NewCustomer == true)
            {
                CustomerTitle.Text = "New Customer";
                CustIDText.Text = Adata.CreateNewID("customer").ToString();
            }
            else
            {
                CustomerTitle.Text = "Update Customer";

                Customer selectedCustomer = Cdata.GetSelectedCustomer(CustID);

                CustIDText.Text = selectedCustomer.CustID.ToString();
                CustNameText.Text = selectedCustomer.CustName;
                CustAddress1Text.Text = selectedCustomer.CustAddress1;
                CustAddress2Text.Text = selectedCustomer.CustAddress2;
                CustCityText.Text = selectedCustomer.CustCity;
                CustCountryText.Text = selectedCustomer.CustCountry;
                CustPostalCodeText.Text = selectedCustomer.CustPostalCode;
                CustPhoneText.Text = selectedCustomer.CustPhone;
            }
        }

        private void CustSaveBtn_Click(object sender, EventArgs e)
        {
            Customer_DataProcedures data = new Customer_DataProcedures();

            bool allFieldshaveText = true;

            if (string.IsNullOrEmpty(CustIDText.Text))
            {
                allFieldshaveText = false;
                CustIDText.BackColor = Color.Salmon;
            }
            if (string.IsNullOrEmpty(CustNameText.Text))
            {
                allFieldshaveText = false;
                CustNameText.BackColor = Color.Salmon;
            }
            if (string.IsNullOrEmpty(CustAddress1Text.Text))
            {
                allFieldshaveText = false;
                CustAddress1Text.BackColor = Color.Salmon;
            }
            if (string.IsNullOrEmpty(CustCityText.Text))
            {
                allFieldshaveText = false;
                CustCityText.BackColor = Color.Salmon;
            }
            if (string.IsNullOrEmpty(CustCountryText.Text))
            {
                allFieldshaveText = false;
                CustCountryText.BackColor = Color.Salmon;
            }
            if (string.IsNullOrEmpty(CustPostalCodeText.Text))
            {
                allFieldshaveText = false;
                CustPostalCodeText.BackColor = Color.Salmon;
            }
            if (string.IsNullOrEmpty(CustPhoneText.Text))
            {
                allFieldshaveText = false;
                CustPhoneText.BackColor = Color.Salmon;
            }

            if ( allFieldshaveText == true)
            {
            Customer customerToBeSaved = new Customer(
                Convert.ToInt32(CustIDText.Text), 
                CustNameText.Text, 
                CustAddress1Text.Text, 
                CustAddress2Text.Text, 
                CustCityText.Text, 
                CustCountryText.Text, 
                CustPostalCodeText.Text, 
                CustPhoneText.Text
                );

            if (NewCust == true)
            {
                data.SaveNewCustomer(customerToBeSaved);
            }
            else
            {
                data.SaveUpdatedCustomer(customerToBeSaved);
            }
            Close();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields.");
            }
        }

        private void CustCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
