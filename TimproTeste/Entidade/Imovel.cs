using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TimproTeste.Entidade
{
    [Table("Imovel")]
    public partial class Imovel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imovel()
        {
            Clientes = new HashSet<Clientes>();
        }

        public Guid ImovelId { get; set; }

        [Display(Name = "Tipo De Negocio")]
        public Enum.TipoDeImovel TipoDeNegocio { get; set; }

        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [StringLength(250)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public Enum.StatusImovel StatusImovel { get; set; }

        public Guid? ClienteId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clientes> Clientes { get; set; }

        public virtual Clientes Clientes1 { get; set; }
    }
}
