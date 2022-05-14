import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { UserData } from '../models/UserData';
import { RegistrationData } from '../models/RegistrationData';

@Injectable()
export class AuthService {
    private _registerUrl = "https://localhost:44339/api/UserAuth/RegisterUser"
    private _loginUrl = "https://localhost:44329/api/Auth/LogIn"

    constructor(private http: HttpClient, private _router: Router) {

    }

    loginUser(user: any) {
        return this.http.post<any>(this._loginUrl, user)
    }

    registerUser(user: RegistrationData) {
        console.log(user);
        return this.http.post<any>(this._registerUrl, user)
    }

    logoutUser() {
        localStorage.removeItem('token')
        this._router.navigate(['/login'])
    }

    getToken() {
        return localStorage.getItem('token')
    }

    getUserId() {
        return localStorage.getItem('userId')
    }

    loggedIn() {
        return !!localStorage.getItem('token')
    }
}