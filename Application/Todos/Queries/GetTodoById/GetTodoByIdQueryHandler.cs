using Application.Abstractions;
using Domain.Todos;
using MediatR;

namespace Application.Todos.Queries.GetTodoById;

public sealed class GetTodoByIdQueryHandler(ITodoRepository todoRepository) : IRequestHandler<GetTodoByIdQuery, Todo?>
{
    private readonly ITodoRepository _todoRepository = todoRepository;
    public async Task<Todo?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _todoRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}