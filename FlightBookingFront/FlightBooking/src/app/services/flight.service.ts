import { HttpClient, HttpParams } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FlightData } from '../models/FlightData';
import { BookFlightModel } from '../models/BookFlightModel';
import { Airlines } from '../models/Airlines';
import { Availablecity } from '../models/Availablecity';


@Injectable()
export class FlightService {

    private _AirlineListUrl = "https://localhost:44340/api/Flight/AvailableAirline"
    private _CityUrl = "https://localhost:44340/api/Flight/ServiceCity"

    private _ModifyAirlineUrl = "https://localhost:44340/api/Flight/AddUpdateFlight"
    private _flightListUrl = "https://localhost:44340/api/Flight/GetAllFlightList"
    private _BookReservationUrl = "https://localhost:44339/api/Booking/AddUpdateFlightBooking"
    private _YourReservationUrl = "https://localhost:44339/api/Booking/GetActiveBookingList/"
    private _FlightIdUrl = "https://localhost:44340/api/Flight/GetFlightByID/"
    private _GetBookingByIdUrl = "https://localhost:44339/api/Booking/GetBookingById/"
    private _GetSearchedFlightUrl = "https://localhost:44340/api/Flight/GetSearchedFlightList/"

    constructor(private http: HttpClient, private _router: Router) {

    }

    AvailableFlight(): Observable<FlightData[]> {
        return this.http.get<FlightData[]>(this._flightListUrl)
    }


    AvailableAirlines(): Observable<Airlines[]> {
        return this.http.get<Airlines[]>(this._AirlineListUrl)
    }

    AvailableCities(): Observable<Availablecity[]> {
        return this.http.get<Availablecity[]>(this._CityUrl)
    }


    SearchedFlight(SearchText: string): Observable<FlightData[]> {
        return this.http.get<FlightData[]>(this._GetSearchedFlightUrl + SearchText)
    }

    YourBookings(userId: number): Observable<BookFlightModel[]> {
        return this.http.get<BookFlightModel[]>(this._YourReservationUrl + userId)
    }

    BookFlight(bookflight: BookFlightModel) {
        return this.http.post<any>(this._BookReservationUrl, bookflight)
    }

    AddUpdateFlight(flightData: FlightData) {
        debugger
        console.log(flightData)
        return this.http.post<any>(this._ModifyAirlineUrl, flightData)
    }

    GetFlightById(FlightID: number): Observable<FlightData> {
        return this.http.get<FlightData>(this._FlightIdUrl + FlightID)
    }

    GetBookingId(BookingId: number): Observable<BookFlightModel> {
        return this.http.get<BookFlightModel>(this._GetBookingByIdUrl + BookingId)
    }

}