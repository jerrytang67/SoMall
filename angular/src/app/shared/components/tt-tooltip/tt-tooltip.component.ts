import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'tt-tooltip',
    template: `
        <i class="fa-lg m-1 text-info" 
        [class]="icon" 
        [nzTooltipTitle]="text" 
        [nzTooltipPlacement]="position" 
        [nzOverlayClassName]="nzOverlayClassName"
        nz-tooltip></i>
    `
})

export class TtTooltip implements OnInit {
    @Input() text: string;
    @Input() icon: string = "fa fa-question-circle"
    @Input() nzOverlayClassName: string = ""
    @Input() position: "topCenter" = "topCenter"
    constructor() { }

    ngOnInit() { }
}