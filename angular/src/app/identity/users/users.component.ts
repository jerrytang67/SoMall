import { Component, OnInit } from '@angular/core';
import { IdentityService } from '../store/identity.service';
import { NzModalService } from 'ng-zorro-antd';
import { EditUserComponent } from '../components/edit-user/edit-user.component';

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

  create() {
    const modal = this.modalService.create({
      nzTitle: 'Modal Title',
      nzContent: EditUserComponent,
      nzComponentParams: {
        title: 'title in component',
        subtitle: 'component sub title，will be changed after 2 sec'
      },
      nzFooter: [
        {
          label: '确定',
          onClick: componentInstance => {
            console.log("componentInstance",componentInstance);
            
            componentInstance!.title = 'title in inner component is changed';
          }
        }
      ]
    });

    modal.afterOpen.subscribe(() => console.log('[afterOpen] emitted!'));

    // Return a result when closed
    modal.afterClose.subscribe(result => console.log('[afterClose] The result is:', result));
  }
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
