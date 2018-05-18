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
    public partial class Room : System.Web.UI.Page
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {

                try
                {
                    var Room = Task.Run(() => APIСlient.GetRequestData<RoomViewModel>("api/Room/Get/" + id)).Result;
                    TextBox.Text = Room.RoomName;
                    TextBox1.Text = Room.Price.ToString();
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
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                List<RoomViewModel> list = Task.Run(() => APIСlient.GetRequestData<List<RoomViewModel>>("api/Room/GetList")).Result;
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

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название комнаты');</script>");
                return;
            }
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните цену комнаты');</script>");
                return;
            }
            Task task;
            string name = TextBox.Text;
            int price = Convert.ToInt32(TextBox1.Text);
            if (Int32.TryParse((string)Session["id"], out id))
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Room/UpdElement", new RoomCoverModel
                {
                    Id = id,
                    RoomName = name,
                    Price = price
                }));
            }
            else
            {
                task = Task.Run(() => APIСlient.PostRequestData("api/Room/AddElement", new RoomCoverModel
                {
                    RoomName = name,
                    Price = price
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
            TextBox.Text = "";
            TextBox1.Text = "";
            Session["id"] = null;
            Server.Transfer("RoomView.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                string index = dataGridView.Rows[dataGridView.SelectedIndex].Cells[1].Text;
                Session["id"] = index;
                Server.Transfer("RoomView.aspx");

            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView.Rows[dataGridView.SelectedIndex].Cells[1].Text);
                Task task = Task.Run(() => APIСlient.PostRequestData("api/Room/DelElement", new RoomCoverModel { Id = id }));
                task.ContinueWith((prevTask) => Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Запись удалена');</script>"),
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
                LoadData();
                Server.Transfer("RoomView.aspx");
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            LoadData();
        }
    }
}