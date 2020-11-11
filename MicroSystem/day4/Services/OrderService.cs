using MicroShopping.Models;
using MicroShopping.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Services
{
    public class OrderService : IReadable<Order>,ISaveChange,IUpdatable<Order>,IDeletable
    {
        DataContext context;
        public OrderService(DataContext _context)
        {
            context = _context;
        }
       

        public int Delete(int id)
        {
            context.Orders.Remove(context.Orders.FirstOrDefault(s => s.ID == id
            ));
            return 1;
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetDetails(int id)
        {
            return context.Orders.FirstOrDefault(s => s.ID == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public int Update(int id, Order model)
        {
            Order order = context.Orders.FirstOrDefault(s => s.ID == id);
            order.Date = model.Date;
            order.Count = model.Count;
            context.SaveChanges();
            return 1;

        }
    }
}
