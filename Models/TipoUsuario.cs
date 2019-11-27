using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data;

namespace Models
{
    [Table("TIPO_USUARIO")]
    public class TipoUsuario : Entidade
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [Column("TP_USUARIO")]
        public long Codigo { get; set; }

        [Required(ErrorMessage = "Tipo é obrigatório")]
        [Column("NM_TIPO")]
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
