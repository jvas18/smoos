import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { allCategories } from '../../../shared/enums/suggestion-categories.enum'

@Component({
  selector: 'app-suggestions-user',
  templateUrl: './suggestions-user.component.html',
  styleUrls: ['./suggestions-user.component.css']
})
export class SuggestionsUserComponent implements OnInit {

  constructor() { }

  categories = allCategories();

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    categories: new FormControl('', [Validators.required])
  });

  ngOnInit(): void {
  }

}
