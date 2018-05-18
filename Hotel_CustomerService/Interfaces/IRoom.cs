using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Interfaces
{
    public interface IRoom
    {
        List<RoomViewModel> GetList();

        RoomViewModel GetElement(int id);

        void AddElement(RoomCoverModel model);

        void UpdElement(RoomCoverModel model);

        void DelElement(int id);
    }
}
