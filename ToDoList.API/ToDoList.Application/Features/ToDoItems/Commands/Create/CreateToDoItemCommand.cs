namespace ToDoList.Application.Features.ToDoItems.Commands.Create;

public record CreateToDoItemCommand(CreateToDoItemDto ToDoItem) : IRequest<ToDoItemDto>;

public class CreateToDoItemCommandValidator : AbstractValidator<CreateToDoItemCommand>
{
    public CreateToDoItemCommandValidator()
    {
        RuleFor(x => x.ToDoItem.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.ToDoItem.Description).MaximumLength(3000);
        RuleFor(x => x.ToDoItem.ToDoDate).NotEmpty();
        RuleFor(x => x.ToDoItem.Status).NotEmpty();
        RuleFor(x => x.ToDoItem.AssignedEmail).NotEmpty().EmailAddress();
    }
}