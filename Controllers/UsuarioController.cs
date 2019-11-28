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
    public class UsuarioController : ControllerBase
    {
        private readonly EcoRodoviasContext _context;

        public UsuarioController()
        {
            _context = new EcoRodoviasContext();
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var parent = _context.Usuarios.ToListAsync();
            parent.Result.ForEach(delegate (Usuario cham)
            {
                cham.TipoUsuario = _context.TiposUsuario.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.TipoUsuarioCodigo)).Result;
            });
            return await parent;
        }

        // GET: api/usuario/1
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Usuario>> Get(int codigo)
        {
            var model = _context.Usuarios.Where(usu => usu.Codigo.Equals(codigo));
            if (model != null && model.Count() > 0)
            {
                var retorno = model.FirstAsync();
                await _context.Entry(retorno.Result).Reference(p => p.TipoUsuario).LoadAsync();
                return await retorno;
            }
            else
            {
                return BadRequest();
            }
        }

    }
}