import { Component, OnInit } from '@angular/core';
import { Identity } from '../models/identity';
import { Observable } from 'rxjs';
import { IdentityQuery } from '../store/identity.query';
import { IdentityService } from '../store/identity.service';
import { PermissionsService } from '../store/permissions.service';
import { mergeMap } from 'rxjs/operators';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { PermissionsManagerComponent } from '../permissions-manager/permissions-manager.component';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html'
})
export class RolesComponent implements OnInit {

  dataItems$: Observable<Identity.RoleItem[]>;

  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };

  selected: Identity.RoleItem;
  selectedUserRoles: any;

  constructor(
    private identityQuery: IdentityQuery,
    private identityService: IdentityService,
    private permissionsService: PermissionsService,
    private modalService: NzModalService,
    private message: NzMessageService
  ) { }

  ngOnInit() {
    this.refresh();
    this.dataItems$ = this.identityQuery.roles$;
  }

  refresh() {
    this.identityService.getRoles().subscribe();
    this.permissionsService.getPermissions({ providerKey: "admin", providerName: "R" }).subscribe();
  }

  create() { }

  delete() { }


  edit(id: string) {

  }

  claims(id: string) {
    this.identityService.getRoleById(id)
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
  permissions(role: Identity.RoleItem) {
    const modal = this.modalService.create({
      nzTitle: 'PermissionsManager',
      nzWidth: '60vw',
      nzContent: PermissionsManagerComponent,
      nzComponentParams: {
        id: role.id
      },
      nzFooter: [
        {
          label: '确定',
          type: "primary",
          onClick: instance => {
            console.log("componentInstance", instance);
            this.permissionsService.update({
              providerKey: role.name,
              providerName: "R",
              body: {
                permissions: instance.updateList
              }
            }).subscribe(res => {
              this.message.success("修改成功");
              this.refresh();
              modal.destroy();
            })

          }
        }
      ]
    });
  }

}
