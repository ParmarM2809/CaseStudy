import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGaurd } from './services/auth.gaurd';
import { AuthService } from './services/auth.service';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { UserlistComponent } from './userlist/userlist.component';
import { FlightlistComponent } from './flightlist/flightlist.component';
import { UserService } from './services/user.service';
import { FlightService } from './services/flight.service';
import { BookflightComponent } from './bookflight/bookflight.component';
import { BookinglistComponent } from './bookinglist/bookinglist.component';
import { ModfiyflightComponent } from './modfiyflight/modfiyflight.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    UserlistComponent ,
    FlightlistComponent,
    BookflightComponent,
    BookinglistComponent,
    ModfiyflightComponent  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot()// ToastrModule added
  ],
  providers: [AuthService,AuthGaurd,UserService,FlightService,{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptorService,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
