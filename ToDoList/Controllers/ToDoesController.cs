using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private object toDo;
        private ApplicationUser currentUser;
        private IEnumerable<ToDo> myToDoes;

        public IEnumerable<ToDo> MyToDoes { get => myToDoes; set => myToDoes = value; }
        public object ToDo { get => toDo; set => toDo = value; }
        internal ApplicationUser CurrentUser { get => currentUser; set => currentUser = value; }

        public ActionResult Index()
        {
            var model = new ToDo { };
            return View("Index", model);
        }

        private IEnumerable<ToDo> GetMyToDoes()
        {
            string currentUserId = User.Identity.GetUserId();


            int completeCount = 0;
            {
                {
                    completeCount++;
                }
            }


            return MyToDoes;
        }

        public ActionResult BuildToDoTable()
        {
            return PartialView("_ToDoTable", GetMyToDoes());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            {
                return HttpNotFound();
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsDone")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {

            }

            return View(toDo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AJAXCreate([Bind(Include = "Id,Description")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {


            }

            return PartialView("_ToDoTable", GetMyToDoes());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ToDo == null)
            {
                return HttpNotFound();
            }

            string currentUserId = User.Identity.GetUserId();

            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsDone")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDo);
        }

        [HttpPost]
        public ActionResult AJAXEdit(int? id, bool value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            {
                return HttpNotFound();
            }
            {
            }


        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return ToDo == null ? HttpNotFound() : (ActionResult)View(ToDo);
        }

        [ValidateAntiForgeryToken]






        internal class ApplicationUser
        {
            internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
            {
                throw new NotImplementedException();
            }
        }

        internal class ApplicationDbContext
        {

            internal void Dispose()
            {
                throw new NotImplementedException();
            }

            internal object Entry(ToDo toDo)
            {
                throw new NotImplementedException();
            }

            internal object Entry(object toDo)
            {
                throw new NotImplementedException();
            }

            internal void SaveChanges()
            {
                throw new NotImplementedException();
            }
        }
    }
}
  
