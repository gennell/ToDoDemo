import { Component, inject, OnInit, signal } from '@angular/core';
import { TodoService } from '../../core/services/todo-service';
import { PaginatedResult, PaginationRequest, ToDoItemDto, ToDoStatus } from '../../types/todoitem';
import { DatePipe } from '@angular/common';
import { TodoForm } from "../todo-form/todo-form";

@Component({
  selector: 'app-todo-list',
  imports: [DatePipe, TodoForm],
  templateUrl: './todo-list.html',
  styleUrl: './todo-list.css',
})
export class TodoList implements OnInit {
private readonly todoService = inject(TodoService);
private toDoItemsParams = signal<PaginationRequest>({ pageNumber: 0, pageSize: 10 });
protected paginatedToDoItems = signal<PaginatedResult<ToDoItemDto> | null>(null);

selectedToDoItem = signal<ToDoItemDto | null>(null);
showToDoItemForm = signal(false);

filterDate = signal<string>('');
totalCount = signal(0);
totalPages = signal(0);
pageNumber = signal(0);

onFilterDateChange(date: string) {
  this.filterDate.set(date);
  this.pageNumber.set(1);
  this.loadToDoItems();
}

clearFilter() {
  this.filterDate.set('');
  this.pageNumber.set(1);
  this.loadToDoItems();
}

onPageChange(page: number) {
  this.pageNumber.set(page);
  this.toDoItemsParams.set({ ...this.toDoItemsParams(), pageNumber: page });
  this.loadToDoItems();
}

loadToDoItems() {
  this.todoService.getToDoItems(this.toDoItemsParams(), this.filterDate()).subscribe({
    next: (result) => {
      this.paginatedToDoItems.set(result);
      this.totalCount.set(result.totalItems);
      this.totalPages.set(result.totalPages);
    },
    error: (error) => {
      console.error(error);
    },
    complete: () => {
      console.log('complete');
    }
  });
}

openToDoItemForm() {
  this.selectedToDoItem.set(null);
  this.showToDoItemForm.set(true);
}

editToDoItem(toDoItem: ToDoItemDto) {
  console.log(toDoItem.toDoDate);
  this.selectedToDoItem.set(toDoItem);
  this.showToDoItemForm.set(true);
}

closeToDoItemForm() {
  this.showToDoItemForm.set(false);
  this.selectedToDoItem.set(null);
  this.loadToDoItems();
}

ngOnInit() {
  this.loadToDoItems();
}

getStatusLabel(status: ToDoStatus): string {
  switch (status) {
    case ToDoStatus.NotStarted: return 'Nie rozpoczęte';
    case ToDoStatus.InProgress: return 'W trakcie';
    case ToDoStatus.Completed: return 'Wykonane';
    case ToDoStatus.Canceled: return 'Anulowane';
    default: return 'Nieznany';
  }
}

}
