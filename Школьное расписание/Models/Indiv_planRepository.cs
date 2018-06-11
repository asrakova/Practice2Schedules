using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class Indiv_planRepository
    {
        private Model1Container2 cont;

        public Indiv_planRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Indiv_plan> Indiv_plan()
        {
            return cont.Indiv_planSet.OrderBy(t => t.Name);
        }

        // Поиск элемента по ID
        public Indiv_plan GetIndiv_plan(int id)
        {
            return cont.Indiv_planSet.Find(id);
        }

        public Indiv_plan Add(string name)
        {
            Indiv_plan ip = new Indiv_plan();
            ip.Name = name;
            cont.Indiv_planSet.Add(ip);
            cont.SaveChanges();
            return ip;
        }

        public void Delete(int id)
        {
            Indiv_plan ip = GetIndiv_plan(id);
            if (ip != null)
            {
                cont.Indiv_planSet.Remove(ip);
                cont.SaveChanges();
            }
        }

        public void Edit(int id, string name)
        {
            Indiv_plan ip = GetIndiv_plan(id);
            if (ip != null)
            {
                ip.Name = name;
                cont.SaveChanges();
            }
        }
    }
}