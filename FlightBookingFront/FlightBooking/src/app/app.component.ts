import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { NotificationService } from './notification.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'event-app';
 
  constructor(private _authService:AuthService ,
    private notifyService : NotificationService) {
   
  }

  LogOut(){
    this._authService.logoutUser();
  }

  LoggedIn(input:boolean):boolean{
    if(input){
      return this._authService.loggedIn();
    }
    else{
      return !this._authService.loggedIn();
    }
  }

  
  showToasterSuccess(){
    this.notifyService.showSuccess("Data shown successfully !!", "ItSolutionStuff.com")
}

showToasterError(){
    this.notifyService.showError("Something is wrong", "ItSolutionStuff.com")
}

showToasterInfo(){
    this.notifyService.showInfo("This is info", "ItSolutionStuff.com")
}

showToasterWarning(){
    this.notifyService.showWarning("This is warning", "ItSolutionStuff.com")
}

  
}

  
