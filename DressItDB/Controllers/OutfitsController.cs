﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DressItDB.Models;

namespace DressItDB.Controllers
{
    public class OutfitsController : Controller
    {
        private DressItDBEntities db = new DressItDBEntities();

        // GET: Outfits
        public ActionResult Index()
        {
            var outfits = db.Outfits.Include(o => o.Top).Include(o => o.Bottom).Include(o => o.Shoes).Include(o => o.Accessories);
            return View(outfits.ToList());
        }

        // GET: Outfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // GET: Outfits/Create
        public ActionResult Create()
        {
            var tops = from item in db.WardrobeItems
                        where item.TypeID == 1
                        select item;
            ViewBag.TopID = new SelectList(tops, "WardrobeItemID", "Name");
            var bottoms = from item in db.WardrobeItems
                        where item.TypeID == 2
                        select item;
            ViewBag.BottomID = new SelectList(bottoms, "WardrobeItemID", "Name");
            var shoes  = from item in db.WardrobeItems
                        where item.TypeID == 3
                        select item;
            ViewBag.ShoeID = new SelectList(shoes, "WardrobeItemID", "Name");
            var accessories = from item in db.WardrobeItems
                              where item.TypeID == 4
                              select item;
            ViewBag.AccessoryIDs = new MultiSelectList(accessories, "WardrobeItemID", "Name");
            return View();
        }

        // POST: Outfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitID,TopID,BottomID,ShoeID")] Outfit outfit, int[] AccessoryIDs)
        {
            if (ModelState.IsValid)
            {
                if (AccessoryIDs != null)
                {
  foreach (int accessoryID in AccessoryIDs)
                    {
                    outfit.Accessories.Add(db.WardrobeItems.Find(accessoryID));
                    }
                }
               
                db.Outfits.Add(outfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TopID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.TopID);
            ViewBag.BottomID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.ShoeID);
            return View(outfit);
        }

        // GET: Outfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.TopID);
            ViewBag.BottomID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.ShoeID);
            return View(outfit);
        }

        // POST: Outfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitID,TopID,BottomID,ShoeID")] Outfit outfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.TopID);
            ViewBag.BottomID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.BottomID);
            ViewBag.ShoeID = new SelectList(db.WardrobeItems, "WardrobeItemID", "Name", outfit.ShoeID);
            return View(outfit);
        }

        // GET: Outfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Outfit outfit = db.Outfits.Find(id);
            if (outfit == null)
            {
                return HttpNotFound();
            }
            return View(outfit);
        }

        // POST: Outfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Outfit outfit = db.Outfits.Find(id);
            outfit.Accessories.Clear();
            db.Outfits.Remove(outfit);
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
