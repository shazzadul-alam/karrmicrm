using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogisticManagement.CommonLogic;
using LogisticManagement.Models;

namespace LogisticManagement.Controllers
{
    public class HomeController : Controller
    {
        private dataEntities db = new dataEntities();
        private CommonMethod cm = new CommonMethod();


        public ActionResult GetUserCategory(string x)
        {
            try
            {
                var userName = Session["Username"].ToString();
                var userStakeHolderId = db.tbl_201_User.Where(c => c.Username == userName).Select(c => c.StakeHolderUniqueCode).First().ToString();
                var userCategoryId = Int32.Parse(db.tbl_Stakeholder.Where(c=> c.StakeHolderUniqueCode == userStakeHolderId).Select(c => c.StakeHolderTypeId).First().ToString());
                
                var stakeHolderInfo = db.tbl_Stakeholder.Where(c => c.StakeHolderUniqueCode == userStakeHolderId).FirstOrDefault();

                var loggedUsername = stakeHolderInfo.FirstName + " " + stakeHolderInfo.LastName;

                var iResult = new { userCategoryId = userCategoryId, loggedUsername = loggedUsername, errdata = "0" };
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


        public ActionResult Login()
        {
            try
            {
                if(Session["Username"] != null)
                {
                    var userName = Session["Username"].ToString();
                    var userStakeHolderId = db.tbl_201_User.Where(c => c.Username == userName).Select(c => c.StakeHolderUniqueCode).First().ToString();
                    var stakeHolderInfo = db.tbl_Stakeholder.Where(c => c.StakeHolderUniqueCode == userStakeHolderId).FirstOrDefault();

                    TempData["UserFullName"] = stakeHolderInfo.FirstName + " " + stakeHolderInfo.LastName;

                    return RedirectToAction("Index", "View_Candidate");
                    //if (stakeHolderInfo.StakeHolderTypeId == 3 || stakeHolderInfo.StakeHolderTypeId == 4)
                    //{
                    //    return RedirectToAction("Dashboard", "Dashboard");
                    //}
                    //else if (stakeHolderInfo.StakeHolderTypeId == 2)
                    //{
                    //    return RedirectToAction("CreateOrder", "OrderManage");
                    //}
                    //else if (stakeHolderInfo.StakeHolderTypeId == 1)
                    //{
                    //    return RedirectToAction("CustomerHistory", "ConsumerAccess");
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var userInfoCount = db.tbl_201_User
                                 .Where(ui =>
                                    ui.Username.Equals(username) &&
                                    ui.Password.Equals(password)
                                 )
                                 .Count();

            if (userInfoCount > 0)
            {
                Session["Username"] = username;
                var userInfo = db.tbl_201_User
                                 .Where(ui =>
                                    ui.Username.Equals(username) &&
                                    ui.Password.Equals(password)
                                 )
                                 .FirstOrDefault();


                var userStakeHolderId = db.tbl_201_User.Where(c => c.Username == username).Select(c => c.StakeHolderUniqueCode).First().ToString();
                var stakeHolderInfo = db.tbl_Stakeholder.Where(c => c.StakeHolderUniqueCode == userStakeHolderId).FirstOrDefault();
                TempData["UserFullName"] = stakeHolderInfo.FirstName + " " + stakeHolderInfo.LastName;

                return RedirectToAction("Index", "View_Candidate");

                //if (stakeHolderInfo.StakeHolderTypeId == 3 || stakeHolderInfo.StakeHolderTypeId == 4)
                //{   
                //    return RedirectToAction("Dashboard", "Dashboard");
                //}
                //else if (stakeHolderInfo.StakeHolderTypeId == 2)
                //{
                //    return RedirectToAction("CreateOrder", "OrderManage");
                //}
                //else if (stakeHolderInfo.StakeHolderTypeId == 1)
                //{
                //    return RedirectToAction("CustomerHistory", "ConsumerAccess");
                //}
                //else
                //{
                //    return RedirectToAction("Index", "Home");
                //}
               
                //try
                //{
                //    Session["Role"] = userInfo.UserRoleId;
                //    if (userInfo.UserRoleId == 1)
                //    {
                //        return RedirectToAction("Index", "StakeHolder");
                //    }
                //    else
                //    {
                //        return RedirectToAction("Create", "StakeHolder");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    ViewBag.userNameError = ex.InnerException;
                //    return View();
                //}
            }
            else
            {
                ViewBag.userNameError = "Incorrect UserName or Password!";
                return View();
            }

        }



        public ActionResult Logout(string id)
        {
            Session.Clear();
            Session.Abandon();
            //Session.RemoveAll();
            return RedirectToAction("Login");
        }



        public ActionResult Dashboard()
        {
            try
            {
                var userName = Session["Username"].ToString();
                var userStakeHolderId = db.tbl_201_User.Where(c => c.Username == userName).Select(c => c.StakeHolderUniqueCode).First().ToString();
                var stakeHolderInfo = db.tbl_Stakeholder.Where(c => c.StakeHolderUniqueCode == userStakeHolderId).FirstOrDefault();

                ViewBag.FullName = stakeHolderInfo.FirstName + " " + stakeHolderInfo.LastName;

                if (stakeHolderInfo.StakeHolderTypeId == 3 || stakeHolderInfo.StakeHolderTypeId == 4)
                {
                    return View();
                }
                else if (stakeHolderInfo.StakeHolderTypeId == 2)
                {
                    return RedirectToAction("CreateOrder", "OrderManage");
                }
                else if (stakeHolderInfo.StakeHolderTypeId == 1)
                {
                    return RedirectToAction("CustomerHistory", "ConsumerAccess");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            
            }
            catch
            {
                return RedirectToAction("Login", "Home");
            }
        }

    
        public ActionResult Index()
        {
            try
            {
                var userName = Session["Username"].ToString();
                var userStakeHolderId = db.tbl_201_User.Where(c => c.Username == userName).Select(c => c.StakeHolderUniqueCode).First().ToString();
                var stakeHolderInfo = db.tbl_Stakeholder.Where(c => c.StakeHolderUniqueCode == userStakeHolderId).FirstOrDefault();

                ViewBag.FullName = stakeHolderInfo.FirstName + " " + stakeHolderInfo.LastName;

                if (stakeHolderInfo.StakeHolderTypeId == 3 || stakeHolderInfo.StakeHolderTypeId == 4)
                {
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}