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
            //Repositorio<TipoUsuario> _contextTipo = new Repositorio<TipoUsuario>();

            //var tipo = new TipoUsuario();
            //tipo.Codigo = 1; // Guid.NewGuid();
            //tipo.Tipo = "admin";

            //_contextTipo.Inserir(tipo);

            //var usuario = new Usuario();
            //usuario.Codigo = 5;  //Guid.NewGuid();
            //usuario.Nome = "Teste";
            //usuario.Senha = "senha";
            //usuario.Email = "email@email.com";
            //usuario.Telefone = "11 2323-5454";
            //usuario.CPF = 3133670858;
            //usuario.TipoUsuarioCodigo = 1;

            //_context.Inserir(usuario);

            return _context.PesquisarTodos().ToList();
        }

        // GET: api/usuario/1
        [HttpGet("{codigo}")]
        public Usuario Get(int codigo)
        {
            var model = _context.PesquisarPorCodigo(codigo);
            if (model != null)
            {
                return model;
            }
            return new Usuario();
        }


        // POST api/usuario
        /// <summary>
        /// Cria uma usuario
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/usuario
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
        public ActionResult<Usuario> Post([FromBody] Usuario postModel)
        {
            if (postModel == null)
            {
                return BadRequest();
            }

            Usuario model = new Usuario();
            //{
            //    Nome = postModel.GetValue("Nome").Value<string>(),
            //    Descricao = postModel.GetValue("Descricao").Value<string>()
            //};

            //_context.Inserir(model);

            return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        }

    }
}