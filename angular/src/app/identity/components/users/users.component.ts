import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../../store/identity.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.less']
})
export class UsersComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };
  constructor(
    private identityService: IdentityService,
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

  create() { }
  edit() { }
  delete() { }
  // protected delete(item: UserDto): void {
  //   this.userService.delete(item.id).subscribe(() => {
  //     this.notifyService.success(
  //       this.i18NService.localize('SuccessfullyDeleted'),
  //     );
  //     this.refresh();
  //   });
  // }

  // create(): void {
  //   this.modalHelper
  //     .open(CreateUserComponent, undefined, 'md', { nzMaskClosable: false })
  //     .subscribe(result => {
  //       if (result) {
  //         this.refresh();
  //       }
  //     });
  // }

  // edit(item: UserDto): void {
  //   this.modalHelper
  //     .open(EditUserComponent, { id: item.id }, 'md', { nzMaskClosable: false })
  //     .subscribe(result => {
  //       if (result) {
  //         this.refresh();
  //       }
  //     });
  // }


}
