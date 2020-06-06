using ContaBancaria.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Application
{
    public class BancoHandler : IEntityCrudHandler<Banco>
    {
        private readonly IApplicationDbContext db;
        public BancoHandler(IApplicationDbContext db) => this.db = db;
        public Task<int> Alterar(int id, Banco entity, int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Inserir(Banco entity)
        {
            throw new NotImplementedException();
        }

        public Task<Banco[]> Listar(int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<Banco> ObterUm(int id, int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Remover(int id, int clientID)
        {
            throw new NotImplementedException();
        }
    }
}
