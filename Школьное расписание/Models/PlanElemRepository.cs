using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class PlanElemRepository
    {
        private Model1Container2 cont;

        public PlanElemRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<PlanElem> PlanElem()
        {
            return cont.PlanElemSet.OrderBy(t => t.Subject.Name);
        }

        // Поиск элемента по ID
        public PlanElem GetPlanElem(int id)
        {
            return cont.PlanElemSet.Find(id);
        }

        public PlanElem Add(short mo, short tu, short we, short th, short fr, short sa, 
                                Subject sub, string type, Indiv_plan ip, SClass sc)
        {
            PlanElem pl = new PlanElem();
            pl.Mo = mo;
            pl.Tu = tu;
            pl.We = we;
            pl.Th = th;
            pl.Fr = fr;
            pl.Sa = sa;
            pl.Subject = sub;
            pl.Type = type;
            pl.Indiv_plan = ip;
            pl.SClass = sc;
            cont.PlanElemSet.Add(pl);
            cont.SaveChanges();
            return pl;
        }

        public void Delete(int id)
        {
            PlanElem pl = GetPlanElem(id);
            if (pl != null)
            {
                cont.PlanElemSet.Remove(pl);
                cont.SaveChanges();
            }
        }

        public void Edit(int id, short mo, short tu, short we, short th, short fr, short sa,
                                Subject sub, string type, Indiv_plan ip, SClass sc)
        {
            PlanElem pl = GetPlanElem(id);
            if (pl != null)
            {
                pl.Mo = mo;
                pl.Tu = tu;
                pl.We = we;
                pl.Th = th;
                pl.Fr = fr;
                pl.Sa = sa;
                pl.Subject = sub;
                pl.Type = type;
                pl.Indiv_plan = ip;
                pl.SClass = sc;
                cont.SaveChanges();
            }
        }
    }
}