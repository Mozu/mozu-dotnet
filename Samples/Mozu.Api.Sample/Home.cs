using System;
using System.Drawing;
using System.Windows.Forms;
using Mozu.Api.Contracts.AppDev;
using Mozu.Api.Contracts.Core;
using Mozu.Api.Contracts.Tenant;
using Mozu.Api.Resources.Platform;
using Mozu.Api.Security;
using System.Linq;

namespace Mozu.Api.Sample
{
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
            new Bootstrapper().Bootstrap();
            MozuConfig.EnableCache = false;
        }


        private ApiContext _apiContext;
        private AuthenticationProfile _userInfo;

        private async void btnAuthenticate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtApplicationID.Text.Length > 20 
                    && txtSharedSecret.Text.Length > 20)
                {
                    btnAuthenticate.Text = "Authenticating...";
                    var appAuthInfo = new AppAuthInfo
                    {
                        ApplicationId = txtApplicationID.Text,
                        SharedSecret = txtSharedSecret.Text
                    };
                    if (txtEmail.Text.Contains("@") &&
                        txtEmail.Text.Contains(".") &&
                        txtPassword.Text.Length > 5)
                    {
                        await AppAuthenticator.InitializeAsync(appAuthInfo);
                        btnAuthenticate.Text = "Loading Scopes...";
                        panelAPI.Visible = true;
                        panelTenant.Visible = true;
                        var userAuthInfo = new UserAuthInfo {EmailAddress = txtEmail.Text, Password = txtPassword.Text};
                        _userInfo = await UserAuthenticator.AuthenticateAsync(userAuthInfo, AuthenticationScope.Tenant);

                        panelTenant.Visible = true;
                        _userInfo.AuthorizedScopes.Insert(0, new Scope {Id = -1, Name = "[Select Tenant]"});
                        cbTenant.DataSource = _userInfo.AuthorizedScopes;

                        btnAuthenticate.Text = "Renew Authentication";
                    }
                    else
                    {
                        btnAuthenticate.Text = "Authenticate";
                        LogError(new Exception("Not enough User data entered for User Scope Authentication")); 
                    }
                }
                else
                {
                   LogError(new Exception("Not enough Application data entered for Authentication")); 
                }
            }
            catch (ApiException exc)
            {
                LogError(exc);
                btnAuthenticate.Text = "Authenticate";
            }
        }

        public static class RichTextBoxExtensions
        {
            public static void AppendText(RichTextBox box, string text, Color color)
            {
                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;

                box.SelectionColor = color;
                box.AppendText(text);
                box.SelectionColor = box.ForeColor;
                box.SelectionStart = box.Text.Length;
                box.ScrollToCaret();
            }
        }

        private void LogError(Exception exc)
        {

            RichTextBoxExtensions.AppendText(txtLog, "[" + DateTime.Now.ToShortTimeString() + "]  ", Color.DarkGreen);
            RichTextBoxExtensions.AppendText(txtLog, exc.Message + System.Environment.NewLine, Color.Red);

        }

        private void AuthValuesChanged(object sender, EventArgs e)
        {
            panelTenant.Visible = false;
            panelAPI.Visible = false;
        }


        private Tenant _tenant;
        private async void cbTenant_changed(object sender, EventArgs e)
        {
            try
            {
                cbSite.DataSource = null;
                var scope = (Scope) cbTenant.SelectedItem;

                if (scope.Id == -1) return;

                var tenantResource = new TenantResource();
                _tenant = await tenantResource.GetTenantAsync(scope.Id);
                var sites = _tenant.Sites;
                cbSite.DataSource = sites;
                cbSite.DisplayMember = "Name";
                panelAPI.Show();

            }
            catch (Exception exc)
            {
                LogError(exc);
            }
         }

        private void setContext()
        {

            var site = (Site)cbSite.SelectedItem;

           var masterCatalog = (from mc in _tenant.MasterCatalogs
            from c in mc.Catalogs
            where c.Id == site.CatalogId
            select mc).SingleOrDefault();

            _apiContext = new ApiContext(site.TenantId, site.Id, masterCatalogId:masterCatalog.Id,catalogId:site.CatalogId);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (cbSite.Items.Count <= 0) return;
            setContext();
            var orderHome =
                new OrderHandler.Orders(new ApiContext(tenantId: _apiContext.TenantId, siteId: _apiContext.SiteId));
            orderHome.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            if (cbSite.Items.Count <= 0) return;
            setContext();
            var productHome = new ProductHandler.Home(new ApiContext(_apiContext.TenantId, masterCatalogId:_apiContext.MasterCatalogId, catalogId:_apiContext.CatalogId));
            productHome.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (cbSite.Items.Count <= 0) return;
            setContext();
            var customersHome = new CustomerHandler.Customers(new ApiContext(_apiContext.TenantId, masterCatalogId: _apiContext.MasterCatalogId, catalogId: _apiContext.CatalogId));
            customersHome.Show();
        }


    }
}
