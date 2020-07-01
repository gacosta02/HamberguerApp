using HmberguerApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HmberguerApp.Services
{
   public interface IUnitOfWork
    {
        IRepository<Usuarios> Usuarios { get; }
        IRepository<Burgers> Burguer { get; }
        void Save();
    }
}
