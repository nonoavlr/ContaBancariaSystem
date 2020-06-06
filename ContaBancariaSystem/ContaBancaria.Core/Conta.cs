using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Core
{
    public class Conta
    {
        public int ContaID { get; set; }
        public int CodContaCorrente { get; set; }
        public int Saldo { get; set; }
        public int Depositos { get; set; }
        public int Saques { get; set; }
        public int AgenciaID { get; set; }
        public virtual Agencia Agencia { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

    }
}
