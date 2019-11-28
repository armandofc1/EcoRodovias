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
    public class ChamadoController : ControllerBase
    {
        private readonly EcoRodoviasContext _context;
        public ChamadoController()
        {
            _context = new EcoRodoviasContext();
        }

        // GET: api/chamado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chamado>>> Get()
        {
            var parent = _context.Chamados.ToListAsync();
            parent.Result.ForEach(delegate (Chamado cham)
            {
                cham.Usuario = _context.Usuarios.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.UsuarioCodigo)).Result;
                cham.Usuario.TipoUsuario = _context.TiposUsuario.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.Usuario.TipoUsuarioCodigo)).Result;
                cham.Atendente = _context.Usuarios.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.AtendenteCodigo)).Result;
                cham.Atendente.TipoUsuario = _context.TiposUsuario.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.Atendente.TipoUsuarioCodigo)).Result;
            });
            return await parent;
        }

        // GET: api/chamado/1
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Chamado>>  Get(int codigo)
        {
            var model = _context.Chamados.Where(p => p.Codigo.Equals(codigo));
            if (model != null && model.Count() > 0)
            {
                var parent = model.FirstOrDefaultAsync();

                _context.Entry(parent.Result).Reference(p => p.Usuario).LoadAsync();
                _context.Entry(parent.Result.Usuario).Reference(p => p.TipoUsuario).LoadAsync();

                _context.Entry(parent.Result).Reference(p => p.Atendente).LoadAsync();
                _context.Entry(parent.Result.Atendente).Reference(p => p.TipoUsuario).LoadAsync();

                return await parent;
            }
            else
            {
                return BadRequest();
            }
        }


        //// POST api/chamado
        ///// <summary>
        ///// Cria um chamdo
        ///// </summary>
        ///// <remarks>
        ///// Exemplo:
        /////
        /////     POST api/chamado
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
        //public ActionResult<Chamado> Post([FromBody] Chamado postModel)
        //{
        //    if (postModel == null)
        //    {
        //        return BadRequest();
        //    }

        //    Chamado model = new Chamado();
        //    //{
        //    //    Nome = postModel.GetValue("Nome").Value<string>(),
        //    //    Descricao = postModel.GetValue("Descricao").Value<string>()
        //    //};

        //    //_context.Inserir(model);

        //    return CreatedAtAction(nameof(Get), new { codigo = model.Codigo }, model);
        //}

    }
}