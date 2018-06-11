using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class SubjectRepository
    {
        private Model1Container2 cont;

        public SubjectRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Subject> Subjects()
        {
            return cont.SubjectSet.OrderBy(s => s.Name);
        }

        public Subject GetSubject(int id)
        {
            return cont.SubjectSet.Find(id);
        }

        public Subject Add(string name, short room, string type, int th)
        {
            Subject sb = new Subject();
            sb.Name = name;
            sb.Room = room;
            sb.Type = type;
            sb.Teacher = cont.TeacherSet.Find(th);
            cont.SubjectSet.Add(sb);
            cont.SaveChanges();
            return sb;
        }

        public void Delete(int id)
        {
            Subject sb = GetSubject(id);
            if (sb != null)
            {
                cont.SubjectSet.Remove(sb);
                cont.SaveChanges();
            }
        }

        public void Edit(int id, string name, short room, string type, int th)
        {
            Subject sb = GetSubject(id);
            if (sb != null)
            {
                sb.Name = name;
                sb.Room = room;
                sb.Type = type;
                sb.Teacher = cont.TeacherSet.Find(th);
                cont.SaveChanges();
            }
        }
    }
}