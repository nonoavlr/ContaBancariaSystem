using ContaBancaria.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Application
{
    public class EnderecoHandler : IEntityCrudHandler<Endereco>
    {
        private readonly IApplicationDbContext db;
        public EnderecoHandler(IApplicationDbContext db) => this.db = db;
        public Task<int> Alterar(int id, Endereco entity, int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Inserir(Endereco entity)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco[]> Listar(int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> ObterUm(int id, int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Remover(int id, int clientID)
        {
            throw new NotImplementedException();
        }
    }
}
