using Application.Abstractions;
using Domain.Todos;
using MediatR;

namespace Application.Todos.Queries.GetTodos;

public sealed class GetTodosQueryHandler(ITodoRepository todoRepository) : IRequestHandler<GetTodosQuery, List<Todo>>
{
    private readonly ITodoRepository _todoRepository = todoRepository;
    public async Task<List<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return await _todoRepository.GetAllAsync(cancellationToken);
    }
}