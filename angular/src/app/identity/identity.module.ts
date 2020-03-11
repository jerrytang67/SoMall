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
import { ShopListComponent } from './shop/shop-list.component';



const COMPONENTS = [UsersComponent, RolesComponent, ShopListComponent]
const ENTRYCOMPONENTS = [EditUserComponent]
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
