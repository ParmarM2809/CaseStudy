import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookFlightModel } from '../models/BookFlightModel';
import { FlightData } from '../models/FlightData';
import { AuthService } from '../services/auth.service';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-bookflight',
  templateUrl: './bookflight.component.html',
  styleUrls: ['./bookflight.component.css']
})
export class BookflightComponent implements OnInit {

  FlightId: number = 0;
  BookingId: number = 0;
  bookReservationData: BookFlightModel = new BookFlightModel();
  FlightDetailModel: FlightData = new FlightData();

  constructor(private _router: Router, private _activatedRoute: ActivatedRoute,
    private _flightService: FlightService, private _auth: AuthService , 
    private toastr: ToastrService) { }

  ngOnInit() {
    this.FlightId = Number(this._activatedRoute.snapshot.paramMap.get('id'))
    this.BookingId = Number(this._activatedRoute.snapshot.paramMap.get('bookingid'))
    if (this.BookingId > 0 && this.FlightId > 0) {
      this.ModifyBookings(this.BookingId);
    }
    else {
      this.GetFlightById(this.FlightId)
    }
  }

  SuccessGet(res: any) {
    if (this.BookingId == 0) {
      this.FlightDetailModel = res;
      this.bookReservationData.userId = this._auth.getUserId()
      this.bookReservationData.flightName = this.FlightDetailModel.airlineName;
      this.bookReservationData.price = this.FlightDetailModel.price;
      this.bookReservationData.total = this.FlightDetailModel.price;
      this.bookReservationData.flightId = this.FlightId;
      this.bookReservationData.bookedSeats = 1;
    }
    else {
      this.bookReservationData = new BookFlightModel();
      this.bookReservationData = res;
      this.bookReservationData.flightName = res.flight.airlineName;
      this.bookReservationData.price = res.flight.price;
    }
  }

  GetFlightById(Id: number) {
    this._flightService.GetFlightById(Id).
      subscribe(res => this.SuccessGet(res), err => console.log(err))
  }

  ModifyBookings(BookingId: number) {
    this._flightService.GetBookingId(BookingId).
      subscribe(res => this.SuccessGet(res), err => console.log(err))
  }


  SeatmodelChangeFn(value: any) {
    this.bookReservationData.total = this.bookReservationData.price * value
  }


  BookTickes() {
    this.bookReservationData.userId = this._auth.getUserId();
    this.bookReservationData.flightId = this.FlightId;
    this._flightService.BookFlight(this.bookReservationData).subscribe(res => {
      this._router.navigate(['/flightlist'])
      this.toastr.success('Thank You', 'Your details are saved..!')
    },
      err => console.log(err));
  }

}
function res(res: any) {
  throw new Error('Function not implemented.');
}

