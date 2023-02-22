import {Component} from '@angular/core';
import {LoginService} from "../../services/login.service";
import {User} from "../models/User";



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
user=new User();

login(user:User){
  this.auth.login(user).subscribe((token:string)=>{
    localStorage.setItem('token',token)
  })
}
  constructor(private auth: LoginService) {
  }

}
