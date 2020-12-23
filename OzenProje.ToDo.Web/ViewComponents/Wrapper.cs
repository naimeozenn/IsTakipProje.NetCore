using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OzenProje.ToDo.Business.Interfaces;
using OzenProje.ToDo.DTO.DTOs.AppUserDtos;
using OzenProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzenProje.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, IBildirimService bildirimService, IMapper mapper)
        {
            _bildirimService = bildirimService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var identityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDto>(identityUser);


            var bildirimler = _bildirimService.GetirOkunmayanlar(model.Id).Count;

            ViewBag.BildirimSayisi = bildirimler;
            var roles = _userManager.GetRolesAsync(identityUser).Result;

            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);

        }

    }
}
