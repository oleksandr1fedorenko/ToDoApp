import {Component} from '@angular/core';
import {User} from "../models/user";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  user = new User();

  constructor(private authService: AuthService, private router: Router) {
  }

  login(user: User) {
    this.authService.login(user).subscribe((token: string) => {
      localStorage.setItem('token', token);
      localStorage.setItem('username', user.username);
      localStorage.setItem("isLoggedIn", String(true));
      this.router.navigateByUrl("tasks")
    });
  }




}
