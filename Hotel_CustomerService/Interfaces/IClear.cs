using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Interfaces
{
    public interface IClear
    {
        List<ClearViewModel> GetList();

        ClearViewModel GetElement(int id);

        void AddElement(ClearCoverModel model);

        void UpdElement(ClearCoverModel model);

        void DelElement(int id);
    }
}
