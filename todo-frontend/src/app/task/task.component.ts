import { Component } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent {
  constructor(private router: Router, private route: ActivatedRoute) {
  }

  addNewTask() {
    this.router.navigate(['new'], {relativeTo: this.route});
  }
}
