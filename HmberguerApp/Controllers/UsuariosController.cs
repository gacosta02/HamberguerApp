using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HmberguerApp.Data;
using HmberguerApp.Entities;
using HmberguerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HmberguerApp.Controllers
{
    [Route("api/v1/HamburgerApp/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private DataContext dbContext = new DataContext();
        private UnitOfWork unitOfWork = new UnitOfWork(new DataContext());
        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                var usuarios = unitOfWork.Usuarios.Get();
                if (usuarios != null)
                    return Ok(usuarios);
                else
                    return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetUserDetails(int Id)
        {
            Usuarios usuario = unitOfWork.Usuarios.GetByID(Id);
            if (usuario != null)
                return Ok(usuario);
            else
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody] Usuarios usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Usuarios.Insert(usuario);
                    unitOfWork.Save();
                    return Created("HamburgerApp/Create", usuario);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(usuario);
        }

        // PUT api/values/5

        [HttpPut]
        public IActionResult UpdateUser([FromBody] Usuarios usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Usuarios.Update(usuario);
                    unitOfWork.Save();
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpDelete]
        public IActionResult DeleteUser([FromHeader] int Id)
        {

            if (Id != 0)
            {
                unitOfWork.Usuarios.Delete(Id);
                unitOfWork.Save();
                return Ok("Usuario Eliminado");
            }
            else
            {
                return NoContent();
            }
        }
    }

}
