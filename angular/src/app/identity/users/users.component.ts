import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../store/identity.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { Identity } from '../models/identity';
import { switchMap, pluck, take, mergeMap } from 'rxjs/operators';
import { IdentityQuery } from '../store/identity.query';
import { Observable } from 'rxjs';
import { PermissionsService } from '../store/permissions.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit {

  dataItems$: Observable<Identity.UserItem[]>;

  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };

  selected: Identity.UserItem;
  selectedUserRoles: Identity.RoleItem[];

  constructor(
    private identityService: IdentityService,
    private permissionsService: PermissionsService,
    private identityQuery: IdentityQuery,
    private modalService: NzModalService
  ) {

  }

  ngOnInit() {
    this.refresh();
    this.dataItems$ = this.identityQuery.users$;
  }

  refresh() {
    this.identityService.getUsers().subscribe();
    this.identityService.getRoles().subscribe();
    // this.permissionsService.getPermissions({ providerKey: "mall", providerName: "R" }).subscribe();
  }

  delete() { }

  // edit(item: UserDto): void {
  //   this.modalHelper
  //     .open(EditUserComponent, { id: item.id }, 'md', { nzMaskClosable: false })
  //     .subscribe(result => {
  //       if (result) {
  //         this.refresh();
  //       }
  //     });
  // }

  edit(id: string) {
    this.identityService.getUserById(id)
      .pipe(
        mergeMap(() => this.identityService.GetUserRoles(id)),
        // pluck('IdentityState'),
        // take(1)
      )
      .subscribe((state: any) => {
        console.log(state)
        this.selected = state.selectedUser;
        this.selectedUserRoles = state.selectedUserRoles || [];
        //this.openModal();
      });
  }
}