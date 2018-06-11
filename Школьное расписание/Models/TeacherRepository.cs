using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class TeacherRepository
    {
        private Model1Container2 cont;

        public TeacherRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<Teacher> Teachers()
        {
            return cont.TeacherSet.OrderBy(t => t.Name);
        }

        // Поиск элемента по ID
        public Teacher GetTeacher(int id)
        {
            return cont.TeacherSet.Find(id);
        }

        public Teacher Add(string name, string login, string password)
        {
            Teacher th = new Teacher();
            th.Name = name;
            th.Login = login;
            th.Password = password;
            cont.TeacherSet.Add(th);
            cont.SaveChanges();
            return th;
        }

        public void Delete(int id)
        {
            Teacher th = GetTeacher(id);
            if (th != null)
            {
                cont.TeacherSet.Remove(th);
                cont.SaveChanges();
            }
        }

        public void Edit(int id, string name, string login, string password)
        {
            Teacher th = GetTeacher(id);
            if (th != null)
            {
                th.Name = name;
                th.Login = login;
                th.Password = password;
                cont.SaveChanges();
            }
        }

    }
}