using System;
using System.Windows.Forms;
using Mozu.Api.Contracts.CommerceRuntime.Orders;
using Mozu.Api.Resources.Commerce;
using Mozu.Api.Resources.Commerce.Orders;

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

        private void btnGetOrders_Click(object sender, EventArgs e)
        {
            btnGetOrders.Text = "Getting Orders...";
            var orderResource = new OrderResource(_apiContext);
            OrderCollection orders = orderResource.GetOrders();

            if (orders != null && orders.Items.Count > 0)
                dataGridViewOrders.DataSource = orders.Items;
            btnGetOrders.Text = "Refresh Orders";
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
