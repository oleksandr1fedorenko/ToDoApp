import { Component } from '@angular/core';
import {CommonModule} from "@angular/common";
import {CoreModule} from "../../core/core.module";

@Component({
  selector: 'app-home',
  standalone:true,
  imports:[CommonModule,CoreModule],
  template: '<app-content></app-content>',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

}
