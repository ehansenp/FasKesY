using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Repository
{
    public interface IRAgama
    {
        Task<List<RAgama>> GetAll();
        Task<RAgama> GetById(int id);
        Task<int> Insert(RAgama obj);
        Task<int> Update(RAgama obj);
        Task<int> Delete(int id);   
    }
}