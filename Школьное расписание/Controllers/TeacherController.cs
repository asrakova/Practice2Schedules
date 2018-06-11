using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Школьное_расписание.Models;

namespace Школьное_расписание.Controllers
{
    public class TeacherController : Controller
    {
        private DataManager _DataManager;

        public TeacherController(DataManager _DM)
        {
            _DataManager = _DM;
        }

        public ActionResult TeacherCollection()
        {
            ViewData["Teachers"] = _DataManager.TR.Teachers();

            return View();
        }

        public ActionResult Teacher(int id)
        {
            ViewData.Model = _DataManager.TR.GetTeacher(id);

            return View();
        }

        public ActionResult Delete(int id)
        {
            _DataManager.TR.Delete(id);

            return RedirectToAction("TeacherCollection");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            //ViewData["Students"] = new SelectList(_DataManager.SR.Students(), "Id", "Name");
            //ViewData["Teachers"] = new SelectList(_DataManager.TR.Teachers(), "Id", "Name");
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(string name, string login, string password, string copyPassword)
        {
            if (string.IsNullOrWhiteSpace(name))
                ModelState.AddModelError("Name", "Введите имя учителя");

            if (string.IsNullOrWhiteSpace(login))
                ModelState.AddModelError("Login", "Введите логин");

            if (string.IsNullOrWhiteSpace(password))
                ModelState.AddModelError("Password", "Введите пароль");

            if (string.IsNullOrWhiteSpace(copyPassword))
                ModelState.AddModelError("Password", "Повторите пароль");

            if (password != copyPassword)
                ModelState.AddModelError("Password", "Пароли не совпадают");

            if (ModelState.IsValid)
            {
                _DataManager.TR.Add(name, login, password);
                return RedirectToAction("TeacherCollection");
            }
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            Teacher cw = _DataManager.TR.GetTeacher(id);
            ViewData.Model = cw;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, string name, string login, string password, string copyPassword)
        {
            if (string.IsNullOrWhiteSpace(name))
                ModelState.AddModelError("Name", "Введите имя учителя");

            if (string.IsNullOrWhiteSpace(login))
                ModelState.AddModelError("Login", "Введите логин");

            if (string.IsNullOrWhiteSpace(password))
                ModelState.AddModelError("Password", "Введите пароль");

            if (string.IsNullOrWhiteSpace(copyPassword))
                ModelState.AddModelError("Password", "Повторите пароль");

            if (password != copyPassword)
                ModelState.AddModelError("Password", "Пароли не совпадают");


            if (ModelState.IsValid)
            {
                _DataManager.TR.Edit(id, name, login, password);
                return RedirectToAction("TeacherCollection");
            }

            Teacher cw = _DataManager.TR.GetTeacher(id);

            return View();
        }
    }
}