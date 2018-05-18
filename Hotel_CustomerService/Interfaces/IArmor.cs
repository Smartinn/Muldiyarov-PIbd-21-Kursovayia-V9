using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Interfaces
{
    public interface IArmor
    {
        List<ArmorViewModel> GetList();

        void CreateArmor(ArmorCoverModel model);

        void FinishArmor(int id);

        void PayArmor(int id);
    }
}
