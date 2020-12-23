using OzenProje.ToDo.DataAccess.Interfaces;
using OzenProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzenProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAciliyetRepository:EfGenericRepository<Aciliyet>,IAciliyetDal
    {
    }
}
