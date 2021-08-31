using System;

namespace TimproTeste.Models
{
    public class ClienteViewModel
    {
        public Guid ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public Models.StatusCliente StatusCliente { get; set; }
    }
}