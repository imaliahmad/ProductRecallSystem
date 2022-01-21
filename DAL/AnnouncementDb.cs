using BOL;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IAnnouncementDb
    {
        IEnumerable<Announcements> GetAll();
        Announcements GetById(int id);
        bool Insert(Announcements obj);
        bool InsertRange(List<Announcements> list);
        bool Update(Announcements obj);
        bool Delete(int id);
    }
    public class AnnouncementDb: IAnnouncementDb
    {
        private ProductRecallDbContext context;
        public AnnouncementDb(ProductRecallDbContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            var obj = context.Announcements.Find(id);
            context.Announcements.Remove(obj);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Announcements> GetAll()
        {
            return context.Announcements;
        }

        public Announcements GetById(int id)
        {
            return context.Announcements.Find(id);
        }

        public bool Insert(Announcements obj)
        {
            context.Announcements.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool InsertRange(List<Announcements> list)
        {
            context.Announcements.AddRange(list);
            context.SaveChanges();
            return true;
        }

        public bool Update(Announcements obj)
        {
            context.Announcements.Update(obj);
            context.SaveChanges();
            return true;
        }
    }
}
