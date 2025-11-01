using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ToDoList.API.Helpers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
}
