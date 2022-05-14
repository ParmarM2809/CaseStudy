import { Component, OnInit } from '@angular/core';
import { EventData } from '../models/EventData';
import { UserData } from '../models/UserData';
import { EventService } from '../services/event.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-special-events',
  templateUrl: './special-events.component.html'
})
export class SpecialEventsComponent implements OnInit {

  events:Array<UserData> = new Array<UserData>();
  constructor(private _userService: UserService) { }

  ngOnInit(): void {
    this._userService.UserList().subscribe(res => this.events = res, err => console.log(err))
  }

}
