using FluentValidation;
using OzenProje.ToDo.DTO.DTOs.RaporDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class RaporUpdateValidator : AbstractValidator<RaporUpdateDto>
    {
        public RaporUpdateValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez");
            RuleFor(I => I.Detay).NotNull().WithMessage("Detay alanı boş geçilemez");
        }
    }
}
