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
    public partial class PutOnStorageView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<ClearViewModel> listP = Task.Run(() => APIСlient.GetRequestData<List<ClearViewModel>>("api/Clear/GetList")).Result;
                if (listP != null)
                {
                    DropDownListElement.DataSource = listP;
                    DropDownListElement.DataTextField = "ClearName";
                    DropDownListElement.DataValueField = "Id";
                    DropDownListElement.DataBind();

                }
                List<StorageViewModel> listS = Task.Run(() => APIСlient.GetRequestData<List<StorageViewModel>>("api/Storage/GetList")).Result;
                if (listS != null)
                {

                    DropDownListStorage.DataSource = listS;
                    DropDownListStorage.DataTextField = "StorageName";
                    DropDownListStorage.DataValueField = "Id";
                    DropDownListStorage.DataBind();
                }
                Page.DataBind();
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

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле количество');</script>");
                return;
            }
            if (DropDownListElement.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите чист-средство');</script>");
                return;
            }
            if (DropDownListStorage.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите склад');</script>");
                return;
            }
            try
            {
                int componentId = Convert.ToInt32(DropDownListElement.SelectedValue);
                int stockId = Convert.ToInt32(DropDownListStorage.SelectedValue);
                int count = Convert.ToInt32(TextBoxCount.Text);
                Task task = Task.Run(() => APIСlient.PostRequestData("api/Storage/PutClearOnStorage", new StorageClearCoverModel
                {
                    ClearId = componentId,
                    StorageId = stockId,
                    Count = count
                }));
                task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>"),
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
                Server.Transfer("FormMain.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}