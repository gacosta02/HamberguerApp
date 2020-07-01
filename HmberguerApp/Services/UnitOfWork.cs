using HmberguerApp.Data;
using HmberguerApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HmberguerApp.Services
{
    public class UnitOfWork: IUnitOfWork
    {
        private DataContext _dbContext;
        private BaseRepository<Usuarios> _usuario;
        private BaseRepository<Burgers> _contacto;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Usuarios> Usuarios
        {
            get
            {
                return _usuario ??
               (_usuario = new BaseRepository<Usuarios>(_dbContext));
            }
        }

        public IRepository<Burgers> Contactos
        {
            get
            {
                return _contacto ??
               (_contacto = new BaseRepository<Burgers>(_dbContext));

            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
 
