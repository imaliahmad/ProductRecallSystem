using BOL;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRecallDb
    {
        IEnumerable<Recalls> GetAll();
        Recalls GetById(int id);
        bool Insert(Recalls obj);
        bool Update(Recalls obj);
        bool Delete(int id);
    }
    public class RecallDb: IRecallDb
    {
        private ProductRecallDbContext context;
        public RecallDb(ProductRecallDbContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            var obj = context.Recalls.Find(id);
            context.Recalls.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Recalls> GetAll()
        {
            return context.Recalls;
        }

        public Recalls GetById(int id)
        {
            return context.Recalls.Find(id);
        }

        public bool Insert(Recalls obj)
        {
            context.Recalls.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool InsertRange(List<Recalls> list)
        {
            context.Recalls.AddRange(list);
            context.SaveChanges();
            return true;
        }

        public bool Update(Recalls obj)
        {
            context.Recalls.Update(obj);
            context.SaveChanges();
            return true;
        }
    }
}
