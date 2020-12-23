using FluentValidation;
using OzenProje.ToDo.DTO.DTOs.AciliyetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AciliyetUpdateValidator : AbstractValidator<AciliyetUpdateDto>
    {
        public AciliyetUpdateValidator()
        {
            RuleFor(I => I.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
