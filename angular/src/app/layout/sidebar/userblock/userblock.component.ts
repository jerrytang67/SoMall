import { Component, OnInit } from '@angular/core';

import { UserblockService } from './userblock.service';
import { AuthQuery } from 'src/store/auth/auth.query';

@Component({
    selector: 'app-userblock',
    templateUrl: './userblock.component.html'
})
export class UserblockComponent implements OnInit {



    constructor(
        public userblockService: UserblockService,
        public authQuery: AuthQuery
    ) {
        
    }

    ngOnInit() {

    }

    userBlockIsVisible() {
        return this.userblockService.getVisibility();
    }

}
