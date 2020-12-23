using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzenProje.ToDo.Business.Interfaces;
using OzenProje.ToDo.DTO.DTOs.BildirimDtos;
using OzenProje.ToDo.Entities.Concrete;
using OzenProje.ToDo.Web.BaseControllers;
using OzenProje.ToDo.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzenProje.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(AreaInfo.Member)]
    public class BildirimController : BaseIdentityController
    {
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
       public BildirimController(IBildirimService bildirimService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _bildirimService = bildirimService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Bildirim;
            var user = await GetirGirisYapanKullanici();
            return View(_mapper.Map<List<BildirimListDto>>(_bildirimService.GetirOkunmayanlar(user.Id)));
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var guncellencekBildirim = _bildirimService.GetirIdile(id);
            guncellencekBildirim.Durum = true;
            _bildirimService.Guncelle(guncellencekBildirim);
            return RedirectToAction("Index");
        }
    }
}