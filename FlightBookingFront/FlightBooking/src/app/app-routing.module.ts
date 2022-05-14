import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookflightComponent } from './bookflight/bookflight.component';
import { EventsComponent } from './events/events.component';
import { FlightlistComponent } from './flightlist/flightlist.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGaurd } from './services/auth.gaurd';
import { SpecialEventsComponent } from './special-events/special-events.component';
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
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
