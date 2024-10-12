using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Macondo.Model;
using Macondo.Repositories.Interfaces;

namespace Macondo.Services
{
    public class ListService
    {
         private readonly IRepository<List> _listRepository;

    public ListService(IRepository<List> listRepository)
    {
        _listRepository = listRepository;
    }

    public async Task<IEnumerable<List>> GetAllListsAsync()
    {
        return await _listRepository.GetAllAsync();
    }

    public async Task<List> GetListByIdAsync(int id)
    {
        return await _listRepository.GetByIdAsync(id);
    }

    public async Task AddListAsync(List list)
    {
        await _listRepository.AddAsync(list);
    }

    public async Task UpdateListAsync(List list)
    {
        await _listRepository.UpdateAsync(list);
    }

    public async Task DeleteListAsync(int id)
    {
        await _listRepository.DeleteAsync(id);
    }
    }
}