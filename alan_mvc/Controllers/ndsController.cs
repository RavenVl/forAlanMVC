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
    public class ndsController : Controller
    {
        private Database1Entities3 db = new Database1Entities3();

        //
        // GET: /nds/

        //public ViewResult Index()
        //{
        //    return View(db.nds.ToList());
        //}
        public string Index()
        {
            string s_out = "";
            var s = db.nds.ToList();
            foreach (var item in s)
            {
                if (item.myis==true)
                {
                    s_out += item.id + " " + item.name + ",";
                }
                
            }

            return s_out;
        }
        //
        // GET: /nds/Details/5

        public ViewResult Details(short id)
        {
            nds nds = db.nds.Find(id);
            return View(nds);
        }

        //
        // GET: /nds/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /nds/Create

        [HttpPost]
        public ActionResult Create(nds nds)
        {
            if (ModelState.IsValid)
            {
                db.nds.Add(nds);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(nds);
        }
        
        //
        // GET: /nds/Edit/5
 
        public ActionResult Edit(short id)
        {
            nds nds = db.nds.Find(id);
            return View(nds);
        }

        //
        // POST: /nds/Edit/5

        [HttpPost]
        public string Edit(nds nds)
        {

            string StudentName = Request.Form["st1"];
            string OcenkaName = Request.Form["n1"];
            
            int n = StudentName.IndexOf(' ');
            string sn = StudentName.Substring(0,n);
            int ind = Convert.ToInt16(sn);
            nds = db.nds.Find(ind);

            int n1 = OcenkaName.IndexOf(' ');
            string sn1 = OcenkaName.Substring(0, n1);
            int ind1 = Convert.ToInt16(sn1);

           
            switch (ind1)
            {
                case 1:
                    nds.c1 += 1;
                    break;
                case 2:
                    nds.c2 += 1;
                    break;

                case 3:
                    nds.c3 += 1;
                    break;
                case 4:
                    nds.c4 += 1;
                    break;

                case 5:
                    nds.c5 += 1;
                    break;

                case 6:
                    nds.c6 += 1;
                    break;

                case 7:
                    nds.c7 += 1;
                    break;

                case 8:
                    nds.c8 += 1;
                    break;

                case 9:
                    nds.c9 += 1;
                    break;
               
            }

           
            if (ModelState.IsValid)
            {
                db.Entry(nds).State = EntityState.Modified;
                db.SaveChanges();
                
            }
            return "Ok";
        }

        //
        // GET: /nds/Delete/5
 
        public ActionResult Delete(short id)
        {
            nds nds = db.nds.Find(id);
            return View(nds);
        }

        //
        // POST: /nds/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(short id)
        {            
            nds nds = db.nds.Find(id);
            db.nds.Remove(nds);
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