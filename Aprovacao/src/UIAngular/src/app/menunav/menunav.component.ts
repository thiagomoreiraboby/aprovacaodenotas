import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-menunav',
  templateUrl: './menunav.component.html',
  styleUrls: ['./menunav.component.css']
})
export class MenunavComponent implements OnInit {

  caminhoswagger = environment.API_URL + "/swagger/index.html";
  constructor() { }

  ngOnInit(): void {
  }

}
