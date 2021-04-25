import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ArtistService } from '../../services/artist.service';

@Component({
  selector: 'app-register-artist',
  templateUrl: './register-artist.component.html',
  styleUrls: ['./register-artist.component.css']
})
export class RegisterArtistComponent implements OnInit {

  
  constructor(private artistService: ArtistService) { }
  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    age: new FormControl('', [Validators.required]),
    description: new FormControl('', Validators.required)
  });
  ngOnInit(): void {
  }
  save(){
    this.artistService.create(this.form.value).pipe(
    ).subscribe(resp => {
    });

  }

}
