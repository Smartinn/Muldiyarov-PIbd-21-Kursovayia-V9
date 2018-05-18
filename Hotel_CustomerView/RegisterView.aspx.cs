using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_CustomerView
{
    public partial class RegisterView : System.Web.UI.Page
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    var Customer = Task.Run(() => APIСlient.GetRequestData<CustomerViewModel>("api/Customer/Get/" + id)).Result;
                    TextBox.Text = Customer.CustomerF;
                    TextBox1.Text = Customer.CustomerI;
                    TextBox2.Text = Customer.Mail;
                    TextBox4.Text = Customer.Password;
                    TextBox3.Text = Customer.CustomerLogin;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните Фамилию');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните Имя');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox3.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните Login');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox2.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните @mail');</script>");
                return;
            }
            if (!Regex.IsMatch(TextBox2.Text, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Неверный формат');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox4.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните Password');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox5.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('ConfirmPassword');</script>");
                return;
            }
            if (TextBox5.Text != TextBox4.Text)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Password не совпадают');</script>");
                return;
            }
            Task task;
            if (Int32.TryParse((string)Session["id"], out id))
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Customer/UpdElement", new CustomerCoverModel
                {
                    Id = id,
                    CustomerF = TextBox.Text,
                    CustomerI = TextBox1.Text,
                    CustomerLogin = TextBox3.Text,
                    Password = TextBox4.Text,
                    Mail = TextBox2.Text
                }));
            }
            else
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Customer/AddElement", new CustomerCoverModel
                {
                    CustomerF = TextBox.Text,
                    CustomerI = TextBox1.Text,
                    CustomerLogin = TextBox3.Text,
                    Password = TextBox4.Text,
                    Mail = TextBox2.Text
                }));
            }
            task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>('Сохранение прошло успешно');</script>"),
               TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith((prevTask) =>
            {
                var ex = (Exception)prevTask.Exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                
            }, TaskContinuationOptions.OnlyOnFaulted);
            Server.Transfer("EnterView.aspx");
        }


        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("EnterView.aspx");
        }
    }
}