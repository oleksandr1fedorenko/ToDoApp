import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User} from "../app/models/User";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) {
  }

  login(user: User): Observable<string> {
    return this.http.post('https://localhost:5001/api/auth/login', user, {responseType: 'text'});
  }
}
