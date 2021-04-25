import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-sign-up-page',
  templateUrl: './sign-up-page.component.html',
  styleUrls: ['./sign-up-page.component.css']
})
export class SignUpPageComponent implements OnInit {

  constructor(private userService: UserService) { }

  form = new FormGroup({
    name: new FormControl('',[Validators.required]),
    email: new FormControl('',[Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
    confirmPassword:  new FormControl('', Validators.required)
  });

  ngOnInit(): void {
  }

  save(){

    this.userService.create(this.form.value).pipe(
    ).subscribe(resp => {
    });

  }
}
