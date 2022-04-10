using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quest4.Models;
using Quest4.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Quest4.Components;
using Quest4.Data;
using Microsoft.EntityFrameworkCore;
using Quest4.Components.Statuses;

namespace Quest4.Controllers
{
    public class AccountController : Controller
    {
        private readonly Ouest4DBContetx _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManger;

        private CheckStatus CheckStatus;

        const int pageSize = 4;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager, Ouest4DBContetx contetx)
        {
            _userManager = userManager;
            _signinManger = signInManager;
            _context = contetx;
            CheckStatus = new CheckStatus(contetx, userManager);
        }

        //Rgister ======================================================
        [HttpGet]
        public IActionResult Register()
        {    
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User {LastLog=DateTime.Now, Email = model.Email, UserName = model.Email,RegisterDate =DateTime.Now };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Pass);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signinManger.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        //Login ===========================================================

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {   
                var result =
                    await _signinManger.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user =await _userManager.FindByNameAsync(model.Email);
                    var status = await _context.Statuses.FirstOrDefaultAsync(o => o.Title == "Baned");

                    if (user.StatusId == status.Id)
                    {
                        await _signinManger.SignOutAsync();
                        return RedirectToAction(nameof(BanedMessage));
                    }

                    user.LastLog = DateTime.Now;
                    await _userManager.UpdateAsync(user);

                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Users", "Account");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }


        // Users List ===================================================================
        [Authorize]
        public  IActionResult Users(int? id)
        {
            int page = id ?? 0;
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
            {
                return PartialView("_WriteMoreUsers", GetItemsPage (page));
            }
            return View(GetItemsPage(page));
        }
        [Authorize]
        public PartialViewResult _WriteMoreUsers()
        {
            return PartialView();
        }
        [Authorize]
        private List<User> GetItemsPage(int page = 1)
        {
            var itemsToSkip = page * pageSize;

            return _userManager.Users.OrderBy(t => t.Id).Skip(itemsToSkip).
                Take(pageSize).ToList();
        }
        // logout ====================================================================
        public async Task<IActionResult> Logout()
        {
            await _signinManger.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        // Block ====================================================================
        [Authorize]
        public async Task<IActionResult> Block(IEnumerable<string> test) 
        {

            var baned = await _context.Statuses.FirstOrDefaultAsync(o=>o.Title== "Baned");
            foreach (var item in test)
            {
                 var user = await _userManager.FindByEmailAsync(item);

                user.StatusId = baned.Id;
                user.IsBaned = true;

                await _userManager.UpdateAsync(user);
            }
            if(await CheckStatus.IsStatusAsync(User.Identity.Name, "Baned")) await _signinManger.SignOutAsync();
            return RedirectToAction(nameof(Users));
        }
        // unblock ==================================================================
        [Authorize]
        public async Task<IActionResult> UnBlock(IEnumerable<string> test)
        {
            var UnBaned = await _context.Statuses.FirstOrDefaultAsync(o=>o.Title== "Ofline");
            foreach (var item in test)
            {
                var user = await _userManager.FindByEmailAsync(item);
                user.StatusId = UnBaned.Id;
                user.IsBaned = false;
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction(nameof(Users)); 
        }
        // delete ==================================================================
        [Authorize]
        public async Task<IActionResult> Delete(IEnumerable<string> test)
        {
            foreach (var item in test)
            {
                var user = await _userManager.FindByEmailAsync(item);
                await _userManager.DeleteAsync(user);
            }
            if (await CheckStatus.IsStatusAsync(User.Identity.Name, "Baned")) await _signinManger.SignOutAsync();
            return RedirectToAction(nameof(Users));
        }

        public IActionResult BanedMessage()
        {
            return View();
        }

        public async Task CheckUserStatus()
        {
            if (await CheckStatus.IsStatusAsync(User.Identity.Name, "Baned")) await _signinManger.SignOutAsync();
            else
            {
                if (User.Identity.Name != null)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (user.IsBaned==false)
                    {
                        user.LastLog = DateTime.Now;
                        await _userManager.UpdateAsync(user);
                    }
                }
            }
        }

    }
}
