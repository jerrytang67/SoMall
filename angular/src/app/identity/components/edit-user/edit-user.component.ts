import { Component, OnInit, Input } from '@angular/core';
import { NzModalRef } from 'ng-zorro-antd/modal';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html'
})
export class EditUserComponent implements OnInit {

  @Input() title: string;
  @Input() subtitle: string;

  constructor(private modal: NzModalRef) { }

  ngOnInit(): void {
  }

  destroyModal(): void {
    this.modal.destroy({ data: 'this the result data' });
  }


}
