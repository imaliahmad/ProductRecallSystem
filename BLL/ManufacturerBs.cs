using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IManufacturerBs
    {
        IEnumerable<Manufactureres> GetAll();
        Manufactureres GetById(int id);
        bool Insert(Manufactureres obj);
        bool Update(Manufactureres obj);
        bool Delete(int id);
    }
    public class ManufacturerBs: IManufacturerBs
    {
        private IManufacturerDb objDb;
        public ManufacturerBs(IManufacturerDb _objDb)
        {
            objDb = _objDb;
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }

        public IEnumerable<Manufactureres> GetAll()
        {
            return objDb.GetAll();
        }

        public Manufactureres GetById(int id)
        {
            return objDb.GetById(id);
        }

        public bool Insert(Manufactureres obj)
        {
            return objDb.Insert(obj);
        }


        public bool Update(Manufactureres obj)
        {
            return objDb.Update(obj);
        }
    }
}
