import { Component, OnInit, ViewChild, Input, Injector } from '@angular/core';
import { AuditFlowCreateOrEditDto, AuditNodeDto } from 'src/api/appService';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';

@Component({
    selector: 'app-auditFlow-edit',
    templateUrl: './app-auditFlow-edit.html',
    styleUrls: ['./app-auditFlow-edit.scss']
})
export class AuditFlowEditComponent implements OnInit {

    @ViewChild('f', { static: true }) f: NgForm;

    @Input() title: string;

    @Input() id: string;

    @Input() audits: any[];

    @Input() form: AuditFlowCreateOrEditDto;

    i: any = {};

    testNode: AuditNodeDto = { auditFlowId: "123", desc: "Desc", userName: "TT" }

    lists = [
        [this.testNode]
    ]

    constructor(private http: HttpClient) {
    }

    ngOnInit() {

    }

    onSubmit(f: NgForm) { }

    ngOnDestroy(): void {
    };

    updateSingleChecked(event) {
        console.log(event)
    }

    drop(event: CdkDragDrop<string[]>) {
        if (event.previousContainer === event.container) {
            moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
        } else {
            transferArrayItem(event.previousContainer.data,
                event.container.data,
                event.previousIndex,
                event.currentIndex);
        }

        console.log(this.lists);
    }


    addNewNode() {
        this.lists = [...this.lists, [this.testNode]]
    }

    removeEmpty() {
        this.lists = [...this.lists.filter(x => x.length > 0)];
    }



}
