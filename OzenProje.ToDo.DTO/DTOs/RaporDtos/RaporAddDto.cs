using OzenProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.DTO.DTOs.RaporDtos
{
    public class RaporAddDto
    {
        public string Tanim { get; set; }
        public string Detay { get; set; }
        public Gorev Gorev { get; set; }
        public int GorevId { get; set; }
    }
}
