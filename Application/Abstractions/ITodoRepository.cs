using Domain.Todos;

namespace Application.Abstractions;

public interface ITodoRepository
{
    Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Todo>> GetAllAsync(CancellationToken cancellationToken = default);
    Task Add(Todo todo);
    Task Update(Todo todo);
    Task Remove(Todo todo);
}
