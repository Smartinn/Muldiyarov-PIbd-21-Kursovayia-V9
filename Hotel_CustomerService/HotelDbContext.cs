using Hotel_Customer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_CustomerService
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext() : base("HotelDB")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<ArmorItem> ArmorItems { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<Armor> Armors { get; set; }

        public virtual DbSet<Clear> Clears { get; set; }

        public virtual DbSet<Room_Clear> Room_Clears { get; set; }

        public virtual DbSet<Storage> Storages { get; set; }

        public virtual DbSet<StorageClear> StorageClears { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception)
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.State = EntityState.Unchanged;
                            break;
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
                throw;
            }
        }
    }
}
