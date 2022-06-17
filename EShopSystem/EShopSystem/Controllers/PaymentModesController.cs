﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShopSystem.DAL;
using EShopSystem.Models;

namespace EShopSystem.Controllers
{
    public class PaymentModesController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: PaymentModes
        public ActionResult Index()
        {
            return View(db.PaymentModes.ToList());
        }

        // GET: PaymentModes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMode paymentMode = db.PaymentModes.Find(id);
            if (paymentMode == null)
            {
                return HttpNotFound();
            }
            return View(paymentMode);
        }

        // GET: PaymentModes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentModes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentModeId,PaymentModeName,PaymentModeIsActive")] PaymentMode paymentMode)
        {
            if (ModelState.IsValid)
            {
                db.PaymentModes.Add(paymentMode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentMode);
        }

        // GET: PaymentModes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMode paymentMode = db.PaymentModes.Find(id);
            if (paymentMode == null)
            {
                return HttpNotFound();
            }
            return View(paymentMode);
        }

        // POST: PaymentModes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentModeId,PaymentModeName,PaymentModeIsActive")] PaymentMode paymentMode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentMode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentMode);
        }

        // GET: PaymentModes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMode paymentMode = db.PaymentModes.Find(id);
            if (paymentMode == null)
            {
                return HttpNotFound();
            }
            return View(paymentMode);
        }

        // POST: PaymentModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentMode paymentMode = db.PaymentModes.Find(id);
            db.PaymentModes.Remove(paymentMode);
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
