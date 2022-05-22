import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserData } from '../models/UserData';
import { AuthService } from '../services/auth.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

  loginFailedMes: string = '';
  imgsrc: string = '';
  loginUserData: UserData = new UserData();
  constructor(private _auth: AuthService, private _router: Router,
    private toastr: ToastrService,private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.imgsrc = '../assets/loginBackground.jpg';
  }

  loginUser() {
    
    this._auth.loginUser(this.loginUserData).subscribe(res => {
      debugger
      if (res != null) {
        localStorage.setItem('token', res.token)
        localStorage.setItem('userId', res.userId)
        localStorage.setItem('roleId', res.roleId)
        this._router.navigate(['/flightlist'])
      }
      else {
        this.loginFailedMes = 'Your provided credentials are not valid.'
        this.toastr.error('', 'Your provided credentials are not valid');
      }
    },
      err => console.log(err));
  }
}
