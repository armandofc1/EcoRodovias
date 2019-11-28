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
            return await _context.Usuarios.Include(usuario => usuario.TipoUsuario).ToListAsync();
        }

        //// GET: api/usuario/1
        //[HttpGet("{codigo}")]
        //public async Task<ActionResult<Usuario>> Get(int codigo)
        //{


        //    // return await _context.Usuarios.Include(tip => tip.TipoUsuario).ToListAsync().Result.FirstOrDefault(usu => usu.Codigo.Equals(codigo));

        //    var model = _context.Usuarios.Include(usu => usu.TipoUsuario).Where(usu => usu.Codigo.Equals(codigo));
        //    if (model != null && model.Count() > 0)
        //    {
        //        return await model.FirstAsync();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        // GET: api/usuario/1
        [HttpGet("{codigo}")]
        public ActionResult<Usuario> Get(int codigo)
        {
            var parent = _context.Usuarios
            .Where(p => p.Codigo.Equals(codigo))
            .FirstOrDefault();
            _context.Entry(parent).Reference(p => p.TipoUsuario).Load();

            return parent;
        }


        //// POST api/usuario
        ///// <summary>
        ///// Cria uma usuario
        ///// </summary>
        ///// <remarks>
        ///// Exemplo:
        /////
        /////     POST api/usuario
        /////     {
        /////        "nome": "Nome Categoria",
        /////        "descricao": "Descrição Categoria"
        /////     }
        /////
        ///// </remarks>
        ///// <param name="value"></param>
        ///// <returns>Um novo item criado</returns>
        ///// <response code="201">Retorna o novo item criado</response>
        ///// <response code="400">Se o item não for criado</response> 
        //[HttpPost]
        //public ActionResult<Usuario> Post([FromBody] Usuario postModel)
        //{
        //    if (postModel == null)
        //    {
        //        return BadRequest();
        //    }

        //    Usuario model = new Usuario();
        //    //{
        //    //    Nome = postModel.GetValue("Nome").Value<string>(),
        //    //    Descricao = postModel.GetValue("Descricao").Value<string>()
        //    //};

        //    //_context.Inserir(model);

        //    return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        //}

    }
}