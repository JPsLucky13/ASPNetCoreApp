using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProjectApp.Models;
using CourseProjectApp.Services;
using CourseProjectApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseProjectApp.Controllers
{
    public class MainController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSend _emailSend;
        private readonly ISmsSend _smsSend;

        public MainController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSend emailSend, ISmsSend smsSend)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSend = emailSend;
            _smsSend = smsSend;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResults = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (loginResults.Succeeded)
                {
                    return RedirectToAction("Index", "LoggedIn");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login Information.");
                return View(model);
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var identityUser = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Username
                };

                var identityResults = await _userManager.CreateAsync(identityUser, model.Password);

                if (identityResults.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    var callbackUrl = Url.Action("ConfirmEmail", "Main", new { userId = identityUser.Id, code = code }, protocol: HttpContext.Request.Scheme);

                    await _emailSend.SendEmailAsync(model.Username, "Confirm Account", $"Please confirm your account by clicking this link:<a href='{callbackUrl}'>Link</a>");

                    await _signInManager.SignInAsync(identityUser, isPersistent: false);
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error in Creating my User. Password requires upper case letter, a non alpha numeric character and a digit.");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user,code);
            return View("ConfirmEmail");

        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    return RedirectToAction("Index", "Main");
                }
                var result = await _userManager.ResetPasswordAsync(user,model.Code,model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "LoggedIn");
                }
            }
            return View(model);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return View("ForgotPasswordConfirmation");
                }
                //Send Email Confirmation

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Main", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

                await _emailSend.SendEmailAsync(model.Email, "Reset Password", $"Please Reset your password by clicking this link:<a href='{callbackUrl}'>Link</a>");
            }

            return View(model);
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Main");
        }

        [HttpGet]
        public async Task<IActionResult> SmsTest()
        {
            await _smsSend.SendSmsAsync("14695027582","This is a test message");
            return RedirectToAction("Index", "Main");
        }

        public async Task<IActionResult> TestEmail()
        {
            await _emailSend.SendEmailAsync("jeanpaulpeschard43@gmail.com","Test Email","My first send grid email!");
            return View();
        }

        public IActionResult Authenticate()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "LoggedIn");
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
        }
    }
}