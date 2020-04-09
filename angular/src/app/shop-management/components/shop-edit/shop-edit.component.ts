import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { VisitorShopCreateOrEditDto } from 'src/api/appService';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-shop-edit',
  templateUrl: './shop-edit.component.html',
  styleUrls: ['./shop-edit.component.scss']
})
export class ShopEditComponent implements OnInit {
  @ViewChild('f', { static: true }) f: NgForm;
  @Input() title: string;
  @Input() id: string;
  @Input() form: VisitorShopCreateOrEditDto;

  constructor() {
  }

  ngOnInit() {
  }
}
