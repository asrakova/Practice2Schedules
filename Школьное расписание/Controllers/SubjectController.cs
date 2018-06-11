using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Школьное_расписание.Models;

namespace Школьное_расписание.Controllers
{
    public class SubjectController : Controller
    {

        private DataManager _DataManager;

        public SubjectController(DataManager _DM)
        {
            _DataManager = _DM;
        }

        public ActionResult SubjectCollection()
        {
            ViewData["Subject"] = _DataManager.SubR.Subjects();

            return View();
        }

        public ActionResult Subject(int id)
        {
            ViewData.Model = _DataManager.SubR.GetSubject(id);

            return View();
        }

        public ActionResult Delete(int id)
        {
            _DataManager.SubR.Delete(id);

            return RedirectToAction("SubjectCollection");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            ViewData["Teachers"] = new SelectList(_DataManager.TR.Teachers(), "Id", "Name");
            List<string> type = new List<string>();
            type.Add("Общий");
            type.Add("Профильный");
            ViewData["Type"] = new SelectList(type);
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(string name, string room, string type, int teacher)
        {
            if (string.IsNullOrWhiteSpace(name))
                ModelState.AddModelError("Name", "Введите название предмета");

            short r=0;

            if (short.TryParse(room, out r) && (r < 1 || r > 6))
                    ModelState.AddModelError("Room", "Номер кабинета введен неверно");

            if (string.IsNullOrWhiteSpace(type))
                ModelState.AddModelError("Type", "Выберите тип предмета");

            if (teacher < 0)
                ModelState.AddModelError("Teacher", "Выберите учителя");

            if (ModelState.IsValid)
            {
                _DataManager.SubR.Add(name, r, type, teacher);
                return RedirectToAction("SubjectCollection");
            }

            ViewData["Teachers"] = new SelectList(_DataManager.TR.Teachers(), "Id", "Name");
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            Subject sub = _DataManager.SubR.GetSubject(id);
            ViewData.Model = sub;

            List<SelectListItem> teachers = new List<SelectListItem>();
            foreach (Teacher t in _DataManager.TR.Teachers())
            {
                teachers.Add(new SelectListItem { Text = t.Name, Value = t.Id.ToString(), Selected = sub.Teacher.Id == t.Id });
            }
            ViewBag.Teacher = teachers;

            List<SelectListItem> types = new List<SelectListItem>();
            types.Add(new SelectListItem { Text = "Общий", Value = "Общий", Selected = sub.Type == "Общий" } );
            types.Add(new SelectListItem { Text = "Профильный", Value = "Профильный", Selected = sub.Type == "Профильный" });
            ViewBag.Type = new SelectList(types);

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, string name, string room, string type, string teacher)
        {
            List<SelectListItem> teachers = new List<SelectListItem>();

            if (string.IsNullOrWhiteSpace(name))
                ModelState.AddModelError("Name", "Введите имя предмета");

            short r;
            int t;

            if (short.TryParse(room, out r))
                if (r < 1 || r > 6)
                    ModelState.AddModelError("Room", "Номер кабинета введен неверно");

            if (string.IsNullOrWhiteSpace(type))
                ModelState.AddModelError("Type", "Выберите тип предмета");

            if (int.TryParse(teacher, out t))
                if (t < 0)
                    ModelState.AddModelError("Teacher", "Выберите учителя");

            if (ModelState.IsValid)
            {
                _DataManager.SubR.Edit(id, name, r, type, t);
                return RedirectToAction("SubjectCollection");
            }

            Subject sub = _DataManager.SubR.GetSubject(id);

            foreach (Teacher tt in _DataManager.TR.Teachers())
            {
                teachers.Add(new SelectListItem { Text = tt.Name, Value = tt.Id.ToString(), Selected = sub.Teacher.Id == tt.Id });
            }


            ViewBag.Teacher = teachers;

            List<SelectListItem> types = new List<SelectListItem>();
            types.Add(new SelectListItem { Text = "Общий", Value = "Общий", Selected = sub.Type == "Общий" });
            types.Add(new SelectListItem { Text = "Профильный", Value = "Профильный", Selected = sub.Type == "Профильный" });
            ViewBag.Type = types;

            return View();
        }
    }
}