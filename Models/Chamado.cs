using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data;

namespace Models
{
    [Table("CHAMADO")]
    public class Chamado : Entidade
    {
        [Display(Name = "Codigo")]
        [Key]
        [Column("NR_CHAMADO")]
        public long Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição é obrigatória")]
        [Column("DES_CHAMADO")]
        public string Nome { get; set; }

        [Display(Name = "Risco")]
        [Required(ErrorMessage = "Risco é obrigatório")]
        [Column("DES_RISCO")]
        public string Risco { get; set; }

        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Placa é obrigatória")]
        [Column("NR_PLACA")]
        public string Placa { get; set; }

        [Display(Name = "Localização")]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        [Column("END_LOCALIZACAO")]
        public string Endereco { get; set; }

        [Display(Name = "Veículo")]
        [Required(ErrorMessage = "Veículo é obrigatório")]
        [Column("DESC_VEICULO")]
        public string Veiculo { get; set; }

        [Required]
        [Column("ID_USUARIO")]
        [ForeignKey("ID_USUARIO")]
        public long UsuarioCodigo { get; set; }

        public virtual Usuario Usuario { get; set; }

        [Column("ID_ATENDENTE")]
        [ForeignKey("ID_ATENDENTE")]
        public long AtendenteCodigo { get; set; }

        public virtual Usuario Atendente { get; set; }

    }
}
