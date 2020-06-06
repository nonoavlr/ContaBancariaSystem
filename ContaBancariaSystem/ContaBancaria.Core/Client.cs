using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Core
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public int CPF { get; set; }
        public virtual ICollection<Conta> Contas { get; set; }
        public int EnderecoID { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }
}
