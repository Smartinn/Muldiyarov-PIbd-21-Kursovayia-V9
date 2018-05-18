using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Interfaces
{
    public interface IStorage
    {
        List<StorageViewModel> GetList();

        StorageViewModel GetElement(int id);

        void AddElement(StorageCoverModel model);

        void UpdElement(StorageCoverModel model);

        void DelElement(int id);
        void PutClearOnStorage(StorageClearCoverModel model);
    }
}
