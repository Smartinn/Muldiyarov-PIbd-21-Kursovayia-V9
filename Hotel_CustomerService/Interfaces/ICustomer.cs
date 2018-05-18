using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Interfaces
{
    public interface ICustomer
    {
        Task<List<CustomerViewModel>> GetList();

        Task<CustomerViewModel> GetElement(int id);

        Task AddElement(CustomerCoverModel model);

        Task UpdElement(CustomerCoverModel model);

        Task DelElement(int id);

        Task Enter(CustomerCoverModel model);
    }
}
