import {Component} from '@angular/core';

import {User} from "../models/user";
import {MessageService} from "../../services/message.service";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";
import {FormControl, Validators} from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user = new User();

  constructor(private messageService: MessageService, private auth: AuthService, private router: Router) {
  }

  register(user: User) {
    this.auth.register(user).subscribe()
    console.log(user)
    this.messageService.success("Account was created successfully")
    this.router.navigateByUrl('/login')
  }


}
