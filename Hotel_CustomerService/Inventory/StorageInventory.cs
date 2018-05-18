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
    public class StorageInventory : IStorage
    {
        private HotelDbContext context;

        public StorageInventory(HotelDbContext context)
        {
            this.context = context;
        }

        public void AddElement(StorageCoverModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Already have a Stock with such a name");
            }
            context.Storages.Add(new Storage
            {
                StorageName = model.StorageName
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.StorageClears.RemoveRange(
                                            context.StorageClears.Where(rec => rec.StorageId == id));
                        context.Storages.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Doesn't exist");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public StorageViewModel GetElement(int id)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    StorageName = element.StorageName,
                    Id = element.Id,
                    StorageClears = context.StorageClears.Where(recPS => recPS.StorageId == element.Id)
                    .Select(recPS => new StorageClearViewModel
                    {
                        Id = recPS.Id,
                        StorageId = recPS.StorageId,
                        ClearId = recPS.ClearId,
                        Count = recPS.Count,
                        ClearName = recPS.Clear.ClearName
                    }).ToList()

                };
            }
            throw new Exception("Element not found");
        }

        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = context.Storages.Select(rec => new StorageViewModel
            {
                StorageName = rec.StorageName,
                Id = rec.Id,
                StorageClears = context.StorageClears.Where(recPS => recPS.StorageId == rec.Id)
                    .Select(recPS => new StorageClearViewModel
                    {
                        Id = recPS.Id,
                        StorageId = recPS.StorageId,
                        ClearId = recPS.ClearId,
                        Count = recPS.Count,
                        ClearName = recPS.Clear.ClearName
                    }).ToList()
            })
                .ToList();
            return result;
        }

        public void UpdElement(StorageCoverModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec =>
                                    rec.StorageName == model.StorageName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Already exist");
            }
            element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Doesn't exist");
            }
            element.StorageName = model.StorageName;
            context.SaveChanges();
        }

        public void PutClearOnStorage(StorageClearCoverModel model)
        {
            StorageClear element = context.StorageClears
                                                .FirstOrDefault(rec => rec.StorageId == model.StorageId &&
                                                                    rec.ClearId == model.ClearId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StorageClears.Add(new StorageClear
                {
                    StorageId = model.StorageId,
                    ClearId = model.ClearId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
