using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.Interfaces;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Inventory
{
    public class ReportInventory : IReport
    {
        private HotelDbContext context;

        public ReportInventory(HotelDbContext context)
        {
            this.context = context;
        }

        public List<ArmorViewModel> GetArmors(ReportCoverModel model)
        {
            throw new NotImplementedException();
        }

        public List<StorageLoadViewModel> GetStorageLoad()
        {
            throw new NotImplementedException();
        }

        public void SaveArmors(ReportCoverModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveRoomPrice(ReportCoverModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveStorageLoad(ReportCoverModel model)
        {
            throw new NotImplementedException();
        }
    }
}
