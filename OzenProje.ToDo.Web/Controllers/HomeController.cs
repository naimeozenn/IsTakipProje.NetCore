using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzenProje.ToDo.Business.Interfaces;
using OzenProje.ToDo.DTO.DTOs.AppUserDtos;
using OzenProje.ToDo.Entities.Concrete;
using OzenProje.ToDo.Web.BaseControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzenProje.ToDo.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
     
        public HomeController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) :base(userManager)
        {
            _signInManager = signInManager;
          
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
             var user= await _userManager.FindByNameAsync(model.UserName);
                if (user !=null)
                {
                  var identityResult= await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                      var roller=await _userManager.GetRolesAsync(user);
                        if (roller.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }
                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            }
            return View("Index",model);
        }
        public IActionResult KayıtOl()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KayıtOl(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.SurName
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var addRolResult = await _userManager.AddToRoleAsync(user, "Member");
                    if (addRolResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    HataEkle(result.Errors);
                }
                HataEkle(result.Errors);
            }
            return View(model);
        }
        public async Task<IActionResult> CikisYap()
        {
           await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult StatusCode(int? code)
        {
            if (code == 404)
            {
                ViewBag.Code = code;
                ViewBag.Message = "Sayfa bulunamadı";
            }

            return View();
        }
     
    }
}
