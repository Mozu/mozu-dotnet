using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mozu.Api.Contracts.ProductAdmin;
using Mozu.Api.ToolKit.Readers;

namespace Mozu.Api.Sample.ProductHandler
{

    public partial class Home : Form
    {
        private ApiContext _apiContext;
        public Home(ApiContext apiContext)
        {
            InitializeComponent();
            _apiContext = apiContext;
        }

        private async void btnGetProducts_Click(object sender, EventArgs e)
        {
            btnGetProducts.Text = "Getting Products...";

            var reader = new ProductAdminReader
            {
                Context = _apiContext,
                PageSize = 200,
                StartIndex = 0
            };

            var products = new List<Product>();

            while (await reader.ReadAsync())
            {
                products.AddRange(reader.Items);
            }

            dataGridViewProducts.DataSource = products;
            btnGetProducts.Text = "Refresh Product List";

        }
    }
}
