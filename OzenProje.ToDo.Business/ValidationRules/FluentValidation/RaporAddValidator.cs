using FluentValidation;
using OzenProje.ToDo.DTO.DTOs.RaporDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class RaporAddValidator : AbstractValidator<RaporAddDto>
    {
        public RaporAddValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez");
            RuleFor(I => I.Detay).NotNull().WithMessage("Detay alanı boş geçilemez");
        }

    }
}
