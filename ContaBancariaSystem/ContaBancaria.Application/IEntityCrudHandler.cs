using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancaria.Application
{
    public interface IEntityCrudHandler<T>
    {
        Task<int> Inserir(T entity);
        Task<int> Alterar(int id, T entity, int clientID);
        Task<int> Remover(int id, int clientID);
        Task<T[]> Listar(int clientID);
        Task<T> ObterUm(int id, int clientID);
    }
}
