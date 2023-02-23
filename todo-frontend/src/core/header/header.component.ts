import {Component, OnInit} from '@angular/core';
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn: boolean = true;

  constructor(private auth: AuthService,private router:Router) {
  }

  ngOnInit() {
    this.isLoggedIn = this.auth.isLoggedIn()
  }

  logout() {
    this.auth.logout();
    this.router.navigateByUrl('login')

  }

}
