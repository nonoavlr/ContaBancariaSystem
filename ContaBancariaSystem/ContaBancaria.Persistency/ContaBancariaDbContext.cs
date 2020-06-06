using ContaBancaria.Application;
using ContaBancaria.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContaBancaria.Persistency
{
    public class ContaBancariaDbContext : DbContext, IApplicationDbContext
    {
        public ContaBancariaDbContext(DbContextOptions<ContaBancariaDbContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => c.ClientID);
            modelBuilder.Entity<Client>().Property(c => c.ClientID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Banco>().HasKey(c => c.BancoID);
            modelBuilder.Entity<Banco>().Property(c => c.BancoID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Agencia>().HasKey(c => c.AgenciaID);
            modelBuilder.Entity<Agencia>().Property(c => c.AgenciaID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Conta>().HasKey(c => c.ContaID);
            modelBuilder.Entity<Conta>().Property(c => c.ContaID).ValueGeneratedOnAdd();


            modelBuilder.Entity<Endereco>().HasKey(c => c.EnderecoID);
            modelBuilder.Entity<Endereco>().Property(c => c.EnderecoID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Banco>()
                .HasMany(b => b.Agencias)
                .WithOne(b => b.Banco)
                .HasForeignKey(b => b.BancoID);

            modelBuilder.Entity<Agencia>()
                .HasMany(a => a.Contas)
                .WithOne(a => a.Agencia)
                .HasForeignKey(a => a.AgenciaID);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Contas)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientID);

            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Agencias)
                .WithOne(e => e.Endereco)
                .HasForeignKey(e => e.AgenciaID);

            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Clients)
                .WithOne(e => e.Endereco)
                .HasForeignKey(e => e.ClientID);

            modelBuilder.Entity<Client>().HasData(new Client[] {
                new Client(){ ClientID = 1, Name = "Thais", CPF = 123, EnderecoID = 1, ApiKey = Guid.NewGuid().ToString(), ApiSecret = Guid.NewGuid().ToString()},
                new Client(){ ClientID = 2, Name = "Nohan", CPF = 159, EnderecoID = 2, ApiKey = Guid.NewGuid().ToString(), ApiSecret = Guid.NewGuid().ToString()}
            });

            modelBuilder.Entity<Banco>().HasData(new Banco[] {
                new Banco(){ BancoID = 1, Name = "Bradesco", CNPJ = "60.746.948/0001-12"},
                new Banco(){ BancoID = 2, Name = "Itaú", CNPJ = "60.701.190/0001"}
            });

            modelBuilder.Entity<Agencia>().HasData(new Agencia[] {
                new Agencia(){ AgenciaID = 1, BancoID = 1, EnderecoID = 3},
                new Agencia(){ AgenciaID = 2, BancoID = 2, EnderecoID = 4}
            });

            modelBuilder.Entity<Endereco>().HasData(new Endereco[] {
                new Endereco(){ EnderecoID = 1,  Logradouro = "Rua Amelia", Numero = 126, Bairro = "Sao Joao", Cidade = "Belo Horizonte", Estado = "Minas Gerais", Pais = "Brasil"},
                new Endereco(){ EnderecoID = 2,  Logradouro = "Rua Hogwarts", Numero = 12598, Bairro = "Cuba", Cidade = "São Paulo", Estado = "São Paulo", Pais = "Brasil"},
                new Endereco(){ EnderecoID = 3,  Logradouro = "Rua Henrique", Numero = 10, Bairro = "Tucuruvi", Cidade = "São Paulo", Estado = "São Paulo", Pais = "Brasil"},
                new Endereco(){ EnderecoID = 4,  Logradouro = "Rua Anastacia", Numero = 12598, Bairro = "Sao Joao", Cidade = "Belo Horizonte", Estado = "Minas Gerais", Pais = "Brasil"},
            });

            modelBuilder.Entity<Conta>().HasData(new Conta[] {
                new Conta(){ ContaID = 1, ClientID = 1, AgenciaID = 2},
                new Conta(){ ContaID = 2, ClientID = 2, AgenciaID = 1,}
            });

        }
    }
}
