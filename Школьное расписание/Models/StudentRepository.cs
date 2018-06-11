using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class StudentRepository
    {
        private Model1Container2 cont;

        public StudentRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Student> Students()
        {
            return cont.StudentSet.OrderBy(s => s.Name);
        }

        public Student GetStudent(int id)
        {
            return cont.StudentSet.Find(id);
        }

        public Student Add(string name, Indiv_plan iplan, SClass sc)
        {
            Student st = new Student();
            st.Name = name;
            st.Indiv_plan = iplan;
            st.SClass = sc;
            cont.StudentSet.Add(st);
            cont.SaveChanges();
            return st;
        }

        public void Delete(int id)
        {
            Student st = GetStudent(id);
            if (st != null)
            {
                cont.StudentSet.Remove(st);
                cont.SaveChanges();
            }
        }

        public void Edit(int id, string name, int classID, Indiv_plan iplan, SClass sc)
        {
            Student st = GetStudent(id);
            if (st != null)
            {
                st.Name = name;
                st.Indiv_plan = iplan;
                st.SClass = sc;
                cont.SaveChanges();
            }
        }
    }
}