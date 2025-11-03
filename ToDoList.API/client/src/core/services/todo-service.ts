import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { PaginatedResult, PaginationRequest, ToDoItemDto, ToDoItemTest } from '../../types/todoitem';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = environment.apiUrl;

  getToDoItems(paginationRequest: PaginationRequest, filterDate: string) {
    let params = new HttpParams();
    params = params.set('pageNumber', paginationRequest.pageNumber);
    params = params.set('pageSize', paginationRequest.pageSize);

    if (filterDate !== '') {
      params = params.set('toDoDate', filterDate);
    }

      return this.http.get<PaginatedResult<ToDoItemDto>>(`${this.baseUrl}ToDoItems`, { params });
    }
  getToDoItemById(id: string) {
    return this.http.get<ToDoItemDto>(`${this.baseUrl}ToDoItems/${id}`);
  }
  createToDoItem(toDoItem: ToDoItemDto) {
    return this.http.post<ToDoItemDto>(`${this.baseUrl}ToDoItems`, toDoItem);
  }
  updateToDoItem(id: string, toDoItem: ToDoItemDto) {
    return this.http.put<ToDoItemDto>(`${this.baseUrl}ToDoItems/${id}`, toDoItem);
  }
}
