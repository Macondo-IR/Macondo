using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Macondo.Data;
using Macondo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MacondoContext _context;
    private readonly IDbConnection _dbConnection;

    public Repository(MacondoContext context, string connectionString)
    {
        _context = context;
        _dbConnection = new SqlConnection(connectionString);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        // استفاده از Dapper برای خواندن داده‌ها
        var sql = $"SELECT * FROM [{typeof(T).Name}s]"; // نوع T را به نام جدول تبدیل می‌کند
        return await _dbConnection.QueryAsync<T>(sql);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        // استفاده از Dapper برای خواندن بر اساس ID
        var sql = $"SELECT * FROM [{typeof(T).Name}s] WHERE Id = @Id"; // فرض بر این است که هر جدول دارای ستونی به نام Id است
        var x = await _dbConnection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
        return x;
    }

    public async Task AddAsync(T entity)
    {
        // استفاده از EF Core برای اضافه کردن
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        // استفاده از EF Core برای به‌روزرسانی
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        // استفاده از EF Core برای حذف
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
