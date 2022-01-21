using BOL;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface IManufacturerDb
    {
        IEnumerable<Manufactureres> GetAll();
        Manufactureres GetById(int id);
        bool Insert(Manufactureres obj);
        bool Update(Manufactureres obj);
        bool Delete(int id);
    }
    public class ManufacturerDb : IManufacturerDb
    {
        private ProductRecallDbContext context;
        public ManufacturerDb(ProductRecallDbContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            var obj = context.Manufactureres.Find(id);
            context.Manufactureres.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Manufactureres> GetAll()
        {
            var list = context.Manufactureres.Include(x => x.Products)
                                                                   .Select(y => new Manufactureres 
                                                                   {
                                                                     ManufacturerId = y.ManufacturerId,
                                                                     Name = y.Name,
                                                                     City = y.City,
                                                                     Address = y.Address,
                                                                     State = y.State,
                                                                     ZipCode = y.ZipCode,
                                                                     Products = y.Products.Select(m => new Products 
                                                                                                                {
                                                                                                                   ProductId = m.ProductId,
                                                                                                                   Name = m.Name,
                                                                                                                   Price = m.Price
                                                                                                                   })
                                                                   })
                                                                   .ToList();
            return list;
        }

        public Manufactureres GetById(int id)
        {
            return context.Manufactureres.Find(id);
        }

        public bool Insert(Manufactureres obj)
        {
            context.Manufactureres.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool InsertRange(List<Manufactureres> list)
        {
            context.Manufactureres.AddRange(list);
            context.SaveChanges();
            return true;
        }

        public bool Update(Manufactureres obj)
        {
            context.Manufactureres.Update(obj);
            context.SaveChanges();
            return true;
        }
    }
}
