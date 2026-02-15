using Application.Abstractions;
using Application.Common.Exceptions;
using Domain.Todos;
using MediatR;

namespace Application.Todos.Commands.DeleteTodo;

public sealed class DeleteTodoCommandHandler(ITodoRepository todoRepository) : IRequestHandler<DeleteTodoCommand>
{
    private readonly ITodoRepository _todoRepository = todoRepository;
    public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetByIdAsync(request.Id, cancellationToken);

        if (todo is null)
            throw new NotFoundException(nameof(Todo), request.Id);

        await _todoRepository.Remove(todo);
    }
}