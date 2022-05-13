import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {

  constructor(private _userService: UserService, private _router: Router) { }
  data: any;  
  ngOnInit(): void {

    debugger
    this._userService.UserList().subscribe(res => this.data = res, err => console.log(err))
    console.log(this.data);
    // this.getdata();
  }

  // getdata() {  
    
  //   this._userService.UserList().subscribe((data) => {  
  //     this.data = data;  
  //     console.log( this.data);
  //   },
  //     err => console.log(err));
  // }

}
