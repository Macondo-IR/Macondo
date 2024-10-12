using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Macondo.Model;
using Macondo.Repositories.Interfaces;

namespace Macondo.Services
{
    public class SampleService
    {
         private readonly IRepository<Sample> _sampleRepository;

    public SampleService(IRepository<Sample> repository)
    {
        _sampleRepository = repository;
    }

    public async Task<IEnumerable<Sample>> GetAllAsync()
    {
        return await _sampleRepository.GetAllAsync();
    }

    public async Task<Sample> GetByIdAsync(int id)
    {
        return await _sampleRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Sample sample)
    {
        await _sampleRepository.AddAsync(sample);
    }

    public async Task UpdateAsync(Sample sample)
    {
        await _sampleRepository.UpdateAsync(sample);
    }

    public async Task DeleteAsync(int id)
    {
        await _sampleRepository.DeleteAsync(id);
    }
    }
}