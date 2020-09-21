using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LogisticManagement.CommonLogic;
using LogisticManagement.Models;

namespace LogisticManagement.Controllers
{
    public class ViewSkillController : Controller
    {
        private dataEntities db = new dataEntities();
        private CommonMethod cm = new CommonMethod();

        // GET: ViewSkill
        public ActionResult Index()
        {
            return View(db.View_Skill.ToList());
        }

        // GET: ViewSkill/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Skill view_Skill = db.View_Skill.Find(id);
            if (view_Skill == null)
            {
                return HttpNotFound();
            }
            return View(view_Skill);
        }

        // GET: ViewSkill/Create
        public ActionResult Create()
        {
            ViewBag.Country = db.tbl_Country.Where(c=> c.CountryStatus == 1)
                                    .OrderBy(c => c.CountryName).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult SubmitNewTrade(string tradeName, int countryId)
        {
            try
            {
                //var userName = Session["Username"].ToString();
                //var userStakeHolderId = db.tbl_201_User.Where(c => c.Username == userName).Select(c => c.StakeHolderUniqueCode).First().ToString();
               
                var count = db.tbl_Skill.Where(c => c.SkillName == tradeName && c.CountryId == countryId).Count();
                if (count > 0)
                {
                    var xResult = new { result = "Duplicate!", errdata = "1", Msg = "Error: " + "This Trade already exists." };
                    return Json(xResult, JsonRequestBehavior.AllowGet);
                }

                var lastSkill = Int32.Parse(db.tbl_Skill.OrderByDescending(c => c.SkillId).Select(c => c.SkillId).First().ToString());
                tbl_Skill tbl_Skill = new tbl_Skill();
                tbl_Skill.SkillId = (lastSkill + 1);
                tbl_Skill.SkillName = tradeName;
                tbl_Skill.SkillOrder = 0;
                tbl_Skill.SkillStatus = 1;
                tbl_Skill.CountryId = countryId;
                db.tbl_Skill.Add(tbl_Skill);

                db.SaveChanges();
                var iResult = new { result = "Success!", Msg = "Trade Added successfully.", errdata = "0" };
                return Json(iResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorMessage = cm.generateCustomErrorMessage(ex.HResult);
                string message = cm.generateErrorMessage(ex);
                var iResult = new { result = errorMessage, errdata = "1", Msg = "Error: " + message };
                return Json(iResult, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: ViewSkill/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Skill tbl_Skill = db.tbl_Skill.Where(c=> c.SkillId == id).FirstOrDefault();
            if (tbl_Skill == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Skill);
        }

        // POST: ViewSkill/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutoId,SkillId,SkillName,SkillOrder,SkillStatus,CountryId,CountryName,CountryShortName,CountryStatus")] View_Skill view_Skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_Skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view_Skill);
        }

        // GET: ViewSkill/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Skill view_Skill = db.View_Skill.Find(id);
            if (view_Skill == null)
            {
                return HttpNotFound();
            }
            return View(view_Skill);
        }

        // POST: ViewSkill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            View_Skill view_Skill = db.View_Skill.Find(id);
            db.View_Skill.Remove(view_Skill);
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
