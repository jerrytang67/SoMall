import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'tt-tooltip',
    template: `
        <i class="fa fa-question-circle fa-lg m-1 text-info" [nzTooltipTitle]="text" [nzTooltipPlacement]="position" nz-tooltip></i>
    `
})

export class TtTooltip implements OnInit {
    @Input() text: string;
    @Input() position: "topCenter" = "topCenter"
    constructor() { }

    ngOnInit() { }
}