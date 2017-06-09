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
            if (model.UserName==null)
            {
                Response.Write("<script>alert('用户名不能为空！')</script>");
                return View();
            }
            if (model.Password == null)
            {
                Response.Write("<script>alert('密码不能为空！')</script>");
                return View();
            }
            Session["CurrentUser"] = model;
            bool rememberState = model.RememberState;
            bool isLogin = _sysuserservice.Login(model, rememberState);
            var ValidateCode = Session["ValidateCode"].ToString();
            if (!isLogin)
            {
                Response.Write("<script>alert('用户名或密码输入错误！')</script>");
                return View();
            }
            if (model.ValidateCode != Session["ValidateCode"].ToString())
            {
                Response.Write("<script>alert('验证码输入有误')</script>");
                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegisterViewModel model)
        {

            return View();
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