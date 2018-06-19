using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCTutorial.Models;

namespace MVCTutorial.Controllers
{
    public class OrderLinesController : Controller
    {
        private CustomerAppContext db = new CustomerAppContext();

        // GET: OrderLines
        public ActionResult Index()
        {
            var orderLines = db.OrderLines.Include(o => o.Order);
            return View(orderLines.ToList());
        }

        // GET: OrderLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // GET: OrderLines/Create
        public ActionResult Create()
        {
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Description");
            return View();
        }

        // POST: OrderLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderId,Product,Quantity,Price")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.OrderLines.Add(orderLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Description", orderLine.OrderId);
            return View(orderLine);
        }

        // GET: OrderLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Description", orderLine.OrderId);
            return View(orderLine);
        }

        // POST: OrderLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,Product,Quantity,Price")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "Description", orderLine.OrderId);
            return View(orderLine);
        }

        // GET: OrderLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // POST: OrderLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderLine orderLine = db.OrderLines.Find(id);
            db.OrderLines.Remove(orderLine);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
