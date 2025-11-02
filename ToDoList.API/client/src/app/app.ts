import { Component } from '@angular/core';
import { TodoList } from "../features/todo-list/todo-list";

@Component({
  selector: 'app-root',
  imports: [TodoList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = 'ToDO List';
}
