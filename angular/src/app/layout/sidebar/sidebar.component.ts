import { Component, OnInit, Injector, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
declare var $: any;

import { MenuService } from '../../core/menu/menu.service';
import { SettingsService } from '../../core/settings/settings.service';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit, OnDestroy {

    menuItems: Array<any>;
    router: Router;
    sbclickEvent = 'click.sidebar-toggle';
    $doc: any = null;

    constructor(public menu: MenuService, public settings: SettingsService, public injector: Injector) {

        this.menuItems = menu.getMenu();

    }

    ngOnInit() {

        this.router = this.injector.get(Router);

        this.router.events.subscribe((val) => {
            // close any submenu opened when route changes
            this.removeFloatingNav();
            // scroll view to top
            window.scrollTo(0, 0);
            // close sidebar on route change
            this.settings.setLayoutSetting('asideToggled', false);
        });

        // enable sidebar autoclose from extenal clicks
        this.anyClickClose();

    }

    anyClickClose() {
        this.$doc = $(document).on(this.sbclickEvent, (e) => {
            if (!$(e.target).parents('.aside-container').length) {
                this.settings.setLayoutSetting('asideToggled', false);
            }
        });
    }

    ngOnDestroy() {
        if (this.$doc)
            this.$doc.off(this.sbclickEvent);
    }

    toggleSubmenuClick(event) {

        event.preventDefault();

        if (!this.isSidebarCollapsed() && !this.isSidebarCollapsedText() && !this.isEnabledHover()) {

            let ul = $(event.currentTarget.nextElementSibling);

            // hide other submenus
            let parentNav = ul.parents('.sidebar-subnav');
            $('.sidebar-subnav').each((idx, el) => {
                let $el = $(el);
                // if element is not a parent or self ul
                if (el !== parentNav[0] && el !== ul[0]) {
                    this.closeMenu($el);
                }
            });

            // abort if not UL to process
            if (!ul.length) {
                return;
            }

            // any child menu should start closed
            ul.find('.sidebar-subnav').each((idx, el) => {
                this.closeMenu($(el));
            });

            // toggle UL height
            const ulHeight = ul.css('height')
            if (ulHeight === 'auto' || parseInt(ulHeight, 10)) {
                this.closeMenu(ul);
            }
            else {
                // expand menu
                ul.on('transitionend', () => {
                    ul.css('height', 'auto').off('transitionend');
                }).css('height', ul[0].scrollHeight);
                // add class to manage animation
                ul.addClass('opening');
            }

        }

    }

    // Close menu collapsing height
    closeMenu(elem) {
        elem.css('height', elem[0].scrollHeight); // set height
        elem.css('height', 0); // and move to zero to collapse
        elem.removeClass('opening');
    }

    toggleSubmenuHover(event) {
        let self = this;
        if (this.isSidebarCollapsed() || this.isSidebarCollapsedText() || this.isEnabledHover()) {
            event.preventDefault();

            this.removeFloatingNav();

            let ul = $(event.currentTarget.nextElementSibling);
            let anchor = $(event.currentTarget);

            if (!ul.length) {
                return; // if not submenu return
            }

            let $aside = $('.aside-container');
            let $asideInner = $aside.children('.aside-inner'); // for top offset calculation
            let $sidebar = $asideInner.children('.sidebar');
            let mar = parseInt($asideInner.css('padding-top'), 0) + parseInt($aside.css('padding-top'), 0);
            let itemTop = ((anchor.parent().position().top) + mar) - $sidebar.scrollTop();

            let floatingNav = ul.clone().appendTo($aside);
            let vwHeight = document.body.clientHeight;

            // let itemTop = anchor.position().top || anchor.offset().top;

            floatingNav
                .addClass('nav-floating')

            // each item has ~40px height
            // multiply to force space for at least N items
            var safeOffsetValue = (40 * 5)
            var navHeight = floatingNav.outerHeight(true) + 2; // 2px border
            var safeOffset = navHeight < safeOffsetValue ? navHeight : safeOffsetValue;

            var displacement = 25; // displacement in px from bottom

            // if not enough space to show N items, use then calculated 'safeOffset'
            var menuTop = (vwHeight - itemTop > safeOffset) ? itemTop : (vwHeight - safeOffset - displacement);

            floatingNav
                .removeClass('opening') // necesary for demo if switched between normal//collapsed mode
                .css({
                    position: this.settings.getLayoutSetting('isFixed') ? 'fixed' : 'absolute',
                    top: menuTop,
                    bottom: (floatingNav.outerHeight(true) + menuTop > vwHeight) ? (displacement+'px') : 'auto'
                });

            floatingNav
                .on('mouseleave', () => { floatingNav.remove(); })
                .find('a').on('click', function(e) {
                    e.preventDefault(); // prevents page reload on click
                    // get the exact route path to navigate
                    let routeTo = $(this).attr('route');
                    if (routeTo) self.router.navigate([routeTo]);
                });

            this.listenForExternalClicks();

        }

    }

    listenForExternalClicks() {
        let $doc = $(document).on('click.sidebar', (e) => {
            if (!$(e.target).parents('.aside-container').length) {
                this.removeFloatingNav();
                $doc.off('click.sidebar');
            }
        });
    }

    removeFloatingNav() {
        $('.nav-floating').remove();
    }

    isSidebarCollapsed() {
        return this.settings.getLayoutSetting('isCollapsed');
    }
    isSidebarCollapsedText() {
        return this.settings.getLayoutSetting('isCollapsedText');
    }
    isEnabledHover() {
        return this.settings.getLayoutSetting('asideHover');
    }
}
