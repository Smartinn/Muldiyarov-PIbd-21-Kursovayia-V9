using Hotel_Customer;
using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.Interfaces;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Inventory
{
    public class ArmorInventory:IArmor
    {
        private HotelDbContext context;

        public ArmorInventory(HotelDbContext context)
        {
            this.context = context;
        }

        public List<ArmorViewModel> GetList()
        {
            List<ArmorViewModel> result = context.Armors
                    .Select(rec => new ArmorViewModel
                    {
                        Id = rec.Id,
                        DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                                    SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                                    SqlFunctions.DateName("yyyy", rec.DateCreate),
                        ArmorStatus = rec.ArmorStatus.ToString(),
                        priceAll = rec.priceAll,
                        CustomerF = context.Customers
                                        .FirstOrDefault(recC => recC.Id == rec.CustomerId).CustomerF,
                        CustomerI = context.Customers
                                        .FirstOrDefault(recC => recC.Id == rec.CustomerId).CustomerI,
                        ArmorItems = context.ArmorItems
                        .Select(rem => new ArmorItemViewModel
                        {
                            Id = rem.Id,
                            RoomId = rem.RoomId,
                            RoomName = rem.RoomName,
                            Price = rem.Price
                        }).ToList()
                    })
                    .ToList();
            return result;
        }

        public void CreateArmor(ArmorCoverModel model)
        {
            int maxId = context.Armors.Count() > 0 ? context.Armors.Max(rec => rec.Id) : 0;
            context.Armors.Add(new Armor
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                DateCreate = DateTime.Now,
                ArmorStatus = ArmorStatus.Принят,
                ArmorItems = context.ArmorItems
                .Select(rem => new ArmorItem
                {
                    Id = rem.Id,
                    RoomId = rem.RoomId,
                    RoomName = rem.RoomName,
                    Price = rem.Price
                }).ToList()
            });
        }


        public void FinishArmor(int id)
        {
            Armor element = context.Armors.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ArmorStatus = ArmorStatus.Готов;
        }

        public void PayArmor(int id)
        {
            Armor element = context.Armors.FirstOrDefault(rec => rec.Id == id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ArmorStatus = ArmorStatus.Оплачен;
        }
    }
}
