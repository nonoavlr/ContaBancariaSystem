using ContaBancaria.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContaBancaria.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Banco> Bancos { get; set; }
        DbSet<Agencia> Agencias { get; set; }
        DbSet<Conta> Contas { get; set; }
        DbSet<Endereco> Enderecos { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
