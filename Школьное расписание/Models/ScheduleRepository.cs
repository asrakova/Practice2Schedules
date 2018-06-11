using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class ScheduleRepository
    {
        private Model1Container2 cont;

        public ScheduleRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Schedule> Schedules()
        {
            return cont.ScheduleSet.OrderBy(cw => cw.Date);
        }

        public Schedule GetSchedule(DateTime dt)
        {
            return cont.ScheduleSet.Find(dt);
        }

        public Schedule Add(DateTime dt)
        {
            Schedule sch = new Schedule();
            sch.Date = dt;
            sch.ChangeDate = DateTime.Today;
            cont.ScheduleSet.Add(sch);
            cont.SaveChanges();
            return sch;
        }

        public void Delete(DateTime dt)
        {
            Schedule sch = GetSchedule(dt);
            if (sch != null)
            {
                cont.ScheduleSet.Remove(sch);
                cont.SaveChanges();
            }

        }

        public void Edit(DateTime dt)
        {
            Schedule sch = GetSchedule(dt);
            if (sch != null)
            {
                sch.Date = dt;
                sch.ChangeDate = DateTime.Today;
                cont.SaveChanges();
            }
        }
    }
}