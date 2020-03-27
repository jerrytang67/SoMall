import { Component, OnInit, ViewChild, Input, Injector } from '@angular/core';
import { CategoryCreateOrUpdateDto } from 'src/api/appService';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-category-edit',
  templateUrl: './category-edit.component.html',
  styleUrls: ['./category-edit.component.scss']
})
export class CategoryEditComponent implements OnInit {


  @ViewChild('f', { static: true }) f: NgForm;

  @Input() title: string;

  @Input() id: string;

  @Input() form: CategoryCreateOrUpdateDto;

  i: any = {};

  constructor(private http: HttpClient) {
  }

  ngOnInit() {

  }

  onSubmit(f: NgForm) { }

  ngOnDestroy(): void {
  };

}
