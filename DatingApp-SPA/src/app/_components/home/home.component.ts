import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/Http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  values: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  registerToggel() {
    this.registerMode = true;
  }

  cancelRegistrationMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
