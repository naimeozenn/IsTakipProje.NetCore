using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzenProje.ToDo.Business.Interfaces;
using OzenProje.ToDo.Entities.Concrete;
using OzenProje.ToDo.Web.BaseControllers;
using OzenProje.ToDo.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzenProje.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles =RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
        private readonly IBildirimService _bildirimService;
        private readonly IRaporService _raporService;
      
        public HomeController(IGorevService gorevService, IBildirimService bildirimService, UserManager<AppUser> userManager, IRaporService raporService) :base(userManager)
        {
            _raporService = raporService;
            _bildirimService = bildirimService;
            _gorevService = gorevService;
       
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Anasayfa;
            var user = await GetirGirisYapanKullanici();
          
            ViewBag.AtanmayiBekleyenGorevSayisi = _gorevService.GetirGorevSayisiAtanmayiBekleyen();

            ViewBag.TamamlanmisGorevSayisi = _gorevService.GetirGorevTamamlanmis();

            ViewBag.OkunmamisBildirimSayisi = _bildirimService.GetirOkunmayanSayisiileAppUserId(user.Id);

            ViewBag.ToplamRaporSayisi = _raporService.GetirRaporSayisi();
            return View();
            
        }
    }
}
