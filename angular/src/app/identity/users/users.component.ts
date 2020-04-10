import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../store/identity.service';
import { NzModalService } from 'ng-zorro-antd';
import { Identity } from '../models/identity';
import { switchMap, pluck, take } from 'rxjs/operators';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit {

  dataItems: any[] = [];
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
    private modalService: NzModalService
  ) {

  }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.identityService.getUsers().subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
    })
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
        switchMap(() => this.identityService.GetUserRoles(id)),
        // pluck('IdentityState'),
        take(1)
      )
      .subscribe((state: any) => {
        console.log(state)
        // this.selected = state.selectedUser;
        // this.selectedUserRoles = state.selectedUserRoles || [];
        //this.openModal();
      });
  }
}