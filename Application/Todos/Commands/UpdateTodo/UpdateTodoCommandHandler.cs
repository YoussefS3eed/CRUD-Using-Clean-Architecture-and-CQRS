using Application.Abstractions;
using Application.Common.Exceptions;
using Domain.Todos;
using MediatR;

namespace Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandHandler(ITodoRepository todoRepository) : IRequestHandler<UpdateTodoCommand>
{
    private readonly ITodoRepository _todoRepository = todoRepository;
    public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetByIdAsync(request.Id, cancellationToken);
        if (todo == null)
            throw new NotFoundException(nameof(Todo), request.Id);

        todo.Title = request.Title;
        todo.Completed = request.Completed;
        await _todoRepository.Update(todo);
    }
}
