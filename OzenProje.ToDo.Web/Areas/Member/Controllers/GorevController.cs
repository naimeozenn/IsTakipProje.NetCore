﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzenProje.ToDo.Business.Interfaces;
using OzenProje.ToDo.DTO.DTOs.GorevDtos;
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
    public class GorevController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
        private readonly IMapper _mapper;
        public GorevController(IGorevService gorevService, UserManager<AppUser> userManager, IMapper mapper):base(userManager)
        {
            _gorevService = gorevService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int aktifSayfa=1)
        {
            TempData["Active"] = TempdataInfo.Gorev;
            var user = await GetirGirisYapanKullanici();


            var gorevler = _mapper.Map<List<GorevListAllDto>>(_gorevService.GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, user.Id, aktifSayfa));

            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.AktifSayfa = aktifSayfa;

            return View(gorevler);
        }
    }
}
