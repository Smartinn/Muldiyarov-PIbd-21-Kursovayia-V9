using Hotel_Customer;
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
    public class ClearInventory : IClear
    {
        private HotelDbContext context;

        public ClearInventory(HotelDbContext context)
        {
            this.context = context;
        }

        public List<ClearViewModel> GetList()
        {
            List<ClearViewModel> result = context.Clears
                .Select(rec => new ClearViewModel
                {
                    Id = rec.Id,
                    ClearName = rec.ClearName
                })
                .ToList();
            return result;
        }

        public ClearViewModel GetElement(int id)
        {
            Clear element = context.Clears.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ClearViewModel
                {
                    Id = element.Id,
                    ClearName = element.ClearName
                };
            }
            throw new Exception("Element not found");
        }

        public void AddElement(ClearCoverModel model)
        {
            Clear element = context.Clears.FirstOrDefault(rec => rec.ClearName == model.ClearName);
            if (element != null)
            {
                throw new Exception("Already exist");
            }
            context.Clears.Add(new Clear
            {
                ClearName = model.ClearName
            });
            context.SaveChanges();
        }

        public void UpdElement(ClearCoverModel model)
        {
            Clear element = context.Clears.FirstOrDefault(rec =>
                                        rec.ClearName == model.ClearName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Already exist");
            }
            element = context.Clears.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Doesn't exist");
            }
            element.ClearName = model.ClearName;
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Clear element = context.Clears.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Clears.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Doesn't exist");
            }
        }
    }
}
