import { Component, OnInit } from '@angular/core';
import { EventData } from '../models/EventData';
import { EventService } from '../services/event.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-events',
  templateUrl: './events.component.html'
})
export class EventsComponent implements OnInit {


  events:Array<EventData> = new Array<EventData>();
  constructor(private _eventService: EventService , private toastr: ToastrService) { }

  showSuccess() {
    this.toastr.success('Hello world!', 'Toastr fun!');
  }

  ngOnInit(): void {
    this.showSuccess();
    this._eventService.getEvents().subscribe(res => this.events = res, err => console.log(err))
  }

}
