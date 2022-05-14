import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FlightData } from '../models/FlightData';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-flightlist',
  templateUrl: './flightlist.component.html',
  styleUrls: ['./flightlist.component.css']
})
export class FlightlistComponent implements OnInit {

  AvailablrFLights :Array<FlightData> = new Array<FlightData>();
  FlightModel: FlightData = new FlightData();


  constructor(private _flightService: FlightService, private _router: Router) { }
  
  ngOnInit(): void {
    this._flightService.AvailableFlight().subscribe(res => this.AvailablrFLights = res , err => console.log(err))
    console.log(this.AvailablrFLights);
  }

  BookTickets(input: FlightData) {

    this.FlightModel = input;
    debugger
    this._router.navigate(['bookflight/', this.FlightModel.id]);
  }

}
