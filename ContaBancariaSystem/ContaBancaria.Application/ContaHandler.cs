using ContaBancaria.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Application
{
    public class ContaHandler : IEntityCrudHandler<Conta>
    {
        private readonly IApplicationDbContext db;
        public ContaHandler(IApplicationDbContext db) => this.db = db;

        public Task<int> Alterar(int id, Conta entity, int clientID)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Inserir(Conta entity)
        {
            db.Contas.Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<Conta[]> Listar(int clientID)
        {
            return await db.Contas.Where(c => c.ClientID == clientID).ToArrayAsync();
        }

        public async Task<Conta> ObterUm(int id, int clientID)
        {
            return await db.Contas.SingleOrDefaultAsync(c => c.ClientID == clientID && c.ContaID == id);
        }

        public async Task<int> Remover(int id, int clientID)
        {
            var contaRemove = await db.Contas.SingleOrDefaultAsync(c => c.ContaID == id);

            if(contaRemove != null && contaRemove.ClientID == clientID && contaRemove.Saldo == 0)
            {
                db.Contas.Remove(contaRemove);
                return await db.SaveChangesAsync();
            }

            if(contaRemove.Saldo != 0)
            {
                return await Task.FromResult(1);
            }

            return await Task.FromResult(0);
        }

        public async Task<int> Depositar(Conta entity, int id, int clientID)
        {
            var contaDeposito = await db.Contas.SingleOrDefaultAsync(c => c.ClientID == clientID && c.ContaID == id);
            contaDeposito.Saldo = contaDeposito.Saldo + entity.Depositos;
            return await  db.SaveChangesAsync();
        }

        public async Task<int> Sacar(Conta entity, int id, int clientID)
        {
            var contaDeposito = await db.Contas.SingleOrDefaultAsync(c => c.ClientID == clientID && c.ContaID == id);
            contaDeposito.Saldo = contaDeposito.Saldo - entity.Saques;
            return await db.SaveChangesAsync();
        }

    }
}
