import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AppService } from '../../services/app.service';
import { ArtistService } from '../../services/artist.service';

@Component({
  selector: 'app-register-artist',
  templateUrl: './register-artist.component.html',
  styleUrls: ['./register-artist.component.css']
})
export class RegisterArtistComponent implements OnInit {

  
  constructor(private artistService: ArtistService,
              private appService: AppService) { }
  form = new FormGroup({
    name: new FormControl('', [Validators.required]),
    age: new FormControl('', [Validators.required]),
    description: new FormControl('', Validators.required),
    photo: new FormGroup({
      buffer: new FormControl(),
      name: new FormControl(),
      contentType: new FormControl()
    }),
    photoUrl: new FormControl()
  });
  ngOnInit(): void {
  }
  save(){
    this.artistService.create(this.form.value).pipe(
    ).subscribe(resp => {
      this.appService.toastr.success('Sucesso', 'Artista Cadastrado');
    });

  }
  onAttachment($event, formGroup: any, image: any) {
    if (image.length === 0) return;

    var reader = new FileReader();
    reader.readAsDataURL(image[0]);
    reader.onload = (_event) => {
      this.form.get('posterUrl').setValue(reader.result);
    }

    this.appService.onFileChange($event, formGroup);
  }

}
