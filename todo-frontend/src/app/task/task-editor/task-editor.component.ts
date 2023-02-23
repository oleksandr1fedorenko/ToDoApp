import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import {Task} from "../../models/task";
import {TaskService} from "../../../services/task.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-task-editor',
  templateUrl: './task-editor.component.html',
  styleUrls: ['./task-editor.component.css']
})
export class TaskEditorComponent implements OnInit {
  constructor(private route: ActivatedRoute, private taskService: TaskService, private router: Router) {
  }

  tasks: Task[] = [];
  mode: 'new' | 'edit' = 'new';
  pageTitle = 'Add new task';
  taskId: number | null = null;
  titleControl = new FormControl('', {nonNullable: true, validators: [Validators.required, Validators.minLength(3)]});
  descriptionControl = new FormControl('', {
    nonNullable: true,
    validators: [Validators.maxLength(50)],
    updateOn: 'change'
  });
  priorityControl = new FormControl('', {nonNullable: true, validators: [Validators.required]});


  ngOnInit() {
    this.mode = this.route.snapshot.data['mode'];
    this.pageTitle = this.mode === 'new' ? 'Add new task' : 'Edit Task';
    if (this.mode == 'edit') {
      this.taskId = this.route.snapshot.params['id']
      this.taskService.getTask(this.taskId!).subscribe((task) => {
        this.titleControl.setValue(task.title)
        this.descriptionControl.setValue(task.description)
        this.priorityControl.setValue(task.priority)
      })
    }
  }

  updateTask(task: Task) {


  }

  save() {
    const payload = this.getFormValue();
    this.taskService.updateTask(this.taskId!,payload).subscribe(() => {
      this.router.navigateByUrl(`/tasks`);

    })
  }

  getFormValue() {
    return {
      title: this.titleControl.value,
      description: this.descriptionControl.value,
      priority: this.priorityControl.value,
    }
  }
}

