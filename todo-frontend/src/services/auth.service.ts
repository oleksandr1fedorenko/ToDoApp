import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/internal/Observable';
import {User} from '../app/models/user';
import {EMPTY, Subject, Subscriber} from "rxjs";
import {MessageService} from "./message.service";

export const DEFAULT_REDIRECT_AFTER_LOGIN = "/tasks";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  public redirectAfterLogin: string = DEFAULT_REDIRECT_AFTER_LOGIN

  constructor(private http: HttpClient, private messageService: MessageService,) {
  }


  public login(user: User): Observable<string> {
    return this.http.post('https://localhost:5001/api/Auth/login', user, {
      responseType: 'text',
    });
  }

  logout() {
    localStorage.removeItem("token")
    localStorage.removeItem("username")
    localStorage.setItem("isLoggedIn", String(false))
  }

  isLoggedIn() {
    return localStorage.getItem("isLoggedIn") === "true";
  }

  register(user: User) {
    return this.http.post<string>('https://localhost:5001/api/Auth/register', user)

  }


}
