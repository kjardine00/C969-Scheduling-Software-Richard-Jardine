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
            Customer_DataProcedures data = new Customer_DataProcedures();

            NewCust = NewCustomer;

            if (NewCustomer == true)
            {
                CustomerTitle.Text = "New Customer";
                CustIDText.Text = CustID.ToString();
            }
            else
            {
                CustomerTitle.Text = "Update Customer";

                Customer selectedCustomer = data.UpdatedCustList(CustID);

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
        }

        private void CustCancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
