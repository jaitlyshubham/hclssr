import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent implements OnInit {
  users: any[] = [];
  ngOnInit() {
    this.getUsers();
  }
  constructor(private userService: UserService) {

  }
  getUsers() {
    this.userService.getUsers().subscribe((data: any) => { console.log(data) })
  }

}
