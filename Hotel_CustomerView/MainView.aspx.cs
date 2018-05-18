using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.Interfaces;
using Hotel_CustomerService.Inventory;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_CustomerView
{
    public partial class MainView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var Customer = Task.Run(() => APIСlient.GetRequestData<CustomerViewModel>("api/Customer/Get/" + Session["SEid"])).Result;
                Label1.Text = Customer.CustomerF;
                Label3.Text = Customer.CustomerI;
                Label5.Text = Customer.CustomerLogin;
                Label7.Text = Customer.Mail;
                List<ArmorViewModel> list = Task.Run(() => APIСlient.GetRequestData<List<ArmorViewModel>>("api/Cutomer/GetList")).Result;
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.AutoGenerateSelectButton = true;
                    dataGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
            
        }
    }
}