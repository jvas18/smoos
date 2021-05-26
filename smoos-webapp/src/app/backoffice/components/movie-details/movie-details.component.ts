import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  option: string;
  val: number;

  form = new FormGroup({
    title: new FormControl('', [Validators.required]),
    comment: new FormControl('', [Validators.required]),
    rating: new FormControl('', Validators.required),
  });

  favoriteWork(){
    this.option = 'favorited-heart';
  }
}
