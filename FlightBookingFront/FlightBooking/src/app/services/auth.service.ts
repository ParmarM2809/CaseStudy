import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { UserData } from '../models/UserData';
import { environment } from 'src/environments/environment';

@Injectable()
export class AuthService {
    apiURL = environment.baseApiURL;
    private _registerUrl = "https://localhost:44339/api/UserAuth/RegisterUser"
    private _loginUrl = "https://localhost:44329/api/Auth/LogIn"

    constructor(private http: HttpClient, private _router: Router) {

    }

    loginUser(user: any) {
        return this.http.post<any>(this.apiURL + "LogIn", user)
    }

    registerUser(user: UserData) {
        return this.http.post<any>(this.apiURL + "RegisterUser", user)
    }

    logoutUser() {
        localStorage.removeItem('token')
        localStorage.removeItem('userId')
        localStorage.removeItem('roleId')
        this._router.navigate(['/login'])
    }

    getToken() {
        return localStorage.getItem('token')
    }

    getUserId() {
        return Number(localStorage.getItem('userId'))
    }

    getRoleId() {
        return Number(localStorage.getItem('roleId'))
    }

    loggedIn() {
        return !!localStorage.getItem('token')
    }
}