import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserData} from '../models/UserData';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent  {

  registerUserData: UserData = new UserData();
  constructor(private _auth: AuthService, private _router: Router,
    private toastr: ToastrService) { }
  
  registerUser() {
    console.log(this.registerUserData);
    this._auth.registerUser(this.registerUserData).subscribe(res => {
      this.toastr.success('Thank You', 'Your details are saved..! Please login with your new credentials')
      this._router.navigate(['/login'])
    },
      err => console.log(err));
  }
}
