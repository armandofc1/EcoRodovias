using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using Models;

namespace EcoRodovias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/usuario
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        //{
        //    Repositorio<Usuario> repo = new Repositorio<Usuario>();
        //    return await repo.PesquisarTodos1();
        //}

        // GET: api/usuario
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            Repositorio<Usuario> repo = new Repositorio<Usuario>();
            return repo.PesquisarTodos().ToList();
        }
    }
}