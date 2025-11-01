using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Interfaces;


public interface IAppDbContext
{
    DbSet<ToDoItem> ToDoItems { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
