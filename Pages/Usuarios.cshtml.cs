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
    public class UsuariosModel : PageModel
    {
        private readonly Data.EcoRodoviasContext _context;

        private readonly ILogger<UsuariosModel> _logger;

        public UsuariosModel(ILogger<UsuariosModel> logger, Data.EcoRodoviasContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Usuario> Usuarios { get; set; }

        public async Task OnGetAsync()
        {
            var parent = _context.Usuarios.ToListAsync();
            parent.Result.ForEach(delegate (Usuario cham)
            {
                cham.TipoUsuario = _context.TiposUsuario.FirstOrDefaultAsync(u => u.Codigo.Equals(cham.TipoUsuarioCodigo)).Result;
            });
            Usuarios = await parent;
        }
    }
}
