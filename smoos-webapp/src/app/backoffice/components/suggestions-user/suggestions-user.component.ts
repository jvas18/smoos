import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { allCategories } from '../../../shared/enums/categories.enum';
import { AppService } from '../../services/app.service';
import { SuggestionService } from '../../services/suggestions.service';

@Component({
  selector: 'app-suggestions-user',
  templateUrl: './suggestions-user.component.html',
  styleUrls: ['./suggestions-user.component.css']
})
export class SuggestionsUserComponent implements OnInit {

  constructor(private suggestionService: SuggestionService,
              private appService: AppService) { }

  categories = allCategories();

  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    categories: new FormControl('', [Validators.required]),
    userId: new FormControl()
  });

  ngOnInit(): void {
  }
  save(){
    const user = this.appService.sessionUser;
    this.form.patchValue({userId: user.id});
    console.log(this.form.value);
    this.suggestionService.create(this.form.value).subscribe(resp => {
      this.appService.toastr.success('Sugestão enviada com sucesso', 'Sucesso');
    });
  }

}
