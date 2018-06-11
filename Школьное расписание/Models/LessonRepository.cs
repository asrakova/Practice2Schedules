using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class LessonRepository
    {
        private Model1Container2 cont;

        public LessonRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Lesson> Lesson()
        {
            return cont.LessonSet.OrderBy(t => t.Number);
        }

        // Поиск элемента по ID
        public Lesson GetLesson(int id)
        {
            return cont.LessonSet.Find(id);
        }

        public Lesson Add(short num, Schedule sch, SClass sc, Subject sub)
        {
            Lesson ls = new Lesson();
            ls.Number = num;
            ls.Schedule = sch;
            ls.SClass = sc;
            ls.Subject = sub;
            cont.LessonSet.Add(ls);
            cont.SaveChanges();
            return ls;
        }

        public void Delete(int id)
        {
            Lesson ls = GetLesson(id);
            if (ls != null)
            {
                cont.LessonSet.Remove(ls);
                cont.SaveChanges();
            }
        }

        public void Edit(int id, short num, Schedule sch, SClass sc, Subject sub)
        {
            Lesson ls = GetLesson(id);
            if (ls != null)
            {
                ls.Number = num;
                ls.Schedule = sch;
                ls.SClass = sc;
                ls.Subject = sub;
                cont.SaveChanges();
            }
        }
    }
}