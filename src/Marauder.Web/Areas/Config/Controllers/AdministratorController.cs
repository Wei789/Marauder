using Marauder.BLL.Interface;
using Marauder.BLL.ViewModels;
using Marauder.Help;
using Marauder.Help.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marauder.Web.Areas.Config.Controllers
{
    [AdminAuthorize]
    public class AdministratorController : Controller
    {
        private readonly IAdminstratorService AdminstratorService;

        public AdministratorController(IAdminstratorService AdminstratorService)
        {
            this.AdminstratorService = AdminstratorService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Login(AdministratorManager loginVM)
        {
            if (ModelState.IsValid)
            {
                var admin = this.AdminstratorService.FindAccount(loginVM.Account);
                if (admin == null)
                {
                    ModelState.AddModelError("Account", "帳號不存在");
                }
                else if (Encryption.SHA256(loginVM.Password) != admin.Password)
                {
                    ModelState.AddModelError("Password", "密碼不正確");
                }
                else
                {
                    Session.Add("Account", loginVM.Account);
                    Session.Add("AdminID", admin.AdministratorID);
                    return RedirectToAction("Index", "Administrator");
                }
            }
            return View(loginVM);
        }

        /// <summary>
        /// 添加【分部视图】
        /// </summary>
        /// <returns></returns>
        public PartialViewResult AddPartialView()
        {
            return PartialView();
        }

        /// <summary>
        /// 添加【Json】
        /// </summary>
        /// <param name="addAdmin"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult AddJson(AdministratorManager addAdmin)
        {
            Response res = new Response();
            if (ModelState.IsValid)
            {
                addAdmin.Password = Encryption.SHA256(addAdmin.Password);
                if (this.AdminstratorService.FindAccount(addAdmin.Account) != null)
                {
                    res.Code = 0;
                    res.Message = "帳號已存在";
                }
                else if (this.AdminstratorService.CreateAdmin(addAdmin))
                {
                    res.Code = 1;
                    res.Message = "新增成功";
                }
                else
                {
                    res.Code = 0;
                    res.Message = "新增失敗";
                }
            }
            else
            {
                res.Code = 0;
                res.Message = General.GetModelErrorString(ModelState);
            }
            return Json(res);
        }

        /// <summary>
        /// 删除 
        /// Response.Code:1-成功，2-部分删除，0-失败
        /// Response.Data:刪除數量
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteJson(List<int> ids)
        {
            int total = ids.Count();
            Response res = new Response();
            int currentAdminID = int.Parse(Session["AdminID"].ToString());
            if (ids.Contains(currentAdminID))
            {
                ids.Remove(currentAdminID);
            }

            res = this.AdminstratorService.Delete(ids);

            return Json(res);
        }

        /// <summary>
        /// 重設密碼
        /// </summary>
        /// <param name="id">管理員ID</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ResetPassword(int id)
        {
            string password = "CowCow";
            Response resp = this.AdminstratorService.ChangePassword(id, Encryption.SHA256(password));
            if (resp.Code == 1) resp.Message = "密碼重設為：" + password;
            return Json(resp);
        }

        /// <summary>
        /// 管理員資料
        /// </summary>
        /// <returns></returns>
        public ActionResult MyInfo()
        {
            AdministratorManager admin = this.AdminstratorService.FindAccount(Session["Account"].ToString());
            return View(admin);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult MyInfo(FormCollection form)
        {
            var admin = this.AdminstratorService.FindAccount(Session["Account"].ToString());

            if (admin.Password != form["Password"])
            {
                admin.Password = Encryption.SHA256(form["Password"]);
                var resp = this.AdminstratorService.ChangePassword(admin.AdministratorID, admin.Password);
                if (resp.Code == 1) ViewBag.Message = "<div class=\"alert alert-success\" role=\"alert\"><span class=\"glyphicon glyphicon-ok\"></span>修改密碼成功！</div>";
                else ViewBag.Message = "<div class=\"alert alert-danger\" role=\"alert\"><span class=\"glyphicon glyphicon-remove\"></span>修改密碼失敗ˋ！</div>";
            }
            return View(admin);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public JsonResult ListJson()
        {
            return Json(this.AdminstratorService.FindAll());
        }
    }
}