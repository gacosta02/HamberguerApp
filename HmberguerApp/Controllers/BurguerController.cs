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
    public class BurguerController : Controller
    {
        private DataContext dbContext = new DataContext();
        private UnitOfWork unitOfWork = new UnitOfWork(new DataContext());

        public BurguerController(DataContext dbContext, UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                var burguers = unitOfWork.Burguer.Get();
                if (burguers != null)
                    return Ok(burguers);
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
        public IActionResult Create([FromBody] Burgers burguer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Burguer.Insert(burguer);
                    unitOfWork.Save();
                    return Created("HamburgerApp/Create", burguer);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(burguer);
        }

        // PUT api/values/5

        [HttpPut]
        public IActionResult UpdateUser([FromBody] Burgers burguer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.Burguer.Update(burguer);
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
