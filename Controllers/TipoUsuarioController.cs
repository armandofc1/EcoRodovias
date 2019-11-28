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
    public class TipoUsuarioController : ControllerBase
    {
        private readonly Repositorio<TipoUsuario> _context;

        public TipoUsuarioController()
        {
            _context = new Repositorio<TipoUsuario>();
        }

        // GET: api/tipousuario
        [HttpGet]
        public IEnumerable<TipoUsuario> Get()
        {
            return _context.PesquisarTodos().ToList();
        }

        // GET: api/tipousuario/1
        [HttpGet("{codigo}")]
        public TipoUsuario Get(int codigo)
        {
            var model = _context.PesquisarPorCodigo(codigo);
            if (model != null)
            {
                return model;
            }
            return new TipoUsuario();
        }


        // POST api/tipousuario
        /// <summary>
        /// Cria um tipo de usuario
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/tipousuario
        ///     {
        ///        "codigo": 1,
        ///        "Nome": "nome do tipo"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        public ActionResult<TipoUsuario> Post([FromBody] TipoUsuario postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }

            TipoUsuario model = new TipoUsuario();
            //{
            //    Nome = postModel.GetValue("Nome").Value<string>(),
            //    Descricao = postModel.GetValue("Descricao").Value<string>()
            //};

            //_context.Inserir(model);

            return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        }

    }
}