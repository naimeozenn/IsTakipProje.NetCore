﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.DTO.DTOs.GorevDtos
{
    public class GorevUpdateDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public int AciliyetId { get; set; }
    }
}
