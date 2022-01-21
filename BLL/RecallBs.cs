using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IRecallBs
    {
        IEnumerable<Recalls> GetAll();
        Recalls GetById(int id);
        bool Insert(Recalls obj);
        bool Update(Recalls obj);
        bool Delete(int id);
    }
    public class RecallBs: IRecallBs
    {
        private IRecallDb objBs;
        public RecallBs(IRecallDb _objBs)
        {
            objBs = _objBs;
        }
        public bool Delete(int id)
        {
            return objBs.Delete(id);
        }

        public IEnumerable<Recalls> GetAll()
        {
            return objBs.GetAll();
        }

        public Recalls GetById(int id)
        {
            return objBs.GetById(id);
        }

        public bool Insert(Recalls obj)
        {
            return objBs.Insert(obj);
        }
     

        public bool Update(Recalls obj)
        {
            return objBs.Update(obj);
        }
    }
}
