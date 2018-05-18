using Hotel_Customer;
using Hotel_CustomerService;
using Hotel_CustomerService.CoverModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_CustomerView
{
    public partial class EnterView : System.Web.UI.Page
    {
        public EnterView()
        {
            APIСlient.Connect();
        }
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox3.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Login - enter');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox4.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Password - enter');</script>");
                return;
            }
            Task task = Task.Run(() => APIСlient.PostRequestData("api/Customer/Enter", new CustomerCoverModel
            {
                CustomerLogin = TextBox3.Text,
                Password = TextBox4.Text
            }));
            task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>('Успешно');</script>"),
            TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }, TaskContinuationOptions.OnlyOnFaulted);
            Session["SEid"] = id;
            Server.Transfer("MainView.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("RegisterView.aspx");
        }
    }
}