using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimproTeste.Entidade
{
    public class Enum
    {
        public enum StatusCliente
        {
            Inativo = 0,
            Ativo = 1
        }
        public enum StatusImovel
        {
            Inativo = 0,
            Ativo = 1
        }
        public enum TipoDeImovel
        {
            Aluguel = 0,
            Venda = 1
        }
    }
}