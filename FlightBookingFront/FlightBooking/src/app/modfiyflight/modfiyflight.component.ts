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

  constructor(private _router: Router, private _activatedRoute: ActivatedRoute,
    private _flightService: FlightService, private _auth: AuthService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.AvailableAirline();
    this.AvailableCity();
    console.log(this.AirlineList);
    console.log(this.AvailableCityList);
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
    debugger
    console.log(this.FlightDetailModel);
    this._flightService.AddUpdateFlight(this.FlightDetailModel).subscribe(res => {
      this._router.navigate(['/flightlist'])
      this.toastr.success('Thank You', 'Your details are saved..!')
    },
      err => console.log(err));
  }

}
