using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IProductBs
    {
        IEnumerable<Products> GetAll();
        Products GetById(int id);
        bool Insert(Products obj);
        bool Update(Products obj);
        bool Delete(int id);
    }
    public class ProductBs: IProductBs
    {
        private IProductDb objBs;
        public ProductBs(IProductDb _objBs)
        {
            objBs = _objBs;
        }
        public bool Delete(int id)
        {
            return objBs.Delete(id);
        }

        public IEnumerable<Products> GetAll()
        {
            return objBs.GetAll();
        }

        public Products GetById(int id)
        {
            return objBs.GetById(id);
        }

        public bool Insert(Products obj)
        {
            return objBs.Insert(obj);
        }


        public bool Update(Products obj)
        {
            return objBs.Update(obj);
        }
    }
}
