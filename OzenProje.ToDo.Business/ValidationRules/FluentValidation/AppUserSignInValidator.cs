using FluentValidation;
using OzenProje.ToDo.DTO.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre alanı boş geçilemez");
        }
    }
}
