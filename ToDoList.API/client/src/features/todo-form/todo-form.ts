import { Component, inject, Input, OnInit, output, signal } from '@angular/core';
import { TodoService } from '../../core/services/todo-service';
import { ToDoItemDto, ToDoStatus } from '../../types/todoitem';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-todo-form',
  imports: [ReactiveFormsModule],
  templateUrl: './todo-form.html',
  styleUrl: './todo-form.css',
})
export class TodoForm implements OnInit {
  private readonly todoService = inject(TodoService);
  private readonly fb = inject(FormBuilder);
  
  @Input() toDoItem: ToDoItemDto | null = null;
  close = output();
  
  toDoItemForm!: FormGroup;
  isSubmitting = signal(false);
  
  toDoItemStatuses = [
    { value: ToDoStatus.NotStarted, label: 'Nie rozpoczęte' },
    { value: ToDoStatus.InProgress, label: 'W trakcie' },
    { value: ToDoStatus.Completed, label: 'Wykonane' },
    { value: ToDoStatus.Canceled, label: 'Anulowane' }
  ];

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    const dueDate = this.toDoItem?.toDoDate 
      ? this.toDoItem.toDoDate.split('T')[0] 
      : '';
    this.toDoItemForm = this.fb.group({
      title: [this.toDoItem?.title || '', [Validators.required, Validators.maxLength(200)]],
      description: [this.toDoItem?.description || '', Validators.maxLength(2000)],
      toDoDate: [dueDate, Validators.required],
      status: [this.toDoItem?.status ?? ToDoStatus.NotStarted, Validators.required],
      assignedEmail: [this.toDoItem?.assignedEmail || '', [Validators.required, Validators.email]]
    });
  }

  onSubmit() {
    if (this.toDoItemForm.valid && !this.isSubmitting()) {
      this.isSubmitting.set(true);
      
      const formValue = this.toDoItemForm.value;
      const toDoDateISO = formValue.toDoDate;
      
      if (this.toDoItem) {
        // Update existing task
        const updateRequest: ToDoItemDto = {
          id: this.toDoItem.id,
          title: formValue.title,
          description: formValue.description,
          toDoDate: toDoDateISO,
          status: formValue.status,
          assignedEmail: formValue.assignedEmail
        };
        
        this.todoService.updateToDoItem(this.toDoItem.id, updateRequest).subscribe({
          next: () => {
            this.isSubmitting.set(false);
            this.close.emit();
          },
          error: (error) => {
            console.error('Error updating task:', error);
            this.isSubmitting.set(false);
          }
        });
      } else {
        // Create new task
        const createRequest: ToDoItemDto = {
          id: '',
          title: formValue.title,
          description: formValue.description,
          toDoDate: toDoDateISO,
          status: formValue.status,
          assignedEmail: formValue.assignedEmail
        };
        
        this.todoService.createToDoItem(createRequest).subscribe({
          next: () => {
            this.isSubmitting.set(false);
            this.close.emit();
          },
          error: (error) => {
            console.error('Error creating task:', error);
            this.isSubmitting.set(false);
          }
        });
      }
    }
  }

  onCancel() {
    this.close.emit();
  }

  getMinDate() {
    const today = new Date();
    return today.toISOString().split('T')[0];
  }

  get isEditMode(): boolean {
    return this.toDoItem !== null;
  }
}
