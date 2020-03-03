import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-demo1',
  templateUrl: './demo1.component.html',
  styleUrls: ['./demo1.component.less']
})
export class Demo1Component implements OnInit {

  constructor(private oauthService: OAuthService) { }

  ngOnInit() {
  }

  public login() {
    this.oauthService.initLoginFlow();
  }

  public logoff() {
    this.oauthService.logOut();
  }

  public get name() {
    const claims: any = this.oauthService.getIdentityClaims();
    if (!claims) return null;
    return claims.given_name;
  }
}
