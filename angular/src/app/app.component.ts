import { Component, HostBinding, OnInit } from '@angular/core';

import { SettingsService } from './core/settings/settings.service';
import { SignalRGroupAdapter } from './layout/signalr-group-adapter';
import { ChatAdapter } from 'ng-chat';
import { SignalRAdapter } from './layout/SignalRAdapter';
import { HttpClient } from '@angular/common/http';
import { AuthQuery } from 'src/store/auth/auth.query';
import { DemoAdapter } from './layout/demoAdapter';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

    @HostBinding('class.layout-fixed') get isFixed() { return this.settings.getLayoutSetting('isFixed'); };
    @HostBinding('class.aside-collapsed') get isCollapsed() { return this.settings.getLayoutSetting('isCollapsed'); };
    @HostBinding('class.layout-boxed') get isBoxed() { return this.settings.getLayoutSetting('isBoxed'); };
    @HostBinding('class.layout-fs') get useFullLayout() { return this.settings.getLayoutSetting('useFullLayout'); };
    @HostBinding('class.hidden-footer') get hiddenFooter() { return this.settings.getLayoutSetting('hiddenFooter'); };
    @HostBinding('class.layout-h') get horizontal() { return this.settings.getLayoutSetting('horizontal'); };
    @HostBinding('class.aside-float') get isFloat() { return this.settings.getLayoutSetting('isFloat'); };
    @HostBinding('class.offsidebar-open') get offsidebarOpen() { return this.settings.getLayoutSetting('offsidebarOpen'); };
    @HostBinding('class.aside-toggled') get asideToggled() { return this.settings.getLayoutSetting('asideToggled'); };
    @HostBinding('class.aside-collapsed-text') get isCollapsedText() { return this.settings.getLayoutSetting('isCollapsedText'); };

    constructor(
        public settings: SettingsService,
        private http: HttpClient,
        private authQuery: AuthQuery
    ) {

        this.authQuery.profile$.subscribe(res => {
            if (res.sub) {
                this.username = res.name;
                // this.adapter = new SignalRAdapter(res.sub, this.http);
                this.joinSignalRChatRoom();
            }
        })
    }

    ngOnInit() {
        // prevent empty links to reload the page
        document.addEventListener('click', e => {
            const target = e.target as HTMLElement;
            if (target.tagName === 'A' && ['', '#'].indexOf(target.getAttribute('href')) > -1)
                e.preventDefault();
        });
    }

    currentTheme = 'dark-theme';

    triggeredEvents = [];

    fileUploadUrl: string = `${SignalRAdapter.serverBaseUrl}home/UploadFile`;

    userId: string = "offline-demo";
    username: string;

    adapter: ChatAdapter = new DemoAdapter();

    signalRAdapter: SignalRGroupAdapter;

    switchTheme(theme: string): void {
        this.currentTheme = theme;
    }

    onEventTriggered(event: string): void {
        this.triggeredEvents.push(event);
    }

    joinSignalRChatRoom(): void {
        console.log("joinSignalRChatRoom");
        this.signalRAdapter = new SignalRGroupAdapter(this.username, this.http);
    }
}
