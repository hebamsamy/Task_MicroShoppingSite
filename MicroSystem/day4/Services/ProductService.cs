using MicroShopping.Models;
using MicroShopping.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShopping.Services
{
    public class ProductService : ICreatable<Product>, ISaveChange, IReadable<Product>, IUpdatable<Product>, IDeletable
    {
        DataContext context;
        public ProductService(DataContext _context)
        {
            context = _context;
        }
        public int Add(Product Model)
        {
            context.Products.Add(Model);
            context.SaveChanges();
            return Model.ID;
        }

        public int Delete(int id)
        {
            context.Products.Remove(context.Products.FirstOrDefault(s => s.ID == id
            ));
            return 1;
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetDetails(int id)
        {
            return context.Products.FirstOrDefault(s => s.ID == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public int Update(int id, Product model)
        {
            Product product = context.Products.FirstOrDefault(s => s.ID == id);
            product.Image= model.Image;
            product.Name= model.Name;
            product.Price= model.Price;
            product.Quantity= model.Quantity;
            context.SaveChanges();
            return 1;
        }
    }
}
