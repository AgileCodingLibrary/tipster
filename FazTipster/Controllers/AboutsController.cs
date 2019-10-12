﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FazTipster.Entities;
using FazTipster.Models;

namespace FazTipster.Controllers
{
    [Authorize(Roles = "Masteradmin")]
    public class AboutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        //public ActionResult Index()
        //{
        //    return View(db.Abouts.ToList());
        //}

       
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    About about = db.Abouts.Find(id);
        //    if (about == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(about);
        //}

       
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Abouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Header,FirstTopParagraph,SecondTopParagraph,PackagesTitle,PackageOneHeading,PackageOneDetails,PackageTwoHeading,PackageTWoDetails,PackageThreeHeading,PackageThreeDetails")] About about)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Abouts.Add(about);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(about);
        //}

      
        public ActionResult Edit(int? id)
        {
            About about = null;

            if (id == null)
            {
                about = db.Abouts.FirstOrDefault();
            }
            else
            {
                about = db.Abouts.Find(id);

                if (about == null)
                {
                    about = db.Abouts.FirstOrDefault();
                }
            }
        
            return View(about);
        }

        // POST: Abouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,FirstTopParagraph,SecondTopParagraph,PackagesTitle,PackageOneHeading,PackageOneDetails,PackageTwoHeading,PackageTWoDetails,PackageThreeHeading,PackageThreeDetails")] About about)
        {
            if (ModelState.IsValid)
            {
                db.Entry(about).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(about);
            
        }

     
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    About about = db.Abouts.Find(id);
        //    if (about == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(about);
        //}

       
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    About about = db.Abouts.Find(id);
        //    db.Abouts.Remove(about);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
