using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimproTeste.Models
{
    public class ImovelViewModel
    {
        [Key]
        public Guid ImovelId { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O {0} é obrigatório")]
        public Models.StatusImovel StatusImovel { get; set; }

        public Guid ClienteId { get; set; }
    }
}