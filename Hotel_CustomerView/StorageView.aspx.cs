using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_CustomerView
{
    public partial class StorageView : System.Web.UI.Page
    {

        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    var Storage = Task.Run(() => APIСlient.GetRequestData<StorageViewModel>("api/Storage/Get/" + id)).Result;
                    TextBox.Text = Storage.StorageName;
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

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            Task task;
            if (Int32.TryParse((string)Session["id"], out id))
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Storage/UpdElement", new StorageCoverModel
                {
                    Id = id,
                    StorageName = TextBox.Text
                }));
            }
            else
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Storage/AddElement", new StorageCoverModel
                {
                    StorageName = TextBox.Text
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
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }, TaskContinuationOptions.OnlyOnFaulted);
            Server.Transfer("StoragesView.aspx");
        }


        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("StoragesView.aspx");
        }
    }
}