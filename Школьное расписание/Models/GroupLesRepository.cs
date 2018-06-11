using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class GroupLesRepository
    {
        private Model1Container2 cont;

        public GroupLesRepository(Model1Container2 _cont)
        {
            cont = _cont;
        }

        public IEnumerable<GroupLes> GroupLes()
        {
            return cont.GroupLesSet.OrderBy(t => t.Subject.Name);
        }

        // Поиск элемента по ID
        public GroupLes GetGroupLes(int id)
        {
            return cont.GroupLesSet.Find(id);
        }

        public GroupLes Add(short mo, short tu, short we, short th, short fr, short sa, Subject sub)
        {
            GroupLes gl = new GroupLes();
            gl.Mo = mo;
            gl.Tu = tu;
            gl.We = we;
            gl.Th = th;
            gl.Fr = fr;
            gl.Sa = sa;
            gl.Subject = sub;
            cont.GroupLesSet.Add(gl);
            cont.SaveChanges();
            return gl;
        }

        public void Delete(int id)
        {
            GroupLes gl = GetGroupLes(id);
            if (gl != null)
            {
                cont.GroupLesSet.Remove(gl);
                cont.SaveChanges();
            }
        }

        public void Edit(int id, short mo, short tu, short we, short th, short fr, short sa, Subject sub)
        {
            GroupLes gl = GetGroupLes(id);
            if (gl != null)
            {
                gl.Mo = mo;
                gl.Tu = tu;
                gl.We = we;
                gl.Th = th;
                gl.Fr = fr;
                gl.Sa = sa;
                gl.Subject = sub;
                cont.SaveChanges();
            }
        }

    }
}