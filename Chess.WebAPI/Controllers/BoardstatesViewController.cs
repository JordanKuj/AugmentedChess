using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chess.WebAPI.Models;

namespace Chess.WebAPI.Controllers
{
    public class BoardstatesViewController : Controller
    {
        private ChessWebAPIContext db = new ChessWebAPIContext();

        // GET: BoardstatesView
        public ActionResult Index()
        {
            var boardstates = db.Games.Include(x => x.States).Where(x => x.EndTime == null).ToList().Last().States;
            return View(boardstates.ToList());
        }

        // GET: BoardstatesView/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boardstates boardstates = db.Boardstates.Find(id);
            if (boardstates == null)
            {
                return HttpNotFound();
            }
            return View(boardstates);
        }

        // GET: BoardstatesView/Create
        public ActionResult Create()
        {
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId");
            return View();
        }

        // POST: BoardstatesView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,Timestamp,State,GameId,Turn")] Boardstates boardstates)
        {
            if (ModelState.IsValid)
            {
                db.Boardstates.Add(boardstates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", boardstates.GameId);
            return View(boardstates);
        }

        // GET: BoardstatesView/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boardstates boardstates = db.Boardstates.Find(id);
            if (boardstates == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", boardstates.GameId);
            return View(boardstates);
        }

        // POST: BoardstatesView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,Timestamp,State,GameId,Turn")] Boardstates boardstates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boardstates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameId = new SelectList(db.Games, "GameId", "GameId", boardstates.GameId);
            return View(boardstates);
        }

        // GET: BoardstatesView/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boardstates boardstates = db.Boardstates.Find(id);
            if (boardstates == null)
            {
                return HttpNotFound();
            }
            return View(boardstates);
        }

        // POST: BoardstatesView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boardstates boardstates = db.Boardstates.Find(id);
            db.Boardstates.Remove(boardstates);
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
