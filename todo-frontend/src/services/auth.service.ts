import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/internal/Observable';
import {User} from '../app/models/user';
import {Subject, Subscriber} from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private http: HttpClient) {
  }


  public login(user: User): Observable<string> {
    return this.http.post('https://localhost:5001/api/auth/login', user, {
      responseType: 'text',
    });
  }
  logout(){
    localStorage.removeItem("token")
    localStorage.removeItem("username")
    localStorage.setItem("isLoggedIn",String(false))
  }

  isLoggedIn() {

    return localStorage.getItem("isLoggedIn") === "true";
  }





}
