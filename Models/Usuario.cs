using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data;

namespace Models
{
    [Table("USUARIO")]
    public class Usuario : Entidade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("ID_USUARIO")]
        public int Codigo {get;set;}

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Column("NM_USUARIO")]
        public string Nome { get; set; }

        [Column("NR_CPF")]
        public Int64 CPF { get; set; }

        [Column("NR_TELEFONE")]
        public string Telefone { get; set; }

        [Column("NM_EMAIL")]
        public string Email { get; set; }

        [Column("NM_SENHA")]
        public string Senha { get; set; }

        public int TipoUsuarioCodigo { get; set; }
        [ForeignKey("TipoUsuarioCodigo")]
        public virtual TipoUsuario TipoUsuario { get; set; }
    }
}