import { Component, OnInit } from '@angular/core';
import { AuthQuery } from 'src/store/auth.query';
import { User } from 'oidc-client';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-demo1',
  templateUrl: './demo1.component.html',
  styleUrls: ['./demo1.component.less']
})
export class Demo1Component implements OnInit {

  auth$: Observable<User>;
  profile$: Observable<any>;
  constructor(private authQuery: AuthQuery) {

  }

  ngOnInit() {
    this.auth$ = this.authQuery.auth$;
    this.profile$ = this.authQuery.profile$;
  }


}
