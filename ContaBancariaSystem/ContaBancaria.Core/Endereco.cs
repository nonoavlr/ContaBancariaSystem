﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContaBancaria.Core
{
    public class Endereco
    {
        public int EnderecoID { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public virtual ICollection<Agencia> Agencias { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
