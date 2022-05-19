import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Booking } from '../models/FlightData';
import { AuthService } from '../services/auth.service';
import { FlightService } from '../services/flight.service';
import {DatePipe} from '@angular/common';


@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.css']
})
export class BookingsComponent implements OnInit {

  dateobj : any;
  SelectedDate: Date = new Date();
  Bookings: Array<Booking> = new Array<Booking>();
  constructor(private _flightService: FlightService, private _router: Router,
    private _auth: AuthService,private datepipe: DatePipe) { }



  ngOnInit(): void {
    this.dateobj = this.datepipe.transform(this.SelectedDate, 'dd-MM-YYYY');
    this.SearchBookingsReq(this.dateobj);
    debugger
    this.SelectedDate = this.dateobj;
  }

  SearchBookingsReq(input: Date) {
    debugger
    this._flightService.Bookings(input).
      subscribe(res => this.Bookings = res, err => console.log(err))
  }

}
