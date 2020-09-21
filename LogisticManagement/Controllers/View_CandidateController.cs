using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LogisticManagement.Models;

namespace LogisticManagement.Controllers
{
    public class View_CandidateController : Controller
    {
        private dataEntities db = new dataEntities();

        // GET: View_Candidate
        public ActionResult Index()
        {
            return View(db.View_Candidate.ToList());
        }

        // GET: View_Candidate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Candidate view_Candidate = db.View_Candidate.Find(id);
            if (view_Candidate == null)
            {
                return HttpNotFound();
            }
            return View(view_Candidate);
        }

        // GET: View_Candidate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: View_Candidate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutoId,CandidateId,CandidateCode,CandidateName,CandidateContactNo,CandidateAddress,CandidateDOB,CandidateGender,CandidateGuardianName,CandidateGurdianContact,CandidateImageRef,JobTrade,JobDuration,JobCompany,SkillId,SkillName,DocumentId,DocumentKey,DocumentExpiryDate,DocumentImageRef,DocumentOrgImageRef,DocumentName,CountryId,CountryName,CountryShortName,JobCountryName,JobCountryShortName")] View_Candidate view_Candidate)
        {
            if (ModelState.IsValid)
            {
                db.View_Candidate.Add(view_Candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view_Candidate);
        }

        // GET: View_Candidate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Candidate view_Candidate = db.View_Candidate.Find(id);
            if (view_Candidate == null)
            {
                return HttpNotFound();
            }
            return View(view_Candidate);
        }

        // POST: View_Candidate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutoId,CandidateId,CandidateCode,CandidateName,CandidateContactNo,CandidateAddress,CandidateDOB,CandidateGender,CandidateGuardianName,CandidateGurdianContact,CandidateImageRef,JobTrade,JobDuration,JobCompany,SkillId,SkillName,DocumentId,DocumentKey,DocumentExpiryDate,DocumentImageRef,DocumentOrgImageRef,DocumentName,CountryId,CountryName,CountryShortName,JobCountryName,JobCountryShortName")] View_Candidate view_Candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_Candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view_Candidate);
        }

        // GET: View_Candidate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Candidate view_Candidate = db.View_Candidate.Find(id);
            if (view_Candidate == null)
            {
                return HttpNotFound();
            }
            return View(view_Candidate);
        }

        // POST: View_Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            View_Candidate view_Candidate = db.View_Candidate.Find(id);
            db.View_Candidate.Remove(view_Candidate);
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
