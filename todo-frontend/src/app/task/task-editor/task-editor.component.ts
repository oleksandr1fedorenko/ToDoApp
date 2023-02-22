import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-task-editor',
  templateUrl: './task-editor.component.html',
  styleUrls: ['./task-editor.component.css']
})
export class TaskEditorComponent implements OnInit{
  constructor(private route:ActivatedRoute) {
  }
  mode: 'new' | 'edit' = 'new';
  pageTitle = 'Add new task';

  ngOnInit(){
    this.mode = this.route.snapshot.data['mode'];
    this.pageTitle = this.mode === 'new' ? 'Add new task' : 'Edit Task';
  }
}
