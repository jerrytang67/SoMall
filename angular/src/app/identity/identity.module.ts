import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersComponent } from './components/users/users.component';
import { RolesComponent } from './components/roles/roles.component';
import { IdentityRoutingModule } from './identity-routing.module';
import { LayoutModule } from '../layout/layout.module';
import { SharedModule } from '@shared';


const COMPONENTS = [UsersComponent, RolesComponent]

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    SharedModule,
    LayoutModule,
    IdentityRoutingModule,
    

  ]
})
export class IdentityModule { }
