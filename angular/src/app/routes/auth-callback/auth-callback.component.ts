import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/store/auth/auth.service';


@Component({
  selector: 'app-auth-callback',
  templateUrl: './auth-callback.component.html',
  styles: []
})
export class AuthCallbackComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.completeAuthentication();
  }

}
