import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SpuCreateOrUpdateDto, ProductSpuProxyService } from 'src/api/appService';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import * as DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
@Component({
  selector: 'app-spu-edit',
  templateUrl: './spu-edit.component.html',
  styleUrls: ['../spu-create/spu-create.component.scss']
})
export class SpuEditComponent implements OnInit {

  spuId: string;

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

  optionList: any[]
  ngOnInit(): void {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      this.spuId = params.params.id;
      this.api.getForEdit({ id: this.spuId }).subscribe(
        res => {
          this.form = res.data;
          this.optionList = res.schema.categoryId;
        }
      )
    });
  }


  onSubmit(form: any) {
    console.log(form.value)

    this.api.update({
      id: this.spuId,
      body: form.value
    }).subscribe(res => {
      if (res.id) { this.router.navigate(['/mall/spus']) }
    })
  }

}
