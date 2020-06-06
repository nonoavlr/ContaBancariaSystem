using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Core
{
    public class Banco
    {
        public int BancoID { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public virtual ICollection<Agencia> Agencias { get; set; }
    }
}
