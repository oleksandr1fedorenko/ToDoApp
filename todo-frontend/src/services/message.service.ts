import { Injectable } from '@angular/core';
import {Observable} from "rxjs/internal/Observable";
import {Subject} from "rxjs";


@Injectable({
  providedIn: 'root'
})
export class MessageService {

  private messagesSubject = new Subject<MessageAndType>();
  constructor() { }

  public getMessages(): Observable<MessageAndType> {
    return this.messagesSubject.asObservable();
  }

  public success(message: string, timeoutMs?: number) {
    this.messagesSubject.next(new MessageAndType(message, 'success', timeoutMs));
  }
  public error(message: string, timeoutMs?: number) {
    this.messagesSubject.next(new MessageAndType(message, 'error',timeoutMs));
  }
}
export class MessageAndType {
  constructor(
    public message: string,
    public type: 'error' | 'success',
    public timeout = 3000
  ){}


}
