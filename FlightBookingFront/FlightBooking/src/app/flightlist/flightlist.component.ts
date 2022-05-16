import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FlightData } from '../models/FlightData';
import { FlightService } from '../services/flight.service';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-flightlist',
  templateUrl: './flightlist.component.html',
  styleUrls: ['./flightlist.component.css']
})
export class FlightlistComponent implements OnInit {

  AvailablrFLights: Array<FlightData> = new Array<FlightData>();
  FlightModel: FlightData = new FlightData();
  SearchText: string = '';

  constructor(private _flightService: FlightService, private _router: Router,
    private toastr: ToastrService , private _auth : AuthService) { }

  ngOnInit(): void {
    this._flightService.AvailableFlight().subscribe(res => this.AvailablrFLights = res, err => console.log(err))
    this.toastr.success('', 'Your available flight list..!');
  }

  SearchmodelChangeFn(value: string): void {
    this._flightService.SearchedFlight(value).subscribe(res => this.FliteredResult(res),
      err => console.log(err))
    this.toastr.success('', 'Your searched available flight list..!');
  }

  FliteredResult(res: any) {
    this.AvailablrFLights = new Array<FlightData>();
    this.AvailablrFLights = res;
  }

  BookTickets(input: FlightData) {
    this.FlightModel = input;
    this._router.navigate(['bookflight/', this.FlightModel.id]);
  }

  ModifyFlight(input: FlightData)
  {
    this.FlightModel = input;
    this._router.navigate(['modfiyflight/', this.FlightModel.id]);
  }
  CreatNewFlight()
  {
    this._router.navigate(['modfiyflight/']);

  }

  RoleCheck(): number {
    return this._auth.getRoleId() 
   }

}
