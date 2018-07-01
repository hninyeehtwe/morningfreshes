using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MondayAlert.Models;
using System.Web.Security;
using System.Data;

namespace MondayAlert.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                //MondayAlert.Class.Alarm clsAlarm = new Class.Alarm();
                //ViewBag.Question = clsAlarm.GetSupriseQuestion();

            }

            return View();
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

        public ActionResult Login()
        {
            if (!Request.IsAuthenticated)
            {
                LoginViewModel model = new LoginViewModel();
                model.HasError = false;
                model.Message = "";

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            MondayAlert.Class.Authentication clsAuthen = new Class.Authentication();
            bool result = clsAuthen.LoginUser(model);

            if (result == true)
            {
                Response.SetCookie(new System.Web.HttpCookie("Email", model.Email));
                FormsAuthentication.SetAuthCookie(model.Email, false);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                model = new LoginViewModel();
                model.HasError = true;
                model.Message = "Incorrect Username & Password!";
                return View(model);
            }
        }

        public JsonResult MyAlarmsOnHit(/*DateTime alarmDate, int mintes, */int resultStatus, int supriseID/*, int userID*/)
        {
            Class.Alarm clsAlarm = new Class.Alarm();
            DataTable coupon = clsAlarm.GetGiftCouponByPriority();

            if (Convert.ToInt16(coupon.Rows[0]["CouponID"].ToString()) != 0)
            {
                int result = clsAlarm.MyAlarmsOnHit(DateTime.Now, 5, resultStatus, supriseID, Convert.ToInt16(coupon.Rows[0]["CouponID"].ToString()), 1);

                if (result == 1)
                {
                    string[] arr = new string[] { coupon.Rows[0]["CouponCode"].ToString(), coupon.Rows[0]["Description"].ToString(), coupon.Rows[0]["CouponImagePath"].ToString() };
                    return Json(arr, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public void Beep()
        {

            Console.Beep(5000, 5000);
            Beep();

        }
    }
}