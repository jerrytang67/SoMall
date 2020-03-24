import { Component, OnInit } from '@angular/core';

import { UserblockService } from './userblock.service';
import { SettingsService } from '@core/settings/settings.service';

@Component({
    selector: 'app-userblock',
    templateUrl: './userblock.component.html',
    styleUrls: ['./userblock.component.scss']
})
export class UserblockComponent implements OnInit {
    user = {
        name: "TT",
        job: "development",
        picture: 'assets/img/user/01.jpg'
    };
    constructor(public userblockService: UserblockService, public setting: SettingsService) {
    }

    ngOnInit() {
        this.user = this.setting.user;
    }

    userBlockIsVisible() {
        return this.userblockService.getVisibility();
    }

}
