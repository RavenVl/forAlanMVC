using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alan_mvc;

namespace alan_mvc.Controllers
{ 
    public class constsController : Controller
    {
        private Database1Entities3 db = new Database1Entities3();

        //
        // GET: /consts/

        public ViewResult Index()
        {
            return View(db.consts.ToList());
        }

        //
        // GET: /consts/Details/5

        public ViewResult Details(short id)
        {
            consts consts = db.consts.Find(id);
            return View(consts);
        }

        //
        // GET: /consts/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /consts/Create

        [HttpPost]
        public ActionResult Create(consts consts)
        {
            if (ModelState.IsValid)
            {
                db.consts.Add(consts);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(consts);
        }
        
        //
        // GET: /consts/Edit/5
 
        public ActionResult Edit(short id)
        {
            consts consts = db.consts.Find(id);
            return View(consts);
        }

        //
        // POST: /consts/Edit/5

        [HttpPost]
        public ActionResult Edit(consts consts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consts);
        }

        //
        // GET: /consts/Delete/5
 
        public ActionResult Delete(short id)
        {
            consts consts = db.consts.Find(id);
            return View(consts);
        }

        //
        // POST: /consts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            consts consts = db.consts.Find(id);
            db.consts.Remove(consts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}