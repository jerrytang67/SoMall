import { NgModule } from '@angular/core';
import { RouterModule, Router, NavigationEnd, Routes } from '@angular/router';
import { UsersComponent, RolesComponent } from '.';
import { AuthGuard } from '@core/auth-guard.service';
import { LayoutComponent } from '../layout/layout.component';


const routes: Routes = [
    { path: '', redirectTo: 'users', pathMatch: 'full' },
    {
        path: '',
        component: LayoutComponent,
        canActivate: [AuthGuard],
        children: [
            { path: 'users', component: UsersComponent, data: { title: '用户列表', permission: 'Pages' } },
            { path: 'roles', component: RolesComponent, data: { title: '权限列表', permission: 'Pages' } },
        ],
    },
]


@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})


export class IdentityRoutingModule {
    constructor(private router: Router) {
        router.events.subscribe(event => {
            if (event instanceof NavigationEnd) {
                window.scroll(0, 0);
            }
        });
    }
}
