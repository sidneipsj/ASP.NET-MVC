using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CRUD.CodeFirstExample.Models;

namespace CRUD.CodeFirstExample.Controllers
{
    public class TeacherController : ApiController
    {
        SchoolContext objContext;

        public TeacherController()
        {
            objContext = new SchoolContext();
        }

        #region List and Details Teacher   

        public ActionResult Index()
        {
            var teachers = objContext.Publishers.ToList();
            return View(teachers);
        }

        public ViewResult Details(int id)
        {
            Teacher teacher =
                objContext..Where(x => x.TeacherId == id).SingleOrDefault();
            return View(teacher);
        }

        #endregion

        #region Create Teacher   

        public ActionResult Create()
        {
            return View(new Teacher());
        }

        [System.Web.Http.HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            objContext.Teachers.Add(teacher);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

        #region edit teacher   

        public ActionResult Edit(int id)
        {
            Teacher teacher = objContext.Teachers.Where(
                x => x.TeacherId == id).SingleOrDefault();
            return View(teacher);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Edit(Teacher model)
        {
            Teacher teacher = objContext.Teachers.Where(
                x => x.TeacherId == model.TeacherId).SingleOrDefault();
            if (teacher != null)
            {
                objContext.Entry(teacher).CurrentValues.SetValues(model);
                objContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        #endregion

        #region Delete Teacher

        public ActionResult Delete(int id)
        {
            Teacher teacher = objContext.Teachers.Find(id);

            return View(publisher);
        }

        [System.Web.Http.HttpPost]
        public ActionResult Delete(int id, Teacher model)
        {
            var teacher =
                objContext.Teachers.Where(x => x.TeacherId == id).SingleOrDefault();
            if (teacher != null)
            {
                objContext.Teachers.Remove(teacher);
                objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
