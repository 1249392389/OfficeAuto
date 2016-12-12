using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.GlobalUtilities.ValidateCode;
using Saas.Office.Auto.IService;
using Saas.Office.Auto.Service;

namespace Saas.Office.Auto.Web.Areas.AdminLogin.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISysUserService _sysuserservice;
        public LoginController(ISysUserService sysuserservice)
        {
            this._sysuserservice = sysuserservice;
        }
        // GET: AdminLogin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLoginViewModel model)
        {
            bool rememberState = model.RememberState;
            //ISysUserService _sysuserservice = new SysUserService();
            bool isLogin = _sysuserservice.Login(model, rememberState);
            var aa = Session["ValidateCode"].ToString();
            if (model.ValidateCode != Session["ValidateCode"].ToString())
            {
                return Content("<script>alert('验证码输入有误')</script>");
            }
            if (!isLogin)
            {
                return Content("<script>alert('登录失败')</script>");
            }
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
        public virtual ActionResult VerifyImage()
        {
            var validateCodeType = new ValidateCode_Style10();
            string code = "6666";
            byte[] bytes = validateCodeType.CreateImage(out code);
            //this.CookieContext.VerifyCodeGuid = VerifyCodeHelper.SaveVerifyCode(code);
            Session["ValidateCode"] = code;
            return File(bytes, @"image/jpeg");
        }
    }
}