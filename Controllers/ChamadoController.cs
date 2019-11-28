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
    public class ChamadoController : ControllerBase
    {
        private readonly Repositorio<Chamado> _context;

        public ChamadoController()
        {
            _context = new Repositorio<Chamado>();
        }

        // GET: api/chamado
        [HttpGet]
        public IEnumerable<Chamado> Get()
        {
            return _context.PesquisarTodos().ToList();
        }

        // GET: api/chamado/1
        [HttpGet("{codigo}")]
        public Chamado Get(int codigo)
        {
            var model = _context.PesquisarPorCodigo(codigo);
            if (model != null)
            {
                return model;
            }
            return new Chamado();
        }


        // POST api/chamado
        /// <summary>
        /// Cria um chamdo
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/chamado
        ///     {
        ///        "nome": "Nome Categoria",
        ///        "descricao": "Descrição Categoria"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [HttpPost]
        public ActionResult<Chamado> Post([FromBody] Chamado postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }

            Chamado model = new Chamado();
            //{
            //    Nome = postModel.GetValue("Nome").Value<string>(),
            //    Descricao = postModel.GetValue("Descricao").Value<string>()
            //};

            //_context.Inserir(model);

            return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        }

    }
}