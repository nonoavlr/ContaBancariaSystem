using ContaBancaria.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Application
{
    public class AgenciaHandler : IEntityCrudHandler<Agencia>
    {
        private readonly IApplicationDbContext db;
        public AgenciaHandler(IApplicationDbContext db) => this.db = db;

        public Task<int> Alterar(int id, Agencia entity, int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Inserir(Agencia entity)
        {
            throw new NotImplementedException();
        }

        public Task<Agencia[]> Listar(int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<Agencia> ObterUm(int id, int clientID)
        {
            throw new NotImplementedException();
        }

        public Task<int> Remover(int id, int clientID)
        {
            throw new NotImplementedException();
        }
    }
}
