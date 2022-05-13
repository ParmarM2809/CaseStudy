import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { UserData } from '../models/UserData';
import { RegistrationData } from '../models/RegistrationData';

@Injectable()
export class UserService {
    private _UserListUrl = "https://localhost:44329/api/UserManagment/UserList"
    private _loginUrl = "https://localhost:44329/api/Auth/LogIn"

    constructor(private http: HttpClient, private _router: Router) {

    }

    UserList(){
        debugger
        return this.http.get(this._UserListUrl);
    }

    // registerUser(user: RegistrationData) {
    //     console.log(user);
    //     return this.http.post<any>(this._registerUrl, user)
    // }

    // logoutUser() {
    //     localStorage.removeItem('token')
    //     this._router.navigate(['/events'])
    // }
}