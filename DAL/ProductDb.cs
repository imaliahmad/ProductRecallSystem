using BOL;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface IProductDb
    {
        IEnumerable<Products> GetAll();
        Products GetById(int id);
        bool Insert(Products obj);
        bool Update(Products obj);
        bool Delete(int id);
    }
    public  class ProductDb: IProductDb
    {
        private ProductRecallDbContext context;
        public ProductDb(ProductRecallDbContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            var obj = context.Products.Find(id);
            context.Products.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Products> GetAll()
        {
            var list = context.Products.Include(x => x.Manufactureres)
                                                       .Select(y => new Products
                                                       {
                                                           ProductId = y.ProductId,
                                                           Name = y.Name,
                                                           Price = y.Price,
                                                           ManufacturerId = y.ManufacturerId,
                                                           Manufactureres = y.Manufactureres
                                                       })
                                                        .ToList();
            return list;
        }

        public Products GetById(int id)
        {
            return context.Products.Find(id);
        }

        public bool Insert(Products obj)
        {
            context.Products.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool InsertRange(List<Products> list)
        {
            context.Products.AddRange(list);
            context.SaveChanges();
            return true;
        }

        public bool Update(Products obj)
        {
            context.Products.Update(obj);
            context.SaveChanges();
            return true;
        }
    }
}
