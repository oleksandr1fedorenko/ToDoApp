import {Component} from '@angular/core';
import {FormControl, Validators} from "@angular/forms";
import {Task} from "../models/task";
import {User} from "../models/user";
import {MessageService} from "../../services/message.service";
import {AuthService} from "../../services/auth.service";
import {IRegister} from "../models/IRegister";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  user = new User();



  constructor(private messageService: MessageService, private auth: AuthService) {
  }

  register(user: User) {


    this.auth.register(user).subscribe()
    console.log(user)
  }


}
