import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Task} from '../models/task';
import {TaskService} from "../../services/task.service";


@Component({
  selector: 'app-task',
  styleUrls: ['./task.component.css'],
  templateUrl: './task.component.html',

})
export class TaskComponent implements OnInit {
  obj = {} as Task
  tasks: Task[] = [];
taskPr='';

  constructor(private router: Router, private route: ActivatedRoute, private taskService: TaskService) {
  }

  addNewTask(task: Task) {

    this.taskService.addTask(task).subscribe((res: any) => {
      console.log(res)
      this.getAllTasks()
    })
  }

  getAllTasks() {
    this.taskService.getAllTasks().subscribe((res: Task[]) => {
      this.tasks = res;
      console.log(this.tasks)
    })
  }

  removeTask(task: Task) {
    console.log(task)
    this.taskService.removeTask(task).subscribe(() => {
      this.getAllTasks()
    })
  }

  ngOnInit() {

    this.obj = {} as Task
    this.getAllTasks()

  }


}
