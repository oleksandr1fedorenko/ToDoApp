import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private http: HttpClient) {}


  public login(user: User): Observable<string> {
    return this.http.post('https://localhost:5001/api/auth/login', user, {
      responseType: 'text',
    });
  }


}
