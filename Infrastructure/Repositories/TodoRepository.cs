using Domain.Repositories;
using Domain.Todos;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class TodoRepository(AppDbContext context) : ITodoRepository
{
    private readonly AppDbContext _context = context;
    private async Task<bool> SaveChangesAsync()
    => await _context.SaveChangesAsync() > 0;
    public async Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Todos.FindAsync([id], cancellationToken);
    }

    public async Task<List<Todo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Todos.ToListAsync(cancellationToken);
    }

    public async Task Add(Todo todo)
    {
        _context.Todos.Add(todo);
        await SaveChangesAsync();
    }

    public async Task Update(Todo todo)
    {
        _context.Todos.Update(todo);
        await SaveChangesAsync();
    }

    public async Task Remove(Todo todo)
    {
        _context.Todos.Remove(todo);
        await SaveChangesAsync();
    }

}
