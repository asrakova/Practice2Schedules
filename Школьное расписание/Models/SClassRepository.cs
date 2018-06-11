using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class SClassRepository
    {
        private Model1Container2 cont;

        public SClassRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<SClass> SClass()
        {
            return cont.SClassSet.OrderBy(s => s.Number+s.Letter);
        }

        public SClass GetSClass(int id)
        {
            return cont.SClassSet.Find(id);
        }

        public SClass Add(short num, string let)
        {
            SClass sc = new SClass();
            sc.Number = num;
            sc.Letter = let;
            cont.SClassSet.Add(sc);
            cont.SaveChanges();
            return sc;
        }

        public void Delete(int id)
        {
            SClass sc = GetSClass(id);
            if (sc != null)
            {
                cont.SClassSet.Remove(sc);
                cont.SaveChanges();
            }
        }

        public void Edit(int id, short num, string let)
        {
            SClass sc = GetSClass(id);
            if (sc != null)
            {
                sc.Number = num;
                sc.Letter = let;
                cont.SaveChanges();
            }
        }
    }
}