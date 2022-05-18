import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Airlines } from '../models/Airlines';
import { Availablecity } from '../models/Availablecity';
import { FlightData } from '../models/FlightData';
import { AuthService } from '../services/auth.service';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-modfiyflight',
  templateUrl: './modfiyflight.component.html',
  styleUrls: ['./modfiyflight.component.css']
})
export class ModfiyflightComponent implements OnInit {

  FlightDetailModel: FlightData = new FlightData();
  AirlineList: Array<Airlines> = new Array<Airlines>();
  AvailableCityList: Array<Availablecity> = new Array<Availablecity>();

  FlightId: number = 0;

  constructor(private _router: Router, private _activatedRoute: ActivatedRoute,
    private _flightService: FlightService, private _auth: AuthService,
    private toastr: ToastrService) {
  }

  ngOnInit(): void {
    this.AvailableAirline();
    this.AvailableCity();
    this.FlightId = Number(this._activatedRoute.snapshot.paramMap.get('flightId'))
    if (this.FlightId > 0) {
      this.GetFlightById(this.FlightId);
    }
  }

  GetFlightById(FlightId: number) {
    this.FlightDetailModel = new FlightData();
    this._flightService.GetFlightById(FlightId).
      subscribe(res => this.FlightDetailModel = res, err => console.log(err))
  }

  AvailableAirline() {
    this._flightService.AvailableAirlines().
      subscribe(res => this.AirlineList = res, err => console.log(err))
  }

  AvailableCity() {
    this._flightService.AvailableCities().
      subscribe(res => this.AvailableCityList = res, err => console.log(err))
  }

  ModifyFlight() {
    console.log(this.FlightDetailModel);
    this._flightService.AddUpdateFlight(this.FlightDetailModel).subscribe(res => {
      this._router.navigate(['/flightlist'])
      this.toastr.success('Thank You', 'Your details are saved..!')
    },
      err => console.log(err));
  }

}
