using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;


namespace EcoRodovias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly EcoRodoviasContext _context;

        public TipoUsuarioController()
        {
            _context = new EcoRodoviasContext();
        }

        // GET: api/tipousuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoUsuario>>> Get()
        {
            return await _context.TiposUsuario.ToListAsync();
        }

        // GET: api/tipousuario/1
        [HttpGet("{codigo}")]
        public async Task<ActionResult<TipoUsuario>> Get(int codigo)
        {
            var model = _context.TiposUsuario.Where(p => p.Codigo.Equals(codigo));
            if (model != null && model.Count() > 0)
            {
                return await model.FirstOrDefaultAsync();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}