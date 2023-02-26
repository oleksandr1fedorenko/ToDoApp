import {Component} from '@angular/core';
import {User} from "../models/user";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";
import {MessageService} from "../../services/message.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  user = new User();

  constructor(private authService: AuthService, private router: Router, private messageService: MessageService,) {
  }

  login(user: User) {
    this.authService.login(user).subscribe((token: string) => {
      if (token) {
        localStorage.setItem('token', token);
        localStorage.setItem('username', user.username);
        localStorage.setItem("isLoggedIn", String(true));
        this.messageService.success("Successful login")
        this.router.navigateByUrl("tasks")
      }
    });
   //this.messageService.error('Bad credentials')
  }
}
