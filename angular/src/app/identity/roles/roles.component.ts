import { Component, OnInit } from '@angular/core';
import { Identity } from '../models/identity';
import { Observable } from 'rxjs';
import { IdentityQuery } from '../store/identity.query';
import { IdentityService } from '../store/identity.service';
import { PermissionsService } from '../store/permissions.service';
import { mergeMap } from 'rxjs/operators';import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { PermissionsManagerComponent } from '../permissions-manager/permissions-manager.component';
import { EditRoleComponent } from './role-edit.component';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styles: [`
  .anticon {
        margin-right: 6px;
        font-size: 24px;
      }`
  ]
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

  create() {
    const modal = this.modalService.create({
      nzTitle: '新建角色',
      nzWidth: '40vw',
      nzContent: EditRoleComponent,
      nzComponentParams: {
        form: {
          name: "",
          isDefault: true,
          isPublic: false
        }
      },
      nzFooter: [
        {
          label: '确定',
          onClick: instance => {
            console.log("componentInstance", instance);
            if (instance.f.valid) {
              this.identityService.createRole(instance.form).subscribe(res => {
                this.message.success("新建成功");
                this.refresh();
                modal.destroy();
              })
            }
            else {
              instance.f.ngSubmit.emit(null)
              this.message.error("表单错误")
            }
          }
        }
      ]
    });
  }

  delete(role: Identity.RoleItem) {
    this.identityService.deleteRole(role.id).subscribe(res => {
      this.message.success("删除成功");
      this.refresh();
    })
  }

  edit(role: Identity.RoleItem) {
    const modal = this.modalService.create({
      nzTitle: '编辑角色',
      nzWidth: '40vw',
      nzContent: EditRoleComponent,
      nzComponentParams: {
        id: role.id,
        form: role
      },
      nzFooter: [
        {
          label: '确定',
          type: "primary",
          onClick: instance => {
            console.log("componentInstance", instance);
            if (instance.f.valid) {
              this.identityService.updateRole(role.id, instance.form).subscribe(res => {
                this.message.success("修改成功");
                this.refresh();
                modal.destroy();
              })
            }
            else {
              instance.f.ngSubmit.emit(null)
              this.message.error("表单错误")
            }
          }
        }
      ]
    });
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
        id: role.id,
        name: role.name
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
