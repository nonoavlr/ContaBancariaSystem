using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Core
{
    public class Agencia
    {
        public int AgenciaID { get; set; }
        public int EnderecoID { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Conta> Contas { get; set; }
        public int BancoID { get; set; }
        public virtual Banco Banco { get; set; }
    }
}
