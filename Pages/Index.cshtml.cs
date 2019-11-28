using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoRodovias.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.EcoRodoviasContext _context;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, Data.EcoRodoviasContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Chamado> Chamados { get; set; }

        public async Task OnGetAsync()
        {
            var parent = _context.Chamados.ToListAsync();
            parent.Result.ForEach(delegate (Chamado cham)
            {
                cham.Usuario = _context.Usuarios.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.UsuarioCodigo)).Result;
                cham.Usuario.TipoUsuario = _context.TiposUsuario.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.Usuario.TipoUsuarioCodigo)).Result;
                cham.Atendente = _context.Usuarios.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.AtendenteCodigo)).Result;
                cham.Atendente.TipoUsuario = _context.TiposUsuario.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.Atendente.TipoUsuarioCodigo)).Result;
            });
            Chamados = await parent;
        }
    }
}
