import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrationData} from '../models/RegistrationData';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent  {

  registerUserData: RegistrationData = new RegistrationData();
  constructor(private _auth: AuthService, private _router: Router) { }
  
  registerUser() {
    console.log(this.registerUserData);
    this._auth.registerUser(this.registerUserData).subscribe(res => {
      // localStorage.setItem('token', res.token)
      this._router.navigate(['/userlist'])
    },
      err => console.log(err));
  }
}
