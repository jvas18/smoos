import { Component, OnInit } from '@angular/core';
import {
  trigger,
  state,
  style,
  transition,
  animate
} from "@angular/animations";
import { SelectItem, PrimeNGConfig } from "primeng/api";

interface Genre {
  name: string,
  code: string
}

@Component({
  selector: 'app-register-obra',
  templateUrl: './register-obra.component.html',
  styleUrls: ['./register-obra.component.css']
})
export class RegisterObraComponent implements OnInit {

  option: string;
  constructor() {
  }




  ngOnInit(): void {


  }

  selectMovie(){
    this.option = 'movie';
  }
  selectBook(){
    this.option = 'book';
  }

}
