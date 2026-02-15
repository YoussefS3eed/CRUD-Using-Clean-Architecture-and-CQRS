using Application.Abstractions;
using Domain.Todos;
using MediatR;

namespace Application.Todos.Commands.CreateTodo;

public sealed class CreateTodoCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<CreateTodoCommand, Guid>
{
    private readonly ITodoRepository _todoRepository = todoRepository;
    public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo
        {
            Id = Guid.NewGuid(),
            Title = request.Title
        };

        await _todoRepository.Add(todo);

        return todo.Id;
    }
}