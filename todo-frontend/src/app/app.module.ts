import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CoreModule} from "../core/core.module";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import { HomeComponent } from './home/home.component';
import { TaskComponent } from './task/task.component';
import { LoginComponent } from './login/login.component';
import { TaskEditorComponent } from './task/task-editor/task-editor.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {TaskService} from "../services/task.service";
import { MessageComponent } from './message/message.component';
import { RegisterComponent } from './register/register.component';


@NgModule({
  declarations: [
    AppComponent,
    TaskComponent,
    LoginComponent,
    TaskEditorComponent,
    MessageComponent,
    RegisterComponent,


  ],
    imports: [
        HomeComponent,
        CoreModule,
        HttpClientModule,
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,

    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
