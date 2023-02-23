import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/internal/Observable";
import { Task } from "../app/models/task";

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) {
  }

  addTask(task: Task): Observable<Task> {
    return this.http.post<Task>('https://localhost:5001/api/Task/', task)
  }

  getAllTasks(): Observable<Task[]> {
    return this.http.get<Task[]>('https://localhost:5001/api/Task')
  }

  removeTask(task: Task) {
    return this.http.delete<boolean>('https://localhost:5001/api/Task/' + task.id, {responseType: "json"})
  }
}
