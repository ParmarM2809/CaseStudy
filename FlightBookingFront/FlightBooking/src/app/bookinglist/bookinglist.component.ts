import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookFlightModel } from '../models/BookFlightModel';
import { AuthService } from '../services/auth.service';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-bookinglist',
  templateUrl: './bookinglist.component.html',
  styleUrls: ['./bookinglist.component.css']
})
export class BookinglistComponent implements OnInit {

  BookingDetails: BookFlightModel = new BookFlightModel();
  BookingList: Array<BookFlightModel> = new Array<BookFlightModel>();
  userId: number = 0;

  constructor(private _flightService: FlightService, private _router: Router,
    private _auth: AuthService) { }

  ngOnInit(): void {
    this.userId = this._auth.getUserId()
    this._flightService.YourBookings(this.userId).
      subscribe(res => this.BookingList = res, err => console.log(err))
  }

  EditBooking(input:BookFlightModel ) {
    this._router.navigate(['bookflight/', input.flightId , input.id ]);
  }

}
