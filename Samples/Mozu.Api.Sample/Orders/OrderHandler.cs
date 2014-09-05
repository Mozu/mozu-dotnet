using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Mozu.Api.Contracts.CommerceRuntime.Orders;
using Mozu.Api.Resources.Commerce;
using Mozu.Api.Resources.Commerce.Orders;
using Mozu.Api.ToolKit.Readers;

namespace Mozu.Api.Sample.OrderHandler
{
    public partial class Orders : Form
    {
        private ApiContext _apiContext;
        public Orders(ApiContext apiContext)
        {
            InitializeComponent();
            _apiContext = apiContext;
        }

        private async void btnGetOrders_Click(object sender, EventArgs e)
        {
            btnGetOrders.Text = "Getting Orders...";

            var orderReader = new OrderReader
            {
                Context = _apiContext,
                PageSize = 200,
                StartIndex = 0
            };

            var orders = new List<Order>();
            while (await orderReader.ReadAsync())
            {
                orders.AddRange(orderReader.Items);
            }
    
            dataGridViewOrders.DataSource = orders;
            btnGetOrders.Text = "Refresh Orders";
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnGetOrderByGuid_Click(object sender, EventArgs e)
        {
            var orderGuid = txtOrderGuid.Text;
            var orderResource = new OrderResource(_apiContext);
            var order = await orderResource.GetOrderAsync(orderGuid);

            if (order != null && order.Items.Count > 0)
                dataGridViewOrders.DataSource = order.Items;
        }

    }
}
