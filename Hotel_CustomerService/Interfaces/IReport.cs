using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Interfaces
{
    public interface IReport
    {
        void SaveRoomPrice(ReportCoverModel model);

        List<StorageLoadViewModel> GetStorageLoad();

        void SaveStorageLoad(ReportCoverModel model);

        List<ArmorViewModel> GetArmors(ReportCoverModel model);

        void SaveArmors(ReportCoverModel model);
    }
}
