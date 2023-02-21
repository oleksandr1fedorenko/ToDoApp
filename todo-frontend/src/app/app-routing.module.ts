import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {TaskComponent} from "./task/task.component";
import {LoginComponent} from "./login/login.component";
import {TaskEditorComponent} from "./task/task-editor/task-editor.component";

const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: "full"},
  {path:'home', component: HomeComponent, pathMatch: 'full'},
  {path:'tasks',component:TaskComponent},
  {path:'login',component:LoginComponent},
  {path:'tasks',children:[
      {path:'new',component:TaskEditorComponent,data:{mode:'new'}},
      {path:'edit',component:TaskEditorComponent,data:{mode:'edit'}}
    ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
