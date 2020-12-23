using OzenProje.ToDo.DTO.DTOs.GorevDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.DTO.DTOs.AppUserDtos
{
    public class PersonelGorevlendirListDto
    {
        public AppUserListDto AppUser { get; set; }
        public GorevListDto Gorev { get; set; }
    }
}
