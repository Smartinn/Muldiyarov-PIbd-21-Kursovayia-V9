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
    public class RoomInventory : IRoom
    {
        private HotelDbContext context;

        public RoomInventory(HotelDbContext context)
        {
            this.context = context;
        }

        public List<RoomViewModel> GetList()
        {
            List<RoomViewModel> result = context.Rooms
                .Select(rec => new RoomViewModel
                {
                    Id = rec.Id,
                    RoomName = rec.RoomName,
                    Price = rec.Price,
                    Room_Clears = context.Room_Clears
                            .Where(recPC => recPC.RoomId == rec.Id)
                            .Select(recPC => new Room_ClearViewModel
                            {
                                Id = recPC.Id,
                                RoomId = recPC.RoomId,
                                ClearId = recPC.ClearId,
                                Count = recPC.Count,
                                ClearName = recPC.Clear.ClearName                           
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public RoomViewModel GetElement(int id)
        {
            Room element = context.Rooms.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new RoomViewModel
                {
                    Id = element.Id,
                    RoomName = element.RoomName,
                    Price = element.Price,
                    Room_Clears = context.Room_Clears
                            .Where(recPC => recPC.RoomId == element.Id)
                            .Select(recPC => new Room_ClearViewModel
                            {
                                Id = recPC.Id,
                                RoomId = recPC.RoomId,
                                ClearId = recPC.ClearId,
                                Count = recPC.Count,
                                ClearName = recPC.Clear.ClearName
                            })
                            .ToList()
                };
            }
            throw new Exception("Element not found");
        }

        public void AddElement(RoomCoverModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Room element = context.Rooms.FirstOrDefault(rec => rec.RoomName == model.RoomName);
                    if (element != null)
                    {
                        throw new Exception("Already exist");
                    }
                    element = new Room
                    {
                        RoomName = model.RoomName,
                        Price = model.Price
                    };
                    context.Rooms.Add(element);
                    context.SaveChanges();
                    var groupComponents = model.Room_Clears
                                                .GroupBy(rec => rec.ClearId)
                                                .Select(rec => new
                                                {
                                                    ComponentId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        context.Room_Clears.Add(new Room_Clear
                        {
                            RoomId = element.Id,
                            ClearId = groupComponent.ComponentId,
                            Count = groupComponent.Count
                        });
                        context.SaveChanges();
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

        public void UpdElement(RoomCoverModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Room element = context.Rooms.FirstOrDefault(rec =>
                                        rec.RoomName == model.RoomName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Already exist");
                    }
                    element = context.Rooms.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Doesn't exist");
                    }
                    element.RoomName = model.RoomName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    var compIds = model.Room_Clears.Select(rec => rec.ClearId).Distinct();
                    var updateComponents = context.Room_Clears
                                                    .Where(rec => rec.RoomId == model.Id &&
                                                        compIds.Contains(rec.RoomId));
                    foreach (var updateComponent in updateComponents)
                    {
                        updateComponent.Count = model.Room_Clears
                                                        .FirstOrDefault(rec => rec.Id == updateComponent.Id).Count;
                    }
                    context.SaveChanges();
                    context.Room_Clears.RemoveRange(
                                        context.Room_Clears.Where(rec => rec.RoomId == model.Id &&
                                                                            !compIds.Contains(rec.ClearId)));
                    context.SaveChanges();
                    var groupComponents = model.Room_Clears
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.ClearId)
                                                .Select(rec => new
                                                {
                                                    ComponentId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupComponent in groupComponents)
                    {
                        Room_Clear elementPC = context.Room_Clears
                                                .FirstOrDefault(rec => rec.RoomId == model.Id &&
                                                                rec.ClearId == groupComponent.ComponentId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupComponent.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Room_Clears.Add(new Room_Clear
                            {
                                RoomId = model.Id,
                                ClearId = groupComponent.ComponentId,
                                Count = groupComponent.Count
                            });
                            context.SaveChanges();
                        }
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

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Room element = context.Rooms.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.Room_Clears.RemoveRange(
                                            context.Room_Clears.Where(rec => rec.RoomId == id));
                        context.Rooms.Remove(element);
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
    }
}
