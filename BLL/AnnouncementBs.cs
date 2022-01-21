using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IAnnouncementBs
    {
        IEnumerable<Announcements> GetAll();
        Announcements GetById(int id);
        bool Insert(Announcements obj);
        bool Update(Announcements obj);
        bool Delete(int id);
    }
    public class AnnouncementBs: IAnnouncementBs
    {
        private IAnnouncementDb objBs;
        public AnnouncementBs(IAnnouncementDb _objBs)
        {
            objBs = _objBs;
        }
        public bool Delete(int id)
        {
            return objBs.Delete(id);
        }

        public IEnumerable<Announcements> GetAll()
        {
            return objBs.GetAll();
        }

        public Announcements GetById(int id)
        {
            return objBs.GetById(id);
        }

        public bool Insert(Announcements obj)
        {
            return objBs.Insert(obj);
        }
        public bool InsertRange(List<Announcements> list)
        {
            return objBs.InsertRange(list);
        }

        public bool Update(Announcements obj)
        {
            return objBs.Update(obj);
        }
    }
}
