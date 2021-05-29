import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppService } from '../../services/app.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {

  constructor(private router: Router,
              private appService: AppService,
              private authService: AuthService) { }

  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required)
  });

  ngOnInit(): void {
  }
  signIn() {
    if (this.form.invalid) { return; }


    this.authService.auth(this.form.value).pipe(

    ).subscribe(resp => {
      this.appService.storeAccessToken(resp.accessToken);
      this.appService.storeUser(resp.sessionUser);
      this.router.navigate(['/homepage-user']);
    });
  }


}
