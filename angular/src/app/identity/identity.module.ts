import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { IdentityRoutingModule } from './identity-routing.module';

// com
import { UsersComponent } from './users/users.component';
import { RolesComponent } from './roles/roles.component';

//entry
import { EditUserComponent } from './components/edit-user/edit-user.component';
import { PermissionsManagerComponent } from './permissions-manager/permissions-manager.component';


const COMPONENTS = [UsersComponent, RolesComponent]
const ENTRYCOMPONENTS = [EditUserComponent, PermissionsManagerComponent]
@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    SharedModule,
    LayoutModule,
    IdentityRoutingModule,
  ], entryComponents: [...ENTRYCOMPONENTS]
})
export class IdentityModule { }
