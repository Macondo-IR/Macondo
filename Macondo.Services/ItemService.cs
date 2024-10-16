﻿using Macondo.Model;
using Macondo.Repositories.Interfaces;

namespace Macondo.Services;

public class ItemService
{
private readonly IRepository<Item> _itemRepository;

    public ItemService(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync()
    {
        return await _itemRepository.GetAllAsync();
    }

    public async Task<Item> GetItemByIdAsync(int id)
    {
        return await _itemRepository.GetByIdAsync(id);
    }

    public async Task AddItemAsync(Item item)
    {
        await _itemRepository.AddAsync(item);
    }

    public async Task UpdateItemAsync(Item item)
    {
        await _itemRepository.UpdateAsync(item);
    }

    public async Task DeleteItemAsync(int id)
    {
        await _itemRepository.DeleteAsync(id);
    }
}
