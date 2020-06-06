using ContaBancaria.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Application
{
    public class ClientHandler
    {
        private readonly IApplicationDbContext db;
        public ClientHandler(IApplicationDbContext db) => this.db = db;
        public async Task<Client> GetUserByApiCredentials(string apiKey, string apiSecret)
        {
            return await db.Clients.SingleOrDefaultAsync(u => u.ApiKey == apiKey && u.ApiSecret == apiSecret);
        }
    }
}
