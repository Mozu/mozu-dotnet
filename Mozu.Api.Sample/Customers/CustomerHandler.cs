using System;
using System.Linq;
using System.Windows.Forms;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Resources.Commerce.Customer;
using Mozu.Api.Resources.Commerce.Customer.Accounts;

namespace Mozu.Api.Sample.CustomerHandler
{
    public partial class Customers : Form
    {
        private ApiContext _apiContext;
        public Customers(ApiContext apiContext)
        {
            InitializeComponent();
            _apiContext = apiContext;
        }

        private void btnGetCustomers_Click(object sender, EventArgs e)
        {
            btnGetCustomers.Text = "Getting Customers...";
            var customerResource = new CustomerAccountResource(_apiContext);
            CustomerAccountCollection customers = customerResource.GetAccounts();

            if (customers != null && customers.Items.Count > 0)
                dataGridViewCustomers.DataSource = customers.Items;
            btnGetCustomers.Text = "Refresh Customer List";

        }
    }
}
