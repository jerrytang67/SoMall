import { Component, OnInit, Input } from '@angular/core';
import { PermissionsQuery } from '../store/permissions.query';
import { Permission, Group } from '../store/permissions.store';
import { Observable, from, forkJoin } from 'rxjs';
import { PermissionsService } from '../store/permissions.service';
import { IdentityService } from '../store/identity.service';
import { pluck, map, mergeAll, filter, concatAll, concatMap, reduce } from 'rxjs/operators';
@Component({
  selector: 'app-permissions-manager',
  templateUrl: './permissions-manager.component.html',
  styleUrls: ['./permissions-manager.component.scss']
})
export class PermissionsManagerComponent implements OnInit {

  @Input() id: string;

  selectedIndex = 0;
  groups: any[] = []

  updateList: any[] = [];

  constructor(private permissionsQuery: PermissionsQuery,
    private identityService: IdentityService) { }

  ngOnInit(): void {
    this.identityService.getRoleById(this.id).subscribe();
    this.identityService.GetUserRoles(this.id).subscribe();
    this.permissionsQuery.groups$.subscribe(res => {
      res.forEach(item => {
        this.groups = [...this.groups, {
          name: item.name, displayName: item.displayName,
          permissions: item.permissions.map(p => {
            return {
              label: p.displayName,
              value: p.name,
              default: p.isGranted,
              checked: p.isGranted
            }
          })
        }]
      })
    })
  }
  allChecked = false;
  indeterminate = true;
  updateSingleChecked(e) {
    from(this.groups).pipe(
      concatMap((group: any) => {
        return group.permissions.
          filter((res: any) => res.default !== res.checked).
          map((item) => {
            return { name: item.value, isGranted: item.checked };
          })
      }),
      reduce((acc, val) => [...acc, val], [])
    ).subscribe(res => {
      this.updateList = res;
    })
  }
}
