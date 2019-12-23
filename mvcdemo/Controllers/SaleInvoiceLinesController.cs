using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcdemo.Data;
using mvcdemo.Models;

namespace mvcdemo.Controllers
{
    public class SaleInvoiceLinesController : Controller
    {
        private mvcdemo.Data.mvcdemo db = new mvcdemo.Data.mvcdemo();
  // GET: SaleInvoiceLines
        public ActionResult Index()
        {
            var saleInvoiceLines = db.SaleInvoiceLines.Include(s => s.SaleInvoiceLines).Include(s => s.SalesInvoiceHeaders);
            return View(saleInvoiceLines.ToList());
        }
        
        [HttpPost]
       
        // GET: SaleInvoiceLines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleInvoiceLine saleInvoiceLine = db.SaleInvoiceLines.Find(id);
            if (saleInvoiceLine == null)
            {
                return HttpNotFound();
            }
            return View(saleInvoiceLine);
        }

        // GET: SaleInvoiceLines/Create
        public ActionResult Create()
        {
            ViewBag.Items = db.Items.ToList();
            ViewBag.Customers = db.Customers.ToList();
            // ViewBag.customername = new SelectList(db.Customers, "customerid", "customername");
            //ViewBag.itemname = new SelectList(db.Items, "itemid", "itemname");
            return View();
        }

        // POST: SaleInvoiceLines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleLineId,SaleId,ItemId,Qty,Rate")] SaleInvoiceLine saleInvoiceLine)
        {
            if (ModelState.IsValid)
            {
                db.SaleInvoiceLines.Add(saleInvoiceLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.SaleInvoiceLines, "SaleLineId", "SaleLineId", saleInvoiceLine.ItemId);
            ViewBag.SaleId = new SelectList(db.SaleInvoiceHeaders, "SaleId", "InvoiceNo", saleInvoiceLine.SaleId);
            return View(saleInvoiceLine);
        }

        // GET: SaleInvoiceLines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleInvoiceLine saleInvoiceLine = db.SaleInvoiceLines.Find(id);
            if (saleInvoiceLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.SaleInvoiceLines, "SaleLineId", "SaleLineId", saleInvoiceLine.ItemId);
            ViewBag.SaleId = new SelectList(db.SaleInvoiceHeaders, "SaleId", "InvoiceNo", saleInvoiceLine.SaleId);
            return View(saleInvoiceLine);
        }

        // POST: SaleInvoiceLines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleLineId,SaleId,ItemId,Qty,Rate")] SaleInvoiceLine saleInvoiceLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleInvoiceLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.SaleInvoiceLines, "SaleLineId", "SaleLineId", saleInvoiceLine.ItemId);
            ViewBag.SaleId = new SelectList(db.SaleInvoiceHeaders, "SaleId", "InvoiceNo", saleInvoiceLine.SaleId);
            return View(saleInvoiceLine);
        }

        // GET: SaleInvoiceLines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleInvoiceLine saleInvoiceLine = db.SaleInvoiceLines.Find(id);
            if (saleInvoiceLine == null)
            {
                return HttpNotFound();
            }
            return View(saleInvoiceLine);
        }

        // POST: SaleInvoiceLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleInvoiceLine saleInvoiceLine = db.SaleInvoiceLines.Find(id);
            db.SaleInvoiceLines.Remove(saleInvoiceLine);
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
