using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mozu.Api.Contracts.Customer;
using Mozu.Api.Resources.Commerce.Customer;
using Mozu.Api.Resources.Commerce.Customer.Accounts;
using Mozu.Api.ToolKit.Readers;

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

        private async void btnGetCustomers_Click(object sender, EventArgs e)
        {
            btnGetCustomers.Text = "Getting Customers...";
            

            var customers = new List<CustomerAccount>();

            var customerReader = new CustomerAccountReader
            {
                Context = _apiContext,
                PageSize = 200,
                StartIndex = 0
            };

            while (await customerReader.ReadAsync())
            {
                customers.AddRange(customerReader.Items);
            }

            dataGridViewCustomers.DataSource = customers;
            btnGetCustomers.Text = "Refresh Customer List";

        }
    }
}
