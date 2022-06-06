import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserData } from '../models/UserData';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {
  
  UserDatas:Array<UserData> = new Array<UserData>();
  constructor(private _userService: UserService, private _router: Router) { }
  data: any;  
  ngOnInit(): void {

    this._userService.UserList().subscribe(res => this.UserDatas = res , err => console.log(err))
    console.log(this.data);
  }
}
