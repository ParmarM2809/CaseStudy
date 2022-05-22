import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookflightComponent } from './bookflight/bookflight.component';
import { BookinglistComponent } from './bookinglist/bookinglist.component';
import { BookingsComponent } from './bookings/bookings.component';
import { FlightlistComponent } from './flightlist/flightlist.component';
import { LoginComponent } from './login/login.component';
import { ModfiyflightComponent } from './modfiyflight/modfiyflight.component';
import { RegisterComponent } from './register/register.component';
import { UserlistComponent } from './userlist/userlist.component';

const routes: Routes = [

  {
    path: '',
    redirectTo: '/flightlist',
    pathMatch: 'full'
  },
  {
    path: 'flightlist',
    component: FlightlistComponent
  },
  {
    path: 'userlist',
    // canActivate:[AuthGaurd],
    component: UserlistComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path:'bookflight/:id',
    component:BookflightComponent
  },
  {
    path:'bookflight/:id/:bookingid',
    component:BookflightComponent
  },
  {
    path: 'bookinglist',
    component: BookinglistComponent
  },
  {
    path: 'modfiyflight',
    component: ModfiyflightComponent
  },
  {
    path: 'modfiyflight/:flightId',
    component: ModfiyflightComponent
  },
  {
    path: 'bookings',
    component: BookingsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
