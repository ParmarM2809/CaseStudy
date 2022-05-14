import { Component, OnInit } from '@angular/core';
import { Router , ActivatedRoute } from '@angular/router';
import { BookFlightModel } from '../models/BookFlightModel';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-bookflight',
  templateUrl: './bookflight.component.html',
  styleUrls: ['./bookflight.component.css']
})
export class BookflightComponent implements OnInit {
  bookReservationData: BookFlightModel = new BookFlightModel();
  constructor(private _router: Router , private _activatedRoute : ActivatedRoute,
    private _flightService: FlightService)
   { }

 

ngOnInit()  {
  debugger
  console.log(this._activatedRoute.snapshot.paramMap.get('id'));
}


BookTickes() {
  console.log(this.bookReservationData);
  this._flightService.BookFlight(this.bookReservationData).subscribe(res => {
    this._router.navigate(['/flightlist'])
  },
    err => console.log(err));
}

}
