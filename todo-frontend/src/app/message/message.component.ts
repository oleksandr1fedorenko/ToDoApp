import {Component, OnInit} from '@angular/core';
import {MessageService} from "../../services/message.service";

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {

  errorMessage = '';
  successMessage = '';

  constructor(private messageService: MessageService) {
  }

  ngOnInit(): void {
    this.messageService.getMessages().subscribe(messageAndType => {
      if (messageAndType.type === 'success') {
        this.successMessage = messageAndType.message;
      } else {
        this.errorMessage = messageAndType.message;
      }
      setTimeout(() => {
        this.errorMessage = '';
        this.successMessage = '';
      }, messageAndType.timeout);
    });
  }

}
