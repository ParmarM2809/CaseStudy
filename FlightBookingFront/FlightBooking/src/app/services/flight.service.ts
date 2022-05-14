import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FlightData } from '../models/FlightData';
import { BookFlightModel } from '../models/BookFlightModel';


@Injectable()
export class FlightService {
    private _flightListUrl = "https://localhost:44340/api/Flight/GetAllFlightList"
    private _BookReservationUrl = "https://localhost:44340/api/Flight/GetAllFlightList"
    private _loginUrl = "https://localhost:44329/api/Auth/LogIn"

    constructor(private http: HttpClient, private _router: Router) {

    }

    AvailableFlight() : Observable<FlightData[]> {
        debugger
        return this.http.get<FlightData[]>(this._flightListUrl) 
    }

    BookFlight(bookflight: BookFlightModel) {
        console.log(bookflight);
        return this.http.post<any>(this._BookReservationUrl, bookflight)
    }

}