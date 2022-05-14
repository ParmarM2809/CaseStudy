import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { UserData } from '../models/UserData';
import { Observable } from 'rxjs';

@Injectable()
export class UserService {
    private _UserListUrl = "https://localhost:44329/api/UserManagment/UserList"
    private _loginUrl = "https://localhost:44329/api/Auth/LogIn"

    constructor(private http: HttpClient, private _router: Router) {

    }

    UserList() : Observable<UserData[]> {
        debugger
        return this.http.get<UserData[]>(this._UserListUrl) 
    }

}