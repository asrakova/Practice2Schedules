using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Школьное_расписание.Models
{
    public class DataManager
    {
        private Model1Container2 cont;
        public GroupLesRepository GLR;
        public Indiv_planRepository IPR;
        public LessonRepository LR;
        public PlanElemRepository PER;
        public ScheduleRepository SR;
        public SClassRepository SCR;
        public StudentRepository StR;
        public SubjectRepository SubR;
        public TeacherRepository TR;

        public DataManager()
        {
            cont = new Model1Container2();
            GLR = new GroupLesRepository(cont);
            IPR = new Indiv_planRepository(cont);
            LR = new LessonRepository(cont);
            PER = new PlanElemRepository(cont);
            SR = new ScheduleRepository(cont);
            SCR = new SClassRepository(cont);
            StR = new StudentRepository(cont);
            SubR = new SubjectRepository(cont);
            TR = new TeacherRepository(cont);
        }
    }
}