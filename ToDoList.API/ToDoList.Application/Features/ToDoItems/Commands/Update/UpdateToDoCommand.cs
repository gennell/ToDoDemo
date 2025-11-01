namespace ToDoList.Application.Features.ToDoItems.Commands.Update;

public record UpdateToDoCommand(Guid Id, ToDoItemDto ToDoItem) : IRequest<ToDoItemDto>;

public class UpdateToDoCommandValidator : AbstractValidator<UpdateToDoCommand>
{
    public UpdateToDoCommandValidator()
    {
        RuleFor(x => x.ToDoItem.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.ToDoItem.Description).NotEmpty().MaximumLength(3000);
        RuleFor(x => x.ToDoItem.ToDoDate).NotEmpty();
        RuleFor(x => x.ToDoItem.Status).NotEmpty();
        RuleFor(x => x.ToDoItem.AssignedEmail).NotEmpty().EmailAddress();
    }
}