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

  form: SpuCreateOrUpdateDto;

  public Editor = DecoupledEditor;

  public onReady(editor) {
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

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      this.categoryId = params.params.categoryId

      this.form = {
        name: "",
        code: "",
        categoryId: this.categoryId,
        desc: ""
      }
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
