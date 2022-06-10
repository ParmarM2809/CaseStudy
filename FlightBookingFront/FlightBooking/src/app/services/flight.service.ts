import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Booking, FlightData, SearchedFlight } from '../models/FlightData';
import { BookFlightModel } from '../models/BookFlightModel';
import { Airlines } from '../models/Airlines';
import { Availablecity } from '../models/Availablecity';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';


@Injectable()
export class FlightService {
    apiURL = environment.baseApiURL;
    private _EditAvailListUrl = "https://localhost:44339/api/Booking/EditTicketAvaibility"
    private _BookingsListUrl = "https://localhost:44340/api/Flight/BookingList/"
    private _AirlineListUrl = "https://localhost:44340/api/Flight/AvailableAirline"
    private _CityUrl = "https://localhost:44340/api/Flight/ServiceCity"
    private _ModifyAirlineUrl = "https://localhost:44340/api/Flight/AddUpdateFlight"
    private _flightListUrl = "http://localhost:28749/api/gatway/Flight/GetAllFlightList"
    private _BookReservationUrl = "https://localhost:44339/api/Booking/AddUpdateFlightBooking"
    private _YourReservationUrl = "https://localhost:44339/api/Booking/GetActiveBookingList/"
    private _FlightIdUrl = "https://localhost:44340/api/Flight/GetFlightByID/"
    private _GetBookingByIdUrl = "https://localhost:44339/api/Booking/GetBookingById/"
    private _GetSearchedFlightUrl = "https://localhost:44340/api/Flight/GetSearchedFlightList/"

    token: string | null;

    constructor(private http: HttpClient, private _router: Router, private _authService: AuthService) {
        this.token = _authService.getToken();
    }


    EditFlightAvail(input: BookFlightModel): Observable<BookFlightModel> {
        return this.http.post<BookFlightModel>(this.apiURL + "EditTicketAvaibility", input)
    }

    AvailableFlight(): Observable<FlightData[]> {
        debugger

        var header = {
            headers: new HttpHeaders()
                .set('Authorization', `Basic ${this.token}`)
        }
        return this.http.get<FlightData[]>(this.apiURL + "GetAllFlightList")
    }

    Bookings(SearchDate: Date): Observable<Booking[]> {
        debugger
        return this.http.get<Booking[]>(this.apiURL + "BookingList/" + SearchDate)
    }

    AvailableAirlines(): Observable<Airlines[]> {
        return this.http.get<Airlines[]>(this.apiURL + "AvailableAirline")
    }

    AvailableCities(): Observable<Availablecity[]> {
        return this.http.get<Availablecity[]>(this.apiURL + "ServiceCity")
    }

    SearchedFlight(SearchText: SearchedFlight): Observable<FlightData[]> {
        return this.http.post<FlightData[]>(this.apiURL + "GetSearchedFlightList/", SearchText)
    }

    YourBookings(userId: number): Observable<BookFlightModel[]> {
        return this.http.get<BookFlightModel[]>(this.apiURL + "GetActiveBookingList/" + userId)
    }

    BookFlight(bookflight: BookFlightModel) {
        return this.http.post<any>(this.apiURL + "AddUpdateFlightBooking", bookflight)
    }

    AddUpdateFlight(flightData: FlightData) {
        console.log(flightData)
        return this.http.post<any>(this.apiURL + "AddUpdateFlight", flightData)
    }

    GetFlightById(FlightID: number): Observable<FlightData> {
        return this.http.get<FlightData>(this.apiURL + "GetFlightByID/" + FlightID)
    }

    GetBookingId(BookingId: number): Observable<BookFlightModel> {
        return this.http.get<BookFlightModel>(this.apiURL + "GetBookingById/" + BookingId)
    }

}