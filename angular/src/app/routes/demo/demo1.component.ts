import { Component, OnInit } from '@angular/core';
import { AuthQuery } from 'src/store/auth.query';
import { User } from 'oidc-client';
import { Observable } from 'rxjs';
import { AuthService } from 'src/store/auth.service';

@Component({
  selector: 'app-demo1',
  templateUrl: './demo1.component.html'
})
export class Demo1Component implements OnInit {

  auth$: Observable<User>;
  profile$: Observable<any>;
  constructor(public authQuery: AuthQuery, public authService: AuthService) {

  }

  ngOnInit() {
    this.auth$ = this.authQuery.auth$;
    this.profile$ = this.authQuery.profile$;
  }


}
