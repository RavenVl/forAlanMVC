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
    public class ocenkasController : Controller
    {
        private Database1Entities3 db = new Database1Entities3();

        //
        // GET: /ocenkas/

       
           public string Index()
        {
            string s_out = "";
            var s = db.ocenkas.ToList();
            foreach (var item in s)
            {
                if (item.myis == true)
                {
                    s_out += item.id + " " + item.name + ",";
                }
            }

            return s_out;
        }
        

        //
        // GET: /ocenkas/Details/5

        public ViewResult Details(short id)
        {
            ocenkas ocenkas = db.ocenkas.Find(id);
            return View(ocenkas);
        }

        //
        // GET: /ocenkas/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ocenkas/Create

        [HttpPost]
        public ActionResult Create(ocenkas ocenkas)
        {
            if (ModelState.IsValid)
            {
                db.ocenkas.Add(ocenkas);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(ocenkas);
        }
        
        //
        // GET: /ocenkas/Edit/5
 
        public ActionResult Edit(short id)
        {
            ocenkas ocenkas = db.ocenkas.Find(id);
            return View(ocenkas);
        }

        //
        // POST: /ocenkas/Edit/5

        [HttpPost]
        public ActionResult Edit(ocenkas ocenkas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocenkas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ocenkas);
        }

        //
        // GET: /ocenkas/Delete/5
 
        public ActionResult Delete(short id)
        {
            ocenkas ocenkas = db.ocenkas.Find(id);
            return View(ocenkas);
        }

        //
        // POST: /ocenkas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            ocenkas ocenkas = db.ocenkas.Find(id);
            db.ocenkas.Remove(ocenkas);
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