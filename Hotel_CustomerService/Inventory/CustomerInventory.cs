using Hotel_Customer;
using Hotel_CustomerService.CoverModels;
using Hotel_CustomerService.Interfaces;
using Hotel_CustomerService.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_CustomerService.Inventory
{
    public class CustomerInventory : ICustomer
    {
        private HotelDbContext context;

        public CustomerInventory(HotelDbContext context)
        {
            this.context = context;
        }

        public async Task AddElement(CustomerCoverModel model)
        {
            Customer element = await context.Customers.FirstOrDefaultAsync(rec => rec.CustomerLogin.Equals(model.CustomerLogin));
            if (element != null)
            {
                throw new Exception("Already have a customer with such a login");
            }
            element = await context.Customers.FirstOrDefaultAsync(rec => rec.Mail.Equals(model.Mail));
            if (element != null)
            {
                throw new Exception("Already have a @mail");
            }
            context.Customers.Add(new Customer
            {
                CustomerI = model.CustomerI,
                CustomerF = model.CustomerF,
                CustomerLogin = model.CustomerLogin,
                Password = model.Password,
                Mail = model.Mail
            });
            await context.SaveChangesAsync();
        }

        public async Task DelElement(int id)
        {
            Customer element = await context.Customers.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                context.Customers.Remove(element);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Customer doesn't exist");
            }
        }

        public async Task<CustomerViewModel> GetElement(int id)
        {
            Customer element = await context.Customers.FirstOrDefaultAsync(rec => rec.Id == id);
            if (element != null)
            {
                return new CustomerViewModel
                {
                    Id = element.Id,
                    CustomerI = element.CustomerI,
                    CustomerF = element.CustomerF,
                    CustomerLogin = element.CustomerLogin,
                    Mail = element.Mail
                };
            }
            throw new Exception("Element not found");
        }

        public async Task<List<CustomerViewModel>> GetList()
        {
            List<CustomerViewModel> result = await context.Customers
                .Select(rec => new CustomerViewModel
                {
                    Id = rec.Id,
                    CustomerI = rec.CustomerI,
                    CustomerF = rec.CustomerF,
                    CustomerLogin = rec.CustomerLogin,
                    Mail = rec.Mail
                })
                .ToListAsync();
            return result;
        }

        public async Task UpdElement(CustomerCoverModel model)
        {
            Customer element = await context.Customers.FirstOrDefaultAsync(rec =>
                        (rec.CustomerLogin == model.CustomerLogin) && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Already exist");
            }
            element = await context.Customers.FirstOrDefaultAsync(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Customer doesn't exist");
            }
            element.CustomerI = model.CustomerI;
            element.CustomerF = model.CustomerF;
            element.CustomerLogin = model.CustomerLogin;
            await context.SaveChangesAsync();
        }
        public async Task Enter(CustomerCoverModel model)
        {
            Customer element = await context.Customers.FirstOrDefaultAsync(rec => rec.CustomerLogin.Equals(model.CustomerLogin));
            if (element == null)
            {
                throw new Exception("Dosn't have customer with this login");
            }
            element = await context.Customers.FirstOrDefaultAsync(rec => rec.Mail.Equals(model.Mail));
            if (element == null)
            {
                throw new Exception("Wrong password");
            }
        }
    }
}
