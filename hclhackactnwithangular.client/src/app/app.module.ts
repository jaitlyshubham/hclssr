import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { StaffComponent } from './staff/staff.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { StaffAttendanceComponent } from './staff-attendance/staff-attendance.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    StaffComponent,
    DashboardComponent,
    StaffAttendanceComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    RouterModule.forRoot([
      { path: '', pathMatch: 'full', redirectTo: 'app-dashboard' },
      { path: 'app-dashboard', component: DashboardComponent },
      { path: 'app-staff', component: StaffComponent },
      { path: 'app-staff-attendance', component: StaffAttendanceComponent },
      { path: 'app-login', component: LoginComponent }
    ])],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
