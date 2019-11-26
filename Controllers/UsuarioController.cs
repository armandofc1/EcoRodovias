using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data;
using Models;

namespace EcoRodovias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly Repositorio<Usuario> _context;

        public UsuarioController()
        {
            _context = new Repositorio<Usuario>();
        }

        // GET: api/usuario
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _context.PesquisarTodos().ToList();
        }
    }
}