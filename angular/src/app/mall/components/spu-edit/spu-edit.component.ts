import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SpuCreateOrUpdateDto, ProductSpuProxyService, OssProxyService } from 'src/api/appService';
import base64 from '@core/utils/base64';

@Component({
  selector: 'app-spu-edit',
  templateUrl: './spu-edit.component.html',
  styleUrls: ['../spu-create/spu-create.component.scss']
})
export class SpuEditComponent implements OnInit {

  spuId: string;

  categoryId: string;

  ckeConfig: any = {
    uploadUrl: "https://v0.api.upyun.com/ttwork",
    height: 500,
    allowedContent: false,
    forcePasteAsPlainText: true,
    font_names: 'Arial;Times New Roman;Verdana',
    toolbarGroups: [
      { name: 'document', groups: ['mode', 'document', 'doctools'] },
      { name: 'clipboard', groups: ['clipboard', 'undo'] },
      { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
      { name: 'forms', groups: ['forms'] },
      { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
      { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
      { name: 'links', groups: ['links'] },
      { name: 'insert', groups: ['insert'] },
      '/',
      { name: 'styles', groups: ['styles'] },
      { name: 'colors', groups: ['colors'] },
      { name: 'tools', groups: ['tools'] },
      { name: 'others', groups: ['others'] },
      { name: 'about', groups: ['about'] }
    ],
    removeButtons: 'Save,NewPage,Preview,Print,Templates,Scayt,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Strike,Subscript,Superscript,CopyFormatting,Outdent,Indent,CreateDiv,Blockquote,BidiLtr,BidiRtl,Language,Unlink,Anchor,Flash,Table,HorizontalRule,Smiley,SpecialChar,PageBreak,Iframe,Maximize,ShowBlocks,About'
  };

  form: SpuCreateOrUpdateDto = {
    name: "",
    code: "",
    categoryId: "",
    purchaseNotesCommon: "",
    descCommon: "",
  };

  operator = "somall";
  bucket: string = "ttwork";
  signature: string;
  policy: string;
  constructor(
    private api: ProductSpuProxyService,
    private ossApi: OssProxyService,
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