import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'
import { Injectable } from '@angular/core';
import { UserData } from '../models/UserData';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class UserService {
    apiURL = environment.baseApiURL;

    private _UserListUrl = "https://localhost:44329/api/UserManagment/UserList"

    constructor(private http: HttpClient, private _router: Router) {

    }

    UserList() : Observable<UserData[]> {
        return this.http.get<UserData[]>(this.apiURL + "UserList") 
    }

}