import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SpuCreateOrUpdateDto, ProductSpuProxyService } from 'src/api/appService';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import * as DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
@Component({
  selector: 'app-spu-create',
  templateUrl: './spu-create.component.html',
  styleUrls: ['./spu-create.component.scss']
})
export class SpuCreateComponent implements OnInit {

  categoryId: string;

  form: SpuCreateOrUpdateDto = {
    name: "",
    code: "",
    categoryId: "",
    purchaseNotesCommon: "",
    descCommon: "",
  };

  public Editor = DecoupledEditor;
  public Editor2 = DecoupledEditor;

  public onReady(editor) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }

  public onReady2(editor) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }

  constructor(
    private api: ProductSpuProxyService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  guid = '00000000-0000-0000-0000-000000000000';

  optionList: any[]
  ngOnInit(): void {

    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      this.api.getForEdit({ id: this.guid }).subscribe(
        res => {
          this.form = res.data;
          this.optionList = res.schema.categoryId;
          this.form = Object.assign({}, this.form, { categoryId: params.params.categoryId });
        }
      )
    });
  }


  onSubmit(form: any) {
    console.log(form.value)

    this.api.create({
      body: form.value
    }).subscribe(res => {
      if (res.id) { this.router.navigate(['/mall/spus']) }
    })
  }

}
