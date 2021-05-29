import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AppService } from '../../services/app.service';
import { BookService } from '../../services/book.service';
import { RatingService } from '../../services/rating.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {

  constructor(private bookService: BookService,
              private actRoute: ActivatedRoute,
              private ratingService: RatingService,
              private appService: AppService) { }

  option: string;
  val: number;

  form = new FormGroup({
    title: new FormControl('', [Validators.required]),
    comment: new FormControl('', [Validators.required]),
    stars: new FormControl('', Validators.required),
    userId: new FormControl(),
    bookId: new FormControl()
  });

  book;
  bookId;
  ratings = [];
  ngOnInit(): void {
    this.bookId = this.actRoute.snapshot.params.id;
    this.bookService.get(this.bookId).
    subscribe((resp)=>{
      console.log(resp);
      this.book = resp;
    });
    this.ratingService.getBook(this.bookId).subscribe((resp)=>{
      this.ratings = resp;
      console.log(resp);
    });

  }

  favoriteWork(){
    this.option = 'favorited-heart';
  }
  save(){
    const userId = this.appService.sessionUser.id;
    this.form.patchValue({userId, bookId: this.bookId});
    this.ratingService.createBook(this.form.value).pipe(
    ).subscribe(resp => {
      this.appService.toastr.success('Avaliação Enviada', 'Sucesso');
    });
    this.ratingService.getBook(this.bookId).subscribe((resp)=>{
      this.ratings = resp;
      console.log(resp);
    });

  }
}
