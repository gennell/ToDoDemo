export type ToDoItemDto = {
    id: string;
    title: string;
    description: string;
    toDoDate: string;
    status: ToDoStatus;
    assignedEmail: string;
}

export type PaginatedResult<T> = {
    items: T[];
    totalItems: number;
    pageNumber: number;
    pageSize: number;
    totalPages: number;
}

export type PaginationRequest = {
    pageNumber: number;
    pageSize: number;
    toDoDate?: string;
}

export enum ToDoStatus {
    NotStarted = 0,
    InProgress = 1,
    Completed = 2,
    Canceled = 3,
}

export type ToDoItemTest = {
    id: string;
    title: string;
    description: string;
    toDoDate: string;
    status: ToDoStatus;
    assignedEmail: string;
}