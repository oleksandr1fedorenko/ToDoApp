import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {TaskComponent} from "./task/task.component";
import {LoginComponent} from "./login/login.component";
import {TaskEditorComponent} from "./task/task-editor/task-editor.component";
import {RegisterComponent} from "./register/register.component";
import {ServicesGuard} from "../services/service-guard.guard";

const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: "full"},
  {path: 'home', component: HomeComponent, pathMatch: 'full'},
  {path: 'tasks', component: TaskComponent,canActivate: [ServicesGuard]},
  {path: 'login', component: LoginComponent},
  {
    path: 'tasks', children: [
      {path: 'edit/:id', component: TaskEditorComponent, data: {mode: 'edit'}, canActivate: [ServicesGuard]}
    ],
  },
  {path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
